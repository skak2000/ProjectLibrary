using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Media : Item
    {
        public string MediaType { get; set; }
        public List<Track> Tracks = new List<Track>();

        public override string GetAllValues()
        {
            StringBuilder sb = new StringBuilder();
            string values = base.GetAllValues();

            foreach (Track item in Tracks)
            {
                sb.AppendLine(item.Title);
                sb.AppendLine(item.Duration.ToString());
                sb.AppendLine(item.Artist);
            }
            sb.AppendLine(values);
            string respont = sb.ToString();
            return respont;
        }
    }
}
