using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milestone_3
{
    public class Book
    {
        private string bookName;

        public string BookName
        {
            get { return bookName; }
            set { bookName = value; }
        }
        private string authorName;

        public string AuthorName
        {
            get { return authorName; }
            set { authorName = value; }
        }
        private string publisher;
        public string Publisher
        {
            get { return publisher; }
            set { publisher = value; }
        }
        private double price;
        public double Price
        {
            get { return price; }
            set { price = value; }
        }
        private string genre;
        public string Genre
        {
            get { return genre; }
            set { genre = value; }
        }
        private int yearOfPublish;
        public int YearOfPublish
        {
            get { return yearOfPublish; }
            set { yearOfPublish = value; }
        }
        private int quant;

        public int Quant
        {
            get { return quant; }
            set { quant = value; }
        }

        public Book(string bookName, string authorName, string publisher, double price, string genre, int year, int quant)
        {
            this.BookName = bookName;
            this.AuthorName = authorName;
            this.Genre = genre;
            this.Publisher = publisher;
            this.Price = price;
            this.YearOfPublish = year;
            this.Quant = quant;
        }


        public void displayBook()
        {
            Console.WriteLine("Book title: " + BookName);
            Console.WriteLine("Author: " + AuthorName);
            Console.WriteLine("Publisher: " + Publisher);
            Console.WriteLine("Genre: " + Genre);
            Console.WriteLine("Price: " + Price.ToString());
            Console.WriteLine("Year: " + YearOfPublish.ToString());
            Console.WriteLine("Quantity: " + Quant.ToString());
            Console.ReadLine();
        }
        public void changeBookName(string newName)
        {
            BookName = newName;
        }
        public void changeAuthorName(string newName)
        {
            AuthorName = newName;
        }
        public void changePublisher(string newName)
        {
            Publisher = newName;
        }
        public void changePrice(double newPrice)
        {
            Price = newPrice;
        }
        public void changeGenre(string newGenre)
        {
            Genre = newGenre;
        }
        public void changeYear(int newYear)
        {
            YearOfPublish = newYear;
        }

        public void changeQuant(int newquant)
        {
            Quant = newquant;
        }
    }

    public class Warehouse
    {
        public List<Book> Books = new List<Book>();

        public void addBook(Book book)
        {
            this.Books.Add(book);
        }

        public void removeBook(int index)
        {
            this.Books.RemoveAt(index);
        }

        
        public void restockBook(Book book, int quant)
        {
            if (book.Quant == 0)
            {

                book.changeQuant(quant);
            }
            else
            {
                Console.WriteLine("This book does not need to restock");
            }
        }

        public void displayBooks()
        {
            for (int i = 0; i < this.Books.Count; i++)
            {
                Console.Write(i + ". ");
                this.Books[i].displayBook();
            }
        }
        // find book by book name, and gerne
        public Book findBook(string nameBook, string nameGerne)
        {
            Book res = null;
            foreach(Book book in this.Books)
            {
                if (book.BookName == nameBook && book.Genre == nameGerne)
                {
                    res = book; break;
                }

            }
            if (res == null)
            {
                Console.WriteLine("Can not find!!!");
            }
            else
            {
                Console.WriteLine("Successfully");
            }
            return res;
        }


    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Book book1 = new Book("FirstBook", "FirstAuthor", "FirstPubliser", 100, "FirstGenre", 2021, 5);
            Book book2 = new Book("SecondBook", "SecondAuthor", "SecondPublisher", 200, "SecondGenre", 2022, 10);
            Book book3 = new Book("ThirdBook", "ThirdAuthor", "ThirdPublisher", 200, "ThirdGenre", 2022, 20);
            Book book4 = new Book("FourthBook", "FourthAuthor", "FourthPublisher", 400, "FourthGenre", 2022, 40);
            Book book5 = new Book("FifthBook", "FifthAuthor", "FifthPublisher", 500, "FifthGenre", 2022, 50);
            Warehouse warehouse = new Warehouse();
          
            //add books to warehouse
            warehouse.addBook(book1);
            warehouse.addBook(book2);
            warehouse.addBook(book3);
            warehouse.addBook(book4);
            warehouse.addBook(book5);

            //display books in warehouse
            Console.WriteLine("Display books in warehouse");
            warehouse.displayBooks();

            Console.WriteLine("Delete book");
            Console.WriteLine("Input index of book to delete"); //get index

            int index = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Remove book at index " + index.ToString());
            warehouse.removeBook(index); //remove element at input index
            Console.WriteLine("After removing...");
            warehouse.displayBooks(); //display result

            //Restock an item
            warehouse.addBook(book5); //add book5 back to warehouse
            Book book6 = new Book("SixthBook", "SixthAuthor", "SixthPublisher", 600, "SixthGenre", 2022, 0); //add book6 with quantity = 0 to warehouse
            warehouse.addBook(book6);
            Console.WriteLine("Re-stock book6");
            Console.WriteLine("Input number of this book: ");
            int quantity6 = Int32.Parse(Console.ReadLine());
            warehouse.restockBook(book6, quantity6); //re-stock book 6
            Console.WriteLine("Re-stock book5");
            Console.WriteLine("Input number of this book: ");
            int quantity5 = Int32.Parse(Console.ReadLine());
            warehouse.restockBook(book5, quantity5); //re-stock book 5, will show message because book5 does not need to restock
            warehouse.displayBooks(); //display result

            // find book by book name, and gerne
            Console.WriteLine("Input book name: "); 
            string name = Console.ReadLine();
            Console.WriteLine("Input gerne name: ");
            string gerne = Console.ReadLine();

            Book result = warehouse.findBook(name, gerne);
            if (result != null) result.displayBook();


            Console.ReadLine();
        }
    }
}
