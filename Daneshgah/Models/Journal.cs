using System;
using System.Collections.Generic;

namespace Daneshgah.Models
{
    public class Journal
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Topic { get; set; }

        public long ISBN { get; set; }

        public int PageCount { get; set; }

        public DateTime PublicationYear { get; set; }

        public string Publisher { get; set; }

    }
}
