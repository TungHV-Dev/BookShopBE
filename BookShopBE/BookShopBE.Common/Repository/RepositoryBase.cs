using BookShopBE.Common.Constants;
using BookShopBE.Common.Enums;
using BookShopBE.Common.Paging;
using BookShopBE.Data.BaseModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShopBE.Common.Repository
{
    public class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : ModelBase
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

        public async Task<PagingResponse<TEntity>> GetAllPaging(PagingRequest request)
        {
            var response = await _context.Set<TEntity>().FromSqlRaw(SQLStatements.GetAllQuery<TEntity>()).ToListAsync();
            var result = new PagingResponse<TEntity>()
            {
                PageSize = request.PageSize,
                Data = response
            };

            #region Sort by entity's name
            if (request.Sort != null)
            {
                switch (request.Sort)
                {
                    case SortType.ASC:
                        {
                            result.Data = result.Data.OrderBy(entity => entity.Name).ToList();
                        }
                        break;
                    case SortType.DESC:
                        {
                            result.Data = result.Data.OrderByDescending(entity => entity.Name).ToList();
                        }
                        break;
                    default: break;
                }
            }
            #endregion

            #region Searching
            if(!String.IsNullOrEmpty(request.Search))
            {
                result.Data = result.Data.Where(entity => entity.Name.Contains(request.Search, StringComparison.CurrentCultureIgnoreCase)).ToList();
            }
            #endregion

            #region Paging
            if(request.PageNumber == null || request.PageNumber < 1)
            {
                var pagingResult = PaginatedList<TEntity>.Create(result.Data.AsQueryable(), 1, result.PageSize);
                result.Data = pagingResult;
                result.TotalPage = pagingResult.TotalPages;
                result.TotalItem = pagingResult.Count;
            }
            else
            {
                var pagingResult = PaginatedList<TEntity>.Create(result.Data.AsQueryable(), (int)request.PageNumber, request.PageSize);
                result.Data = pagingResult;
                result.TotalPage = pagingResult.TotalPages;
                result.TotalItem = pagingResult.Count;
            }
            #endregion

            return result;
        }

        public async Task<int> Delete(int id)
        {
            return await _context.Database.ExecuteSqlRawAsync(SQLStatements.DeleteCommand<TEntity>(id));
        }
        #endregion
    }
}
