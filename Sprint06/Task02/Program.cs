using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
//Please, implement class Library with public property Books of generic IEnumerable type that can be set only inside the class,

//    and public property Filter(generic predicate) that sets a condition on book. The default value of Filter: any book satisfies the condition.

//    The constructor of Library class takes 1 parameter for initialization Books property.

//    Implement GetEnumerator method that will allow to enumerate by only those books that satisfy the condition in Filter.

//    Do not use yields in this task.

//    Create  MyEnumerator class that implements IEnumerator<Book>.

//    The constructor of MyEnumerator takes 2 parameters: for initialization books and filter.

//    Implement all the necessary methods and properties in MyEnumerator.

//    Implement MyUtils class with public static method GetFiltered that takes generics IEnumerable and Predicate and returns list of filtered books using Library class and its enumerator.

namespace Task02
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int PageCount { get; set; }
        public Book(string title, string author, int pageCount)
        {
            Title = title;
            Author = author;
            PageCount = pageCount;
        }
    }
    public class Library : IEnumerable<Book>
    {
        public IEnumerable<Book> Books { get; }
        public Predicate<Book> Filter { get; internal set; }
        public Library(IEnumerable<Book> book)
        {
            Books = book;
        }
        public IEnumerator<Book> GetEnumerator()
        {
            return new MyEnumerator(Books, Filter);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    public sealed class MyEnumerator : IEnumerator<Book>
    {
        private List<Book> books;
        private int currentIndex = -1;
        //private Predicate<Book> filter;
        public MyEnumerator(IEnumerable<Book> library, Predicate<Book> filter)
        {
            if (filter != null)
            {
                this.books = new List<Book>(library).FindAll(filter);
            }
            else
            {
                this.books = new List<Book>(library);
            }
            //this.filter = filter;
        }
        public Book Current => books[currentIndex];
        object IEnumerator.Current => Current;
        public void Dispose() { }
        public bool MoveNext() => ++currentIndex < books.Count;
        public void Reset() => currentIndex = -1;
    }
    public class MyUtils
    {
        public static List<Book> GetFiltered(IEnumerable<Book> library, Predicate<Book> predicate)
        {
            var lib = new Library(library) { Filter = predicate };
            List<Book> books = new List<Book>();
            foreach (var item in lib)
            {
                if (predicate(item))
                {
                    books.Add(item);
                }
            }
            return books;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Book[] books = new Book[]
            {
                new Book("A", "A", 10),
                new Book("B", "B", 20),
                new Book("C", "C", 30)
            };
            IEnumerable<Book> library = new List<Book>(books);
            Predicate<Book> predicate = (Book b) => { return b.Author == "A"; };
            var Enumerator = new MyEnumerator(books, predicate);
            while(Enumerator.MoveNext())
            {
                Console.WriteLine(Enumerator.Current.Author + " " + Enumerator.Current.Title + " " + Enumerator.Current.PageCount);
            }
        }
    }
}
