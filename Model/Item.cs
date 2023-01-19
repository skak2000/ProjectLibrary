using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Item
    {
        public string Title { get; set; }
        public string ISBN { get; set; }
        public Location location = new Location();


        public virtual string GetAllValues()
        {
            StringBuilder sb = new StringBuilder();

            Type objType = this.GetType();
            PropertyInfo[] properties = objType.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                sb.AppendLine(property.GetValue(this).ToString());
            }
            return sb.ToString().ToLower();
        }
    }
}
