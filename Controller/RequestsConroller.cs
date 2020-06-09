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
        public RequestsConroller(CourseWorkDbContext context)
        {
            this.context = context;
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
                Feedback = rec.Feedback,
                ReceiptMark = rec.ReceiptMark,
                UserId = rec.UserId
            })
            .ToList();
            return result;
        }

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
                        Feedback = null,
                        ReceiptMark = false,
                        UserId = AuthController.authId
                    };
                    context.Requests.Add(element);
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

        public int recId(DateTime dateRec)
        {
            Request element = context.Requests.FirstOrDefault(rec => rec.Date == dateRec);
            int result = element.Id;
            return result;
        }

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
    }

}
