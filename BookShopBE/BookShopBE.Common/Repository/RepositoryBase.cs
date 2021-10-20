using BookShopBE.Common.Constants;
using BookShopBE.Common.Dtos;
using BookShopBE.Common.Enums;
using BookShopBE.Common.Paging;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShopBE.Common.Repository
{
    public class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class
    {
        #region Properties
        protected readonly DbContext _context;
        #endregion

        #region Ctor
        public RepositoryBase(DbContext context)
        {
            _context = context;
        }
        #endregion

        #region Function
        public async Task<TEntity> GetById(int id)
        {
            return await _context.Set<TEntity>().FromSqlRaw(SQLStatements.GetByIdQuery<TEntity>(id)).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _context.Set<TEntity>().FromSqlRaw(SQLStatements.GetAllQuery<TEntity>()).ToListAsync();
        }

        public async Task<int> Delete(int id)
        {
            return await _context.Database.ExecuteSqlRawAsync(SQLStatements.DeleteCommand<TEntity>(id));
        }
        #endregion
    }
}
