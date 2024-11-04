using GameShopEntity.DataAccessLayer.Entities;
using GameShopEntity.DataAccessLayer.Pagination;
using GameShopEntity.DataAccessLayer.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShopEntity.DataAccessLayer.Interface.Repositories
{
    public interface ICategoriesRepository : IRepository<Categories>
    {
        Task<PagedList<Categories>> GetAsync(CategoriesParameter categoriesParameter);
        Task AddCategories(int id, Categories category);
        Task DeleteCategories(int id);
    }
}
