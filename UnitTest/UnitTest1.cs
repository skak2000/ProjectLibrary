using BuisnessLogicLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod()
        {
            BuisnessController bc = new BuisnessController();
            string text = File.ReadAllText(@"Test.txt");

            List<Book> respont = bc.ReadBooks(text);
            bc.FindBooks("*20*&*Jensen*");

            List<Book> result = bc.FindBooks("*20*");

            // Assert
            Assert.IsTrue(result.Any(b => b.Title == "Texts from Denmark"));
            Assert.IsTrue(result.Any(b => b.Authors.Contains("Brian Jensen")));
            Assert.IsTrue(result.Any(b => b.Publisher == "Gyldendal"));
            Assert.IsTrue(result.Any(b => b.PublicationYear == 2001));
            Assert.IsTrue(result.Any(b => b.NumberOfPages == 253));
        }

        [TestMethod]
        public void TestMethod2()
        {
            BuisnessController bc = new BuisnessController();
            string text = File.ReadAllText(@"Test.txt");
            List<Book> respont = bc.ReadBooks(text);
            var result = bc.FindBooks("*20*&*peter*");

            // Assert
            Assert.IsTrue(result.Any(b => b.Title == "Stories from abroad"));
            Assert.IsTrue(result.Any(b => b.Authors.Contains("Peter Jensen")));
            Assert.IsTrue(result.Any(b => b.PublicationYear == 2012));
            Assert.IsTrue(result.Any(b => b.NumberOfPages == 156));
            Assert.AreEqual(1, result.Count());
        }

        [TestMethod]
        public void TestMethod3()
        {
            List<Room> rooms = CreateTestData();
                        
            Book searchResult = rooms
                .SelectMany(r => r.Rows)
                .SelectMany(r => r.BookShelvesList)
                .SelectMany(b => b.BookList)
                .FirstOrDefault(b => b.ISBN == "2525");

            Assert.IsTrue(searchResult.ISBN == "2525");
        }

        public List<Room> CreateTestData()
        {
            List<Room> rooms = new List<Room>();

            BuisnessController bc = new BuisnessController();

            string text = File.ReadAllText(@"Test.txt");
            List<Book> respont = bc.ReadBooks(text);

            BookShelves bs = new BookShelves();
            bs.BookShelvesId = 100;
            bs.BookList.Add(respont.FirstOrDefault());

            Row row = new Row();
            row.RowId = 5;
            row.BookShelvesList.Add(bs);

            Room room = new Room();
            room.RoomId = 1;
            room.Rows.Add(row);
            rooms.Add(room);

            //
            bs = new BookShelves();
            bs.BookShelvesId = 200;
            bs.BookList.Add(respont.LastOrDefault());

            row = new Row();
            row.RowId = 6;
            row.BookShelvesList.Add(bs);

            room = new Room();
            room.RoomId = 2;
            room.Rows.Add(row);
            rooms.Add(room);

            return rooms;
        }
    }    
}
