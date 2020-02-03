using System;

namespace PandaHR.Api.Services.Models.User
{
    public class UserServiceModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
