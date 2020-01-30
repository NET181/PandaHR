using System;
using System.Collections.Generic;
using System.Text;

namespace PandaHR.Api.DAL.DTOs.User
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
