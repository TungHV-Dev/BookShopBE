using BookShopBE.Common.Dtos;

namespace BookShopBE.Common.Constants
{
    public static class SQLStatements
    {
        public static string GetByIdQuery<TEntity>(int id) where TEntity : class
        {
            return $"SELECT * FROM {typeof(TEntity).Name}s WHERE Id = '{id}'";
        }

        public static string GetAllQuery<TEntity>() where TEntity : class
        {
            return $"SELECT * FROM {typeof(TEntity).Name}s";
        }

        public static string DeleteCommand<TEntity>(int id) where TEntity : class
        {
            return $"DELETE FROM {typeof(TEntity).Name}s WHERE Id = '{id}'";
        }
    }
}
