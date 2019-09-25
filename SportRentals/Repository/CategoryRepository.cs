using SportRentals.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportRentals.Repository
{
    public class CategoryRepository
    {
        private Models.DBObjects.SportRentalsDataContext dbContext;

        public CategoryRepository()
        {
            this.dbContext = new Models.DBObjects.SportRentalsDataContext();
        }

        public CategoryRepository(Models.DBObjects.SportRentalsDataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        private CategoryModel MapDbObjectToModel(Models.DBObjects.Category dbCategory)
        {
            CategoryModel categoryModel = new CategoryModel();
            if(dbCategory!=null)
            {
                categoryModel.CategoryID = dbCategory.CategoryID;
                categoryModel.Name = dbCategory.Name;
                categoryModel.Description = dbCategory.Description;

                return categoryModel;
            }
            return null;
        }

        private Models.DBObjects.Category MapModelToDbObject(CategoryModel categoryModel)
        {
            Models.DBObjects.Category dbCategoryModel = new Models.DBObjects.Category();
            if(categoryModel !=null)
            {
                dbCategoryModel.CategoryID = categoryModel.CategoryID;
                dbCategoryModel.Name = categoryModel.Name;
                dbCategoryModel.Description = categoryModel.Description;

                return dbCategoryModel;

            }
            return null;
        }

        public List<CategoryModel> GetAllCategories()
        {
            List<CategoryModel> categoryList = new List<CategoryModel>();
            foreach(Models.DBObjects.Category dbCategory in dbContext.Categories)
            {
                categoryList.Add(MapDbObjectToModel(dbCategory));
            }
            return categoryList;
        }

        public CategoryModel GetCategoryByID( int ID)
        {
            return MapDbObjectToModel(dbContext.Categories.FirstOrDefault(x => x.CategoryID == ID));
        }

        public void DeleteCategory (int ID)
        {
            Models.DBObjects.Category categoryToDelete = dbContext.Categories.FirstOrDefault(x => x.CategoryID == ID);
            if(categoryToDelete !=null)
            {
                dbContext.Categories.DeleteOnSubmit(categoryToDelete);
                dbContext.SubmitChanges();
            }
        }

        public void InsertCategory(CategoryModel categoryModel)
        {
            dbContext.Categories.InsertOnSubmit(MapModelToDbObject(categoryModel));
            dbContext.SubmitChanges(0);
        }
    }
}