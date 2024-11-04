﻿using GameShopEntity.DataAccessLayer.Entities;
using GameShopEntity.DataAccessLayer.Pagination;
using GameShopEntity.DataAccessLayer.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShopEntity.DataAccessLayer.Interface.Repositories
{
    public interface ICategoriesGamesRepository: IRepository<GameCategory>
    {
        Task<PagedList<GameCategory>> GetAsync(GameCategoryParameter gameCategoryParameter);
    }
}