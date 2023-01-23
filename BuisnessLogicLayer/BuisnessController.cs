using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogicLayer
{
    public class BuisnessController
    {
        List<Book> bookList = new List<Book>();

        public List<Book> ReadBooks(string input)
        {
            Book temp = new Book();
             string[] lines = input.Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

            foreach (string line in lines)
            {
                string[] linesTemp = line.Split(':');
                                        
                if (linesTemp.Length < 1)
                {
                    continue;
                }

                string key = linesTemp[0].Trim();
                int numberValue = 0;
                string value = string.Empty;

                if (linesTemp.Length > 1)
                {
                    value = linesTemp[1].Trim();
                }               

                if (key == "Book")
                {
                    temp = new Book();
                    bookList.Add(temp);
                }
                else if (key == "Author")
                {
                    temp.Authors.Add(value);
                }
                else if (key == "Title")
                {
                    temp.Title = value;
                }
                else if (key == "Publisher")
                {
                    temp.Publisher = value;
                }
                else if (key == "Published")
                {                    
                    int.TryParse(value, out numberValue);
                    temp.PublicationYear = numberValue;
                }
                else if (key == "NumberOfPages")
                {
                    int.TryParse(value, out numberValue);
                    temp.NumberOfPages = numberValue;
                }
                else if (key == "ISBN")
                {                    
                    temp.ISBN = value;
                }
            }

            return bookList;
        }

        public List<Book> FindBooks(string searchString)
        {
            List<Book> respont = bookList.ToList();
            string[] query = searchString.ToLower().Split('&');

            foreach (string search in query)
            {
                if (search.StartsWith("*") && search.EndsWith("*"))
                {
                    string searchKey = search.Substring(1, search.Length - 2);
                    respont = respont.Where(x => x.GetAllValues().Contains(searchKey)).ToList();    
                }
            }
            return respont;
        }

        public Item GetItemByISBN(string isbn)
        {
            return bookList.FirstOrDefault(x => x.ISBN.Contains(isbn));
        }
    }
}
