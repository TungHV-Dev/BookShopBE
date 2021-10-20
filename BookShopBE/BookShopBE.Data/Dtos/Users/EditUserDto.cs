using System;

namespace BookShopBE.Data.Dtos.Users
{
    public class EditUserDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsActive { get; set; }
        public string PhoneNumber { get; set; }
    }
}
