using Model;
using Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class RequestsConroller
    {
        private CourseWorkDbContext context;
        private readonly EmailController email;
        private readonly ProductController productController;
        private readonly ProvidersController providerController;
        public RequestsConroller(CourseWorkDbContext context, EmailController email, ProductController productController, ProvidersController providerController)
        {
            this.context = context;
            this.productController = productController;
            this.providerController = providerController;
            this.email = email;
        }
        // список заявок для отдельного пользователя
        public List<RequestViewModel> GetList()
        {
            int uId = AuthController.authId;
            List<RequestViewModel> result = context.Requests.Where(rec => rec.UserId == uId).Select(rec => new
           RequestViewModel
            {
                Id = rec.Id,
                Date = rec.Date,
                Address = rec.Address,
                ReceiptMark = rec.ReceiptMark,
                DateReception = rec.DateReception,
                Prioritet = rec.Prioritet,
                UserId = rec.UserId
            })
            .ToList();
            return result;
        }

        // полный список заявок
        public List<RequestViewModel> GetFullList()
        {
            List<RequestViewModel> result = context.Requests.Select(rec => new
           RequestViewModel
            {
                Id = rec.Id,
                Date = rec.Date,
                Address = rec.Address,
                ReceiptMark = rec.ReceiptMark,
                DateReception = rec.DateReception,
                Prioritet = rec.Prioritet,
                UserId = rec.UserId
            })
            .ToList();
            return result;
        }

        // добавление новой заявки
        public void AddElement(Request model)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Request element = new Request
                    {
                        Id = model.Id,
                        Date = model.Date,
                        Address = model.Address,
                        ReceiptMark = false,
                        DateReception = null,
                        Prioritet = model.Prioritet,
                        UserId = AuthController.authId
                    };
                    context.Requests.Add(element);
                    context.SaveChanges();
                    transaction.Commit();
                    
                    string address = findEmail(AuthController.authId);
                    email.SendEmail(address, "Оформление заказа", "Ваш заказ на " + model.Date.ToString() + " принят в обработку");
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        // поиск адреса почты клиента
        public string findEmail(int userId)
        {
            User element = context.Users.FirstOrDefault(rec => rec.Id == userId);
            string result = element.Email;
            return result;
        }

        // поиск заявки по id 
        public int recId(DateTime dateRec)
        {
            Request element = context.Requests.FirstOrDefault(rec => rec.Date == dateRec);
            int result = element.Id;
            return result;
        }

        // добавление товаров в заявку
        public void addProdToRequest(RequestProduct model)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    RequestProduct element = new RequestProduct
                    {
                        Id = model.Id,
                        RequestId = model.RequestId,
                        ProductId = model.ProductId,
                        Status = model.Status,
                        Amount = model.Amount,
                        ProviderId = model.ProviderId
                    };
                    context.RequestProducts.Add(element);
                    context.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        // детали заявки (товары в заявке)
        public List<RequestProductViewModel> GetDetails(int recId)
        {
            List<RequestProductViewModel> result = context.RequestProducts.Where(rec => rec.RequestId == recId).Select(rec => new
           RequestProductViewModel
            {
                Id = rec.Id,
                RequestId = rec.RequestId,
                ProductId = rec.ProductId,
                Status = rec.Status,
                Amount = rec.Amount,
                ProviderId = rec.ProviderId
            })
            .ToList();
            return result;
        }

        // список товаров в каждой заявке (для исполнителя)
        public List<RequestProductViewModel> GetDetailsOnAll()
        {
            List<RequestProductViewModel> result = context.RequestProducts.Select(rec => new
           RequestProductViewModel
            {
                Id = rec.Id,
                RequestId = rec.RequestId,
                ProductId = rec.ProductId,
                Status = rec.Status,
                Amount = rec.Amount,
                ProviderId = rec.ProviderId
            })
            .ToList();
            return result;
        }

        // список нераспределенных заявок
        public List<RequestProductViewModel> GetUnclassified()
        {
            List<RequestProductViewModel> result = context.RequestProducts.Where(rec => rec.ProviderId == 1).Select(rec => new
           RequestProductViewModel
            {
                Id = rec.Id,
                RequestId = rec.RequestId,
                ProductId = rec.ProductId,
                Status = rec.Status,
                Amount = rec.Amount,
                ProviderId = rec.ProviderId
            })
            .ToList();
            return result;
        }

        // назначение поставщиков заявкам 
        public List<RequestProductViewModel> FindProviders(){
            List<RequestProductViewModel> result = context.RequestProducts.Where(rec => rec.ProviderId == 1).Select(rec => new
           RequestProductViewModel
            {
                Id = rec.Id,
                RequestId = rec.RequestId,
                ProductId = rec.ProductId,
                Status = rec.Status,
                Amount = rec.Amount,
                ProviderId = rec.ProviderId
            })
            .ToList();

            for (int i = 0; i < result.Count; i++)
            {
                int recuestId = result[i].RequestId;
                Request el = context.Requests.FirstOrDefault(rec => rec.Id == recuestId);
                int Prioritet = el.Prioritet;

                int prodId = result[i].ProductId;
                int amount = result[i].Amount;
                int providerId = 1;

                if (Prioritet == 0)
                {
                    providerId = FindProviderWithMinPrice(prodId, amount);
                } else
                {
                    providerId = FindProviderWithBestRating(prodId, amount);
                }                
                //result[i].ProviderId = providerId;
                RequestProduct element = getById(result[i].Id);
                element.ProviderId = providerId;
                element.Status = "Заказ передан поставщику";
                decimal totalPrice = changeInStockAmount(prodId, providerId, amount);
                context.SaveChanges();
                int user = getUserIdForRequest(result[i].RequestId);
                string address = findEmail(user);
                email.SendEmail(address, "Изменение статуса заказа", "Доставка " + productController.ProductNameById(result[i].ProductId) + " передана " + providerController.ProviderNameById(providerId) + ". Стоимость доставки составила " + totalPrice);
            }

            context.SaveChanges();
            return result;
        }

        // изм количества товара на складе
        public decimal changeInStockAmount(int prodId, int providerId, int amount)
        {
            ProviderProduct element = context.ProviderProducts.FirstOrDefault(rec => rec.ProviderId == providerId && rec.ProductId == prodId);
            element.InStockAmount = element.InStockAmount - amount;            
            context.SaveChanges();
            decimal totalPrice = element.Price * amount;
            return totalPrice;
        }

        // получение товаров в заявке по id 
        public RequestProduct getById(int recId)
        {
            RequestProduct element = context.RequestProducts.FirstOrDefault(rec => rec.Id == recId);
            return element;
        }

        // завершение заявки (статус и дата окончания)
        public void finishOrder(int recId, DateTime reception)
        {
            Request element = context.Requests.FirstOrDefault(rec => rec.Id == recId);
            element.ReceiptMark = true;
            element.DateReception = reception;
            context.SaveChanges();
            RequestProduct element1 = getById(element.Id);
            element1.Status = "Завершен";
            context.SaveChanges();
            int user = getUserIdForRequest(recId);
            string address = findEmail(user);
            email.SendEmail(address, "Завершение заказа", "Доставка заказа № " + recId + " выполнена");
        }

        // получение id заказчика по заказу
        public int getUserIdForRequest(int recId)
        {
            Request element = context.Requests.FirstOrDefault(rec => rec.Id == recId);
            int user = element.UserId;
            return user;
        }

        // поиск поставщика с минимальной ценой
        public int FindProviderWithMinPrice(int productId, int amount)
        {
            List<ProviderProductViewModel> choices = context.ProviderProducts.Where(rec => rec.ProductId == productId && rec.InStockAmount >= amount).Select(rec => new
           ProviderProductViewModel
            {
                Id = rec.Id,
                ProviderId = rec.ProviderId,
                ProductId = rec.ProductId,
                Price = rec.Price,
                InStockAmount = rec.InStockAmount
            })
            .ToList();
            int result = 1; 
            if (choices.Count != 1)
            {
                decimal minPrice = 10000;
                for (int i = 0; i < choices.Count; i++)
                {
                    if (choices[i].Price < minPrice)
                    {
                        minPrice = choices[i].Price;
                        result = choices[i].ProviderId;
                    }
                }
            } 
            else if (choices.Count == 1)
            {
                result = choices[0].ProviderId;
            }
            else if (choices.Count == 0)
            {
                result = 1;            
            }                      
            return result;
        }


        public int FindProviderWithBestRating(int productId, int amount)
        {
            List<ProviderProductViewModel> choices = context.ProviderProducts.Where(rec => rec.ProductId == productId && rec.InStockAmount >= amount).Select(rec => new
           ProviderProductViewModel
            {
                Id = rec.Id,
                ProviderId = rec.ProviderId,
                ProductId = rec.ProductId,
                Price = rec.Price,
                InStockAmount = rec.InStockAmount
            })
            .ToList();
            int result = 1;
            if (choices.Count != 1)
            {
                decimal bestRating = 0;
                for (int i = 0; i < choices.Count; i++)
                {
                    int provId = choices[i].ProviderId;
                    Provider element = context.Providers.FirstOrDefault(rec => rec.Id == provId);
                    decimal rating = element.Rating;
                    if (rating > bestRating)
                    {
                        bestRating = rating;
                        result = choices[i].ProviderId;
                    }
                }
            }
            else if (choices.Count == 1)
            {
                result = choices[0].ProviderId;
            }
            else if (choices.Count == 0)
            {
                result = 1;
            }
            return result;
        }
    }

}
