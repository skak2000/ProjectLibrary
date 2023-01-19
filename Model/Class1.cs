using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Book
    {
        public List<string> Authors = new List<string>();
        public string Publisher { get; set; }
        public int PublicationYear { get; set; }
        public int NumberOfPages { get; set; }
    }
}
