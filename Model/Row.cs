using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Row
    {
        public int RowId { get; set; }
        public List<BookShelves> BookShelvesList = new List<BookShelves>();          
    }
}