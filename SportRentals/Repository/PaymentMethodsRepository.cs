using SportRentals.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportRentals.Repository
{
    public class PaymentMethodsRepository
    {

        private Models.DBObjects.SportRentalsDataContext dbContext;

        public PaymentMethodsRepository()
        {
            this.dbContext = new Models.DBObjects.SportRentalsDataContext();
        }

        public PaymentMethodsRepository(Models.DBObjects.SportRentalsDataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        private PaymentMethodModel MapDbObjectToModel(Models.DBObjects.PaymentMethod dbPaymentMethod)
        {
            PaymentMethodModel paymentMethodModel = new PaymentMethodModel();
            if(dbPaymentMethod!=null)
            {
                paymentMethodModel.PaymentMethodID = dbPaymentMethod.PaymentMethodID;
                paymentMethodModel.Name = dbPaymentMethod.Name;
                paymentMethodModel.Description = dbPaymentMethod.Description;

                return paymentMethodModel;
            }

            return null;
        }

        private Models.DBObjects.PaymentMethod MapModelToDbObject(PaymentMethodModel paymentMethodModel)
        {
            Models.DBObjects.PaymentMethod dbpaymentMethodModel = new Models.DBObjects.PaymentMethod();
            if(paymentMethodModel!=null)
            {
                dbpaymentMethodModel.PaymentMethodID = paymentMethodModel.PaymentMethodID;
                dbpaymentMethodModel.Name = paymentMethodModel.Name;
                dbpaymentMethodModel.Description = paymentMethodModel.Description;

                return dbpaymentMethodModel;
            }
            return null;
        }

        public List<PaymentMethodModel> GetAllPaymentMethods()
        {
            List<PaymentMethodModel> paymentMethodList = new List<PaymentMethodModel>();

            foreach(Models.DBObjects.PaymentMethod dbPaymentMethod in dbContext.PaymentMethods)
            {
                paymentMethodList.Add(MapDbObjectToModel(dbPaymentMethod));
            }
            return paymentMethodList;
        }

        public PaymentMethodModel GetPaymentMethodByID(int ID)
        {
            return MapDbObjectToModel(dbContext.PaymentMethods.FirstOrDefault(x => x.PaymentMethodID == ID));
        }

        public void InsertPaymentMethod(PaymentMethodModel paymentMethodModel)
        {
            dbContext.PaymentMethods.InsertOnSubmit(MapModelToDbObject(paymentMethodModel));
            dbContext.SubmitChanges();
        }

        public void UpdatePaymentMethod(PaymentMethodModel paymentMethodModel)
        {
            Models.DBObjects.PaymentMethod existingPaymentMethod = dbContext.PaymentMethods.FirstOrDefault(x => x.PaymentMethodID == paymentMethodModel.PaymentMethodID);
            if(existingPaymentMethod !=null)
            {
                existingPaymentMethod.PaymentMethodID = paymentMethodModel.PaymentMethodID;
                existingPaymentMethod.Name = paymentMethodModel.Name;
                existingPaymentMethod.Description = paymentMethodModel.Description;
                dbContext.SubmitChanges();
             
            }
        }

        public void DeletePaymentMethod(int ID)
        {
            Models.DBObjects.PaymentMethod paymentMethodToDelete=dbContext.PaymentMethods.FirstOrDefault(x=>x.PaymentMethodID==ID);
            if(paymentMethodToDelete!=null)
            {
                dbContext.PaymentMethods.DeleteOnSubmit(paymentMethodToDelete);
                dbContext.SubmitChanges();
            }
        }
    }
}