using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Milestone_3;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        Book first_book = new Book("FirstBook", "FirstAuthor", "FirstPublisher", 100, "FirstGenre", 2021, 1);
        Book second_book = new Book("SecondBook", "SecondAuthor", "SecondPublisher", 200, "SecondGenre", 2022, 2);
        Book third_book = new Book("ThirdBook", "ThirdAuthor", "ThirdPublisher", 300, "ThirdGenre", 2020, 3);
        Warehouse warehouse = new Warehouse();


        [TestMethod]
        //test add books to warehouse
        public void FirstTest()
        {

            warehouse.addBook(first_book);
            warehouse.addBook(second_book);
            warehouse.addBook(third_book);
            Assert.AreEqual("FirstBook", warehouse.Books[0].BookName);
            Assert.AreEqual("FirstAuthor", warehouse.Books[0].AuthorName);
            Assert.AreEqual("FirstPublisher", warehouse.Books[0].Publisher);
            Assert.AreEqual(100, warehouse.Books[0].Price);
            Assert.AreEqual("FirstGenre", warehouse.Books[0].Genre);
            Assert.AreEqual(2021, warehouse.Books[0].YearOfPublish);
            Assert.AreEqual(1, warehouse.Books[0].Quant);

            Assert.AreEqual("SecondBook", warehouse.Books[1].BookName);
            Assert.AreEqual("SecondAuthor", warehouse.Books[1].AuthorName);
            Assert.AreEqual("SecondPublisher", warehouse.Books[1].Publisher);
            Assert.AreEqual(200, warehouse.Books[1].Price);
            Assert.AreEqual("SecondGenre", warehouse.Books[1].Genre);
            Assert.AreEqual(2022, warehouse.Books[1].YearOfPublish);
            Assert.AreEqual(2, warehouse.Books[1].Quant);

            Assert.AreEqual("ThirdBook", warehouse.Books[2].BookName);
            Assert.AreEqual("ThirdAuthor", warehouse.Books[2].AuthorName);
            Assert.AreEqual("ThirdPublisher", warehouse.Books[2].Publisher);
            Assert.AreEqual(300, warehouse.Books[2].Price);
            Assert.AreEqual("ThirdGenre", warehouse.Books[2].Genre);
            Assert.AreEqual(2020, warehouse.Books[2].YearOfPublish);
            Assert.AreEqual(3, warehouse.Books[2].Quant);

        }

        [TestMethod]
        //test re-stock books
        public void SecondTest()
        {
            Book fourth_book = new Book("FourthBook", "FourthAuthor", "FourthPublisher", 400, "FourthGenre", 2021, 0);
            warehouse.addBook(first_book);
            warehouse.addBook(second_book);
            warehouse.addBook(third_book);
            warehouse.addBook(fourth_book);
            Assert.AreEqual("FourthBook", warehouse.Books[3].BookName);
            Assert.AreEqual("FourthAuthor", warehouse.Books[3].AuthorName);
            Assert.AreEqual("FourthPublisher", warehouse.Books[3].Publisher);
            Assert.AreEqual(400, warehouse.Books[3].Price);
            Assert.AreEqual("FourthGenre", warehouse.Books[3].Genre);
            Assert.AreEqual(2021, warehouse.Books[3].YearOfPublish);
            Assert.AreEqual(0, warehouse.Books[3].Quant);

            warehouse.restockBook(fourth_book, 10);
            Assert.AreEqual(10, warehouse.Books[3].Quant);

        }


        [TestMethod]
        //test delete book
        public void ThirdTest()
        {
            Book fourth_book = new Book("FourthBook", "FourthAuthor", "FourthPublisher", 400, "FourthGenre", 2021, 0);
            warehouse.addBook(first_book);
            warehouse.addBook(second_book);
            warehouse.addBook(third_book);
            warehouse.addBook(fourth_book);
            Assert.AreEqual(4, warehouse.Books.Count);

            warehouse.removeBook(0);//remove first book

            Assert.AreEqual(3, warehouse.Books.Count);

            Assert.AreEqual("SecondBook", warehouse.Books[0].BookName);
            Assert.AreEqual("SecondAuthor", warehouse.Books[0].AuthorName);
            Assert.AreEqual("SecondPublisher", warehouse.Books[0].Publisher);
            Assert.AreEqual(200, warehouse.Books[0].Price);
            Assert.AreEqual("SecondGenre", warehouse.Books[0].Genre);
            Assert.AreEqual(2022, warehouse.Books[0].YearOfPublish);
            Assert.AreEqual(2, warehouse.Books[0].Quant);

            Assert.AreEqual("ThirdBook", warehouse.Books[1].BookName);
            Assert.AreEqual("ThirdAuthor", warehouse.Books[1].AuthorName);
            Assert.AreEqual("ThirdPublisher", warehouse.Books[1].Publisher);
            Assert.AreEqual(300, warehouse.Books[1].Price);
            Assert.AreEqual("ThirdGenre", warehouse.Books[1].Genre);
            Assert.AreEqual(2020, warehouse.Books[1].YearOfPublish);
            Assert.AreEqual(3, warehouse.Books[1].Quant);

            Assert.AreEqual("FourthBook", warehouse.Books[2].BookName);
            Assert.AreEqual("FourthAuthor", warehouse.Books[2].AuthorName);
            Assert.AreEqual("FourthPublisher", warehouse.Books[2].Publisher);
            Assert.AreEqual(400, warehouse.Books[2].Price);
            Assert.AreEqual("FourthGenre", warehouse.Books[2].Genre);
            Assert.AreEqual(2021, warehouse.Books[2].YearOfPublish);
            Assert.AreEqual(0, warehouse.Books[2].Quant);

        }

        [TestMethod]
        //test find book by name and gerne
        public void FourthTest()
        {
            warehouse.addBook(first_book);
            warehouse.addBook(second_book);
            warehouse.addBook(third_book);
            Book res = warehouse.findBook("FirstBook", "FirstGenre");
            Assert.IsNotNull(res);
            Assert.AreEqual("FirstBook", res.BookName);
            Assert.AreEqual("FirstAuthor", res.AuthorName);
            Assert.AreEqual("FirstPublisher", res.Publisher);
            Assert.AreEqual(100, res.Price);
            Assert.AreEqual("FirstGenre", res.Genre);
            Assert.AreEqual(2021, res.YearOfPublish);
            Assert.AreEqual(1, res.Quant);

            Book second_res = warehouse.findBook("NotBook", "NotGerne");
            Assert.IsNull(second_res);
        }
    }
}
