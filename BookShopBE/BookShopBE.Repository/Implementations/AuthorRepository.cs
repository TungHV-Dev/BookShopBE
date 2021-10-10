using BookShopBE.Common.Repository;
using BookShopBE.Data.DataContext;
using BookShopBE.Data.Models;
using BookShopBE.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookShopBE.Repository.Implementations
{
    public class AuthorRepository : RepositoryBase<Author>, IAuthorRepository
    {
        public AuthorRepository(BookShopDbContext context) : base(context)
        {

        }


    }
}
