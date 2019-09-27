using SportRentals.Models;
using SportRentals.Models.DBObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportRentals.Repository
{
    public class CustomerRepository
    {

        private Models.DBObjects.SportRentalsDataContext dbContext;

        public CustomerRepository()
        {
            this.dbContext = new Models.DBObjects.SportRentalsDataContext();



        }

        public CustomerRepository(Models.DBObjects.SportRentalsDataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        private CustomerModel MapDbObjectToModel(Models.DBObjects.Customer dbCustomer)
        {
            CustomerModel customerModel = new CustomerModel();

            if(dbCustomer != null)
            {
                customerModel.CustomerID = dbCustomer.CustomerID;
                customerModel.FirstName = dbCustomer.FirstName;
                customerModel.LastName = dbCustomer.LastName;
                customerModel.Phone = dbCustomer.Phone;
                customerModel.Email = dbCustomer.Email;
                customerModel.AddressID = dbCustomer.AddressId;

                return customerModel;
            }

            return null;

        }

        private Models.DBObjects.Customer MapModelToDbOject(CustomerModel customerModel)
        {
            Models.DBObjects.Customer dbCustomerModel = new Models.DBObjects.Customer();

            if(customerModel != null)
            {
                dbCustomerModel.CustomerID = customerModel.CustomerID;
                dbCustomerModel.FirstName = customerModel.FirstName;
                dbCustomerModel.LastName = customerModel.LastName;
                dbCustomerModel.Phone = customerModel.Phone;
                dbCustomerModel.Email = customerModel.Email;
                dbCustomerModel.UserID = customerModel.UserID;
                dbCustomerModel.AddressId = customerModel.AddressID;

                return dbCustomerModel;
            }
            return null;
        }

        public List<CustomerModel> GetAllCustomers()
        {
            List<CustomerModel> customerList = new List<CustomerModel>();
            foreach(Models.DBObjects.Customer dbCustomer in dbContext.Customers)
            {

                customerList.Add(MapDbObjectToModel(dbCustomer));
            }
            return customerList;
        }

        public CustomerModel GetCustomerById(int ID)
        {
            return MapDbObjectToModel(dbContext.Customers.FirstOrDefault(x => x.CustomerID == ID));
        }

        public void InsertCustomer(CustomerModel customerModel)
        {
            dbContext.Customers.InsertOnSubmit(MapModelToDbOject(customerModel));
            dbContext.SubmitChanges();

        }

       
        public void UpdateCustomer(CustomerModel customerModel)
        {
            Models.DBObjects.Customer existingCustomer = dbContext.Customers.FirstOrDefault(x => x.CustomerID == customerModel.CustomerID);
            if(existingCustomer != null)
            {
                existingCustomer.CustomerID = customerModel.CustomerID;
                existingCustomer.FirstName = customerModel.FirstName;
                existingCustomer.LastName = customerModel.LastName;
                existingCustomer.Phone = customerModel.Phone;
                existingCustomer.Email = customerModel.Email;

                dbContext.SubmitChanges();


            }
        }

        public void DeleteCustomer(int ID)
        {
            Models.DBObjects.Customer customerToDelete = dbContext.Customers.FirstOrDefault(x => x.CustomerID == ID);
            if(customerToDelete!=null)
            {
                dbContext.Customers.DeleteOnSubmit(customerToDelete);
                dbContext.SubmitChanges();

                    

            }

        }
      
    }
}