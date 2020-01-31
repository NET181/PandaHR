using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.Services.Models.User
{
    public class UserCreationServiceModel
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
