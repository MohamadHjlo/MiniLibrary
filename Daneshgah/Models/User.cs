using System;
using System.Collections.Generic;

namespace Daneshgah.Models
{
    public class User
    {
        public int Id { get; set; }

        public bool IsAdmin { get; set; }

        public string Name { get; set; }

        public string Family { get; set; }

        public string Password { get; set; }

        public int BirthDate { get; set; }

        public string Email { get; set; }

        public DateTime RegisterDate { get; set; }

        public List<Deposit> AmanatHa { get; set; }
    }
}
