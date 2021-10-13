using System.Threading.Tasks;

namespace BookShopBE.Core.Services.Interfaces
{
    public interface IAccountServices
    {
        Task<bool> Login();
        Task<bool> Register();
    }
}
