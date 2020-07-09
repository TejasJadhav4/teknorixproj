using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeknorixWebApplication.Models
{
    public class UserModel
    {
        public Decimal UserId { get; set; }

        public string firstname { get; set; }

        public string lastname { get; set; }

        public string email { get; set; }

        public string password { get; set; }

        public string phonecode { get; set; }

        public string phone { get; set; }

        public string city { get; set; }

        public string state { get; set; }

        public string country { get; set; }

        public string code { get; set; }

        public string lstadddress { get; set; }

        public string mode { get; set; }

        public List<UserModel> userlist { get; set; }

    }
}