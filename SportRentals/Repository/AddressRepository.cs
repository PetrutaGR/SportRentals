using SportRentals.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportRentals.Repository
{
    public class AddressRepository
    {

        private Models.DBObjects.SportRentalsDataContext dbContext;

        public AddressRepository()
        {
            this.dbContext = new Models.DBObjects.SportRentalsDataContext();

        }

        public AddressRepository(Models.DBObjects.SportRentalsDataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        private AddressModel MapDbObjectToModel(Models.DBObjects.Address dbAddress)
        {
            AddressModel addressModel = new AddressModel();
            if(dbAddress !=null)
            {
                addressModel.AddressID = dbAddress.AddressID;
                addressModel.Country = dbAddress.Country;
                addressModel.County = dbAddress.County;
                addressModel.City = dbAddress.City;
                addressModel.Street = dbAddress.Street;
                addressModel.StreetNumber = dbAddress.StreetNumber;
                addressModel.PostCode = dbAddress.PostCode;

                return addressModel;              
            }
            return null;
        }

        private Models.DBObjects.Address MapModelToDbObject(AddressModel addressModel)
        {
            Models.DBObjects.Address dbAddressModel = new Models.DBObjects.Address();
            if(addressModel !=null)
            {
                dbAddressModel.AddressID = addressModel.AddressID;
                dbAddressModel.Country = addressModel.Country;
                dbAddressModel.County = addressModel.County;
                dbAddressModel.City = addressModel.City;
                dbAddressModel.Street = addressModel.Street;
                dbAddressModel.StreetNumber = addressModel.StreetNumber;
                dbAddressModel.PostCode = addressModel.PostCode;

                return dbAddressModel;
            }
            return null;         

        }

        public List<AddressModel> GetAllAddresses()
        {
            List<AddressModel> addressList = new List<AddressModel>();

            foreach(Models.DBObjects.Address dbAddress in dbContext.Addresses)
            {
                addressList.Add(MapDbObjectToModel(dbAddress));
            }
            return addressList;
        }

        public AddressModel GetAddressByID(int ID)
        {
            return MapDbObjectToModel(dbContext.Addresses.FirstOrDefault(x => x.AddressID == ID));
        }

        public void InsertAddress(AddressModel addressModel)
        {
            dbContext.Addresses.InsertOnSubmit(MapModelToDbObject(addressModel));
            dbContext.SubmitChanges();
        }

        public void UpdateAddress(AddressModel addressModel)
        {
            Models.DBObjects.Address existingAddress = dbContext.Addresses.FirstOrDefault(x => x.AddressID == addressModel.AddressID);
            if(existingAddress !=null)
            {
                existingAddress.AddressID = addressModel.AddressID;
                existingAddress.Country = addressModel.Country;
                existingAddress.County = addressModel.County;
                existingAddress.City = addressModel.City;
                existingAddress.Street = addressModel.Street;
                existingAddress.StreetNumber = addressModel.StreetNumber;
                existingAddress.PostCode = addressModel.PostCode;

                dbContext.SubmitChanges();

            }
        }

        public void DeleteAddress(int ID)
        {
            Models.DBObjects.Address addressToDelete = dbContext.Addresses.FirstOrDefault(x => x.AddressID == ID);
            if(addressToDelete!= null)
            {
                dbContext.Addresses.DeleteOnSubmit(addressToDelete);
                dbContext.SubmitChanges();
            }
        }
    }
}