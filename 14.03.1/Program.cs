using System;
using System.Collections.Generic;

namespace Library
{
    namespace Books
    {
        public class Book
        {
            public string Title { get; set; }
            public string Author { get; set; }
            public string Genre { get; set; }
            public bool IsAvailable { get; set; }

            public Book(string title, string author, string genre)
            {
                Title = title;
                Author = author;
                Genre = genre;
                IsAvailable = true;
            }

            public override string ToString()
            {
                return $"{Title} by {Author} ({Genre}) - {(IsAvailable ? "Available" : "Not Available")}";
            }
        }
    }

    namespace Members
    {
        public class Member
        {
            public string Name { get; set; }
            public string MemberId { get; set; }

            public Member(string name, string memberId)
            {
                Name = name;
                MemberId = memberId;
            }

            public override string ToString()
            {
                return $"{Name} (ID: {MemberId})";
            }
        }
    }

    namespace Operations
    {
        public class LibraryOperations
        {
            private List<Books.Book> _books;
            private List<Members.Member> _members;

            public LibraryOperations()
            {
                _books = new List<Books.Book>();
                _members = new List<Members.Member>();
            }

            public void AddBook(string title, string author, string genre)
            {
                _books.Add(new Books.Book(title, author, genre));
                Console.WriteLine("Book added successfully.");
            }

            public void AddMember(string name, string memberId)
            {
                _members.Add(new Members.Member(name, memberId));
                Console.WriteLine("Member added successfully.");
            }

            public void BorrowBook(string memberId, string bookTitle)
            {
                var book = _books.Find(b => b.Title.Equals(bookTitle, StringComparison.OrdinalIgnoreCase));
                var member = _members.Find(m => m.MemberId.Equals(memberId, StringComparison.OrdinalIgnoreCase));

                if (book == null)
                {
                    Console.WriteLine("Book not found.");
                    return;
                }

                if (member == null)
                {
                    Console.WriteLine("Member not found.");
                    return;
                }

                if (!book.IsAvailable)
                {
                    Console.WriteLine("This book is already borrowed.");
                    return;
                }

                book.IsAvailable = false;
                Console.WriteLine($"{member.Name} borrowed {book.Title}.");
            }

            public void ReturnBook(string memberId, string bookTitle)
            {
                var book = _books.Find(b => b.Title.Equals(bookTitle, StringComparison.OrdinalIgnoreCase));
                var member = _members.Find(m => m.MemberId.Equals(memberId, StringComparison.OrdinalIgnoreCase));

                if (book == null)
                {
                    Console.WriteLine("Book not found.");
                    return;
                }

                if (member == null)
                {
                    Console.WriteLine("Member not found.");
                    return;
                }

                if (book.IsAvailable)
                {
                    Console.WriteLine("This book was not borrowed.");
                    return;
                }

                book.IsAvailable = true;
                Console.WriteLine($"{member.Name} returned {book.Title}.");
            }

            public void ListBooks()
            {
                Console.WriteLine("Books in the library:");
                foreach (var book in _books)
                {
                    Console.WriteLine(book);
                }
            }

            public void ListMembers()
            {
                Console.WriteLine("Library Members:");
                foreach (var member in _members)
                {
                    Console.WriteLine(member);
                }
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        var operations = new Library.Operations.LibraryOperations();

        while (true)
        {
            Console.WriteLine("\nLibrary Management");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. Add Member");
            Console.WriteLine("3. Borrow Book");
            Console.WriteLine("4. Return Book");
            Console.WriteLine("5. List Books");
            Console.WriteLine("6. List Members");
            Console.WriteLine("7. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter book title: ");
                    string bookTitle = Console.ReadLine();
                    Console.Write("Enter book author: ");
                    string bookAuthor = Console.ReadLine();
                    Console.Write("Enter book genre: ");
                    string bookGenre = Console.ReadLine();
                    operations.AddBook(bookTitle, bookAuthor, bookGenre);
                    break;

                case "2":
                    Console.Write("Enter member name: ");
                    string memberName = Console.ReadLine();
                    Console.Write("Enter member ID: ");
                    string memberId = Console.ReadLine();
                    operations.AddMember(memberName, memberId);
                    break;

                case "3":
                    Console.Write("Enter member ID: ");
                    string borrowMemberId = Console.ReadLine();
                    Console.Write("Enter book title to borrow: ");
                    string borrowBookTitle = Console.ReadLine();
                    operations.BorrowBook(borrowMemberId, borrowBookTitle);
                    break;

                case "4":
                    Console.Write("Enter member ID: ");
                    string returnMemberId = Console.ReadLine();
                    Console.Write("Enter book title to return: ");
                    string returnBookTitle = Console.ReadLine();
                    operations.ReturnBook(returnMemberId, returnBookTitle);
                    break;

                case "5":
                    operations.ListBooks();
                    break;

                case "6":
                    operations.ListMembers();
                    break;

                case "7":
                    return;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}
