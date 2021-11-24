using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace animeAppWebApi.Dtos
{
    public record UserDto
    {
        [Key]
        public int userID { get; init; }
        public string username { get; init; }
        public string userEmail { get; init; }
        public string userPassword { get; init; }
        public bool userPremium { get; init; }
        public string userBio { get; init; }
        //public string userLogo { get; set; }
        public string userGender { get; init; }
        public DateTime userDOB { get; init; }
        }

    public record UserSignupDto
    {
        public string username { get; init; }
        public string userEmail { get; init; }
        public string userPassword { get; init; }
    }

    public record UserLoginDto
    {
        public string username { get; init; }
        public string userPassword { get; init; }
    }
}
