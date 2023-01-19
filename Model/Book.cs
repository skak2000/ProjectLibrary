using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Book : Item
    {
        public Book()
        {
            Authors = new List<string>();
            ISBN = String.Empty;
        }

        public List<string> Authors { get; set; }
        public string Publisher { get; set; }
        public int PublicationYear { get; set; }
        public int NumberOfPages { get; set; }

        public override string GetAllValues()
        {
            StringBuilder sb = new StringBuilder();
            string values = base.GetAllValues();

            foreach (string item in Authors)
            {
                sb.AppendLine(item);
            }
            sb.AppendLine(values);
            string respont = sb.ToString().ToLower();
            return respont;
        }
    }
}
