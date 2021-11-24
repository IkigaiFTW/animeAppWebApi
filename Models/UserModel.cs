using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace animeAppWebApi.Models
{
    public record UserModel
    {
        [Key]
        public int userID { get; init; }
        public string username { get; set; }
        public string userEmail { get; set; }
        public string userPassword { get; set; }
        public bool userPremium { get; set; }
        public string userBio { get; set; }
        //public string userLogo { get; set; }
        public string userGender { get; set; }
        public DateTime userDOB { get; set; }
    }
}
