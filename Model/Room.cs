using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Room
    {
        public int RoomId { get; set; }
        public List<Row> Rows = new List<Row>();
    }
}
