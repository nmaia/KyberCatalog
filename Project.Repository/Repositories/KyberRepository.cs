﻿using Microsoft.EntityFrameworkCore;
using Project.Domain.Contracts.Repositories;
using Project.Domain.Entities;
using Project.Repository.Repositories.Common;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Repository.Repositories
{
    public class KyberRepository : RepositoryBase<Kyber>, IKyberRepository
    {
        public override async Task<IEnumerable<Kyber>> SearchByNameOrColor(string searchObj)
        {
            return await db.Set<Kyber>()
                .Where(k => k.Name.ToLower().Contains(searchObj.ToLower()) || 
                            k.Color.ToLower().Contains(searchObj.ToLower()))
                                .ToListAsync();
        }
    }
}
