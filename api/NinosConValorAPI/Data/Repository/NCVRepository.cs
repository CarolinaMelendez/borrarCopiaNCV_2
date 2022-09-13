﻿using Microsoft.EntityFrameworkCore;
using NinosConValorAPI.Data.Entity;

namespace NinosConValorAPI.Data.Repository
{
    public class NCVRepository:INCVRepository
    {
        private NCV_DBContext _dbContext;
        public NCVRepository(NCV_DBContext NCV_DBContext)
        {
            _dbContext = NCV_DBContext;
        }

        public void CreateFixedAsset(FixedAssetEntity fixedAsset)
        {
            _dbContext.FixedAssets.Add(fixedAsset);
        }

        public async Task<bool> SaveChangesAsync()
        {
            try
            {
                var result = await _dbContext.SaveChangesAsync();
                return result > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<FixedAssetEntity>> GetFixedAssetsAsync()
        {
            IQueryable<FixedAssetEntity> query = _dbContext.FixedAssets;
            query = query.AsNoTracking();
            var result = await query.ToListAsync();
            return result;
        }
    }
}
