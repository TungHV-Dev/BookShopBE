using AutoMapper;
using BookShopBE.Data.Dtos.Authentications;
using BookShopBE.Data.Dtos.Books;
using BookShopBE.Data.Dtos.Carts;
using BookShopBE.Data.Dtos.Feedbacks;
using BookShopBE.Data.Dtos.Orders;
using BookShopBE.Data.Dtos.Users;
using BookShopBE.Data.Models;

namespace BookShopBE.Core.Mappings
{
    public class ModelMapping : Profile
    {
        public ModelMapping()
        {
            CreateMap<Book, BookResponse>();
            CreateMap<Order, OrderResponse>()
                .ForMember(destination => destination.CustomerName, options => options.MapFrom(source => source.Customer.CustomerName))
                .ForMember(destination => destination.CustomerEmail, options => options.MapFrom(source => source.Customer.CustomerEmail))
                .ForMember(destination => destination.BookName, options => options.MapFrom(source => source.Book.Name));

            CreateMap<Cart, BookInCartDto>()
                .ForMember(destination => destination.CartId, options => options.MapFrom(source => source.Id))
                .ForMember(destination => destination.BookName, options => options.MapFrom(source => source.Book.Name))
                .ForMember(destination => destination.BookGenre, options => options.MapFrom(source => source.Book.Genre))
                .ForMember(destination => destination.BookPrice, options => options.MapFrom(source => source.Book.Price))
                .ForMember(destination => destination.BookUrl, options => options.MapFrom(source => source.Book.Url))
                .ForMember(destination => destination.PublisherName, options => options.MapFrom(source => source.Book.PublisherName));

            CreateMap<Feedback, FeedbackResponse>()
                .ForMember(destination => destination.FeedbackId, options => options.MapFrom(source => source.Id))
                .ForMember(destination => destination.CustomerId, options => options.MapFrom(source => source.CustomerId))
                .ForMember(destination => destination.CustomerName, options => options.MapFrom(source => source.Customer.CustomerName));

            CreateMap<RegisterRequest, User>();
            CreateMap<EditUserDto, User>();
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
        }
    }
}
