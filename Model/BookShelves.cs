using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class BookShelves
    {
        public int BookShelvesId { get; set; }

        public List<Book> BookList = new List<Book>();
    }
}
