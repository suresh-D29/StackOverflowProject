using System;
using System.Collections.Generic;
using System.Linq;
using StackOverflowProject.DomainModels;
using StackOverflowProject.Repositories;
using StackOverflowProject.ViewModels;
using AutoMapper;
using AutoMapper.Configuration;

namespace StackOverflowProject.ServiceLayer
{
    public interface ICategoriesServices
    {
        void InsertCategory(CategoryViewModel cvm);
        void UpdateCategory(CategoryViewModel cvm);
        void DeleteCategory(int cid);
        List<CategoryViewModel> GetCategories();
        CategoryViewModel GetCategoryByCategoryID(int CategoryID);
    }
    public class CategoriesService:ICategoriesServices
    {
        ICategoriesRepository cr;

        public CategoriesService()
        {
            cr = new CategoriesRepository();
        }

        public void InsertCategory(CategoryViewModel cvm)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<CategoryViewModel, Category>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            Category c = mapper.Map<CategoryViewModel, Category>(cvm);
            cr.insertCategory(c);
        }

        public void UpdateCategory(CategoryViewModel cvm)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<CategoryViewModel, Category>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            Category c = mapper.Map<CategoryViewModel, Category>(cvm);
            cr.UpdateCategory(c);
        }

        public void DeleteCategory(int cid)
        {
            cr.deleteCategory(cid);
        }

        public List<CategoryViewModel> GetCategories()
        {
            List<Category> c = cr.GetCategories();
            var confg = new MapperConfiguration(cfg => { cfg.CreateMap<User, CategoryViewModel>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = confg.CreateMapper();
            List<CategoryViewModel> cvm = mapper.Map<List<Category>, List<CategoryViewModel>>(c);
            return cvm;
        }

        public CategoryViewModel GetCategoryByCategoryID(int CategoryID)
        {
            Category c = cr.GetCategoryByCategoryID(CategoryID).FirstOrDefault();
            CategoryViewModel cvm = null;
            if (c != null)
            {
                var confg = new MapperConfiguration(cfg => { cfg.CreateMap<User, CategoryViewModel>(); cfg.IgnoreUnmapped(); });
                IMapper mapper = confg.CreateMapper();
                 cvm = mapper.Map<Category, CategoryViewModel>(c);
            }
            return cvm;
        }
    }
}
