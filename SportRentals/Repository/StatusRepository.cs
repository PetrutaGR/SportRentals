using SportRentals.Models;
using SportRentals.Models.DBObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportRentals.Repository
{
    public class StatusRepository
    {
        private Models.DBObjects.SportRentalsDataContext dbContext;

        public StatusRepository()
        {
            this.dbContext = new Models.DBObjects.SportRentalsDataContext();
        }

        public StatusRepository(Models.DBObjects.SportRentalsDataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<StatusModel> GetAllStatuses()
        {
            List<StatusModel> statusList = new List<StatusModel>();
            foreach (Models.DBObjects.Status status in dbContext.Status)
            {
                statusList.Add(MapDbObjectToModel(status));
            }
            return statusList;
        }

        private StatusModel MapDbObjectToModel(Status status)
        {
            var statusModel = new StatusModel();
            statusModel.StatusID = status.StatusID;
            statusModel.Name = status.Name;
            statusModel.Description = status.Description;

            return statusModel;
        }

        public StatusModel GetStatus(int statusId)
        {
            return MapDbObjectToModel(dbContext.Status.FirstOrDefault(x => x.StatusID == statusId));
        }

    }

}