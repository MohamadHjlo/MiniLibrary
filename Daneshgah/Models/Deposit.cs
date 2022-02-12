using System;
using System.Collections.Generic;

namespace Daneshgah.Models
{
    public class Deposit
    {
        public int Id { get; set; }

        public DateTime RespiteTime { get; set; }

        public bool IsDelivered { get; set; }

        public int UserId { get; set; }

        public int BookId { get; set; }

        

        public User User { get; set; }

        public Book Book { get; set; }


    }
}
