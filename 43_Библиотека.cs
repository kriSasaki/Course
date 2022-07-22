using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _42_Библиотека
{
    class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();
            bool isActive = true;

            while (isActive)
            {
                Console.WriteLine("Библиотека\n");
                library.ShowAll();
                Console.WriteLine(
                    "\n1 - Добавить книгу" +
                    "\n2 - Убрать книгу" +
                    "\n3 - Найти по параметру" +
                    "\n4 - Выход\n");
                string command = Console.ReadLine();
                Console.Clear();

                switch (command)
                {
                    case "1":
                        library.Add();
                        break;
                    case "2":
                        library.Remove();
                        break;
                    case "3":
                        library.Find();
                        break;
                    case "4":
                        isActive = false;
                        break;
                    default:
                        Console.WriteLine("Такой команды нет, попробуй ещё раз.\n");
                        break;
                }
            }
        }

        class Book
        {
            public string Title { get; private set; }
            public string Author { get; private set; }
            public int YearOfRelease { get; private set; }
            public string Genre { get; private set; }

            public Book(string title, string author, int year, string genre)
            {
                Title = title;
                Author = author;
                YearOfRelease = year;
                Genre = genre;
            }
        }

        class Library
        {
            private List<Book> _books = new List<Book>();

            public void ShowAll()
            {
                Console.WriteLine("Полный список книг: ");

                for (int i = 0; i < _books.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {_books[i].Title}: \"{_books[i].Author}\", {_books[i].YearOfRelease}, {_books[i].Genre}");
                }
            }

            public void Add()
            {
                Console.Write("Введите название книги: ");
                string title = Console.ReadLine();
                Console.Write("Введите автора книги: ");
                string author = Console.ReadLine();
                Console.Write("Введите год издания книги: ");
                int year = ReadInt();
                Console.Write("Введите жанр: ");
                string genre = Console.ReadLine();
                _books.Add(new Book(title, author, year, genre));
                ShowMessage("Книга добавлена.");
            }

            public void Remove()
            {
                Console.Write("Введите номер книги для удаления: ");
                int index = ReadInt() - 1;

                if (index <= _books.Count)
                {
                    _books.RemoveAt(index);
                    Console.WriteLine("Книга удалена.");
                }
                else
                {
                    Console.WriteLine("Такого номера нет в списке.");
                }
            }

            private int ReadInt()
            {
                int result;

                while (int.TryParse(Console.ReadLine(), out result) == false)
                {
                    Console.Write("Неверный ввод числа!\nНеобходимо ввести целое число: ");
                }
                return result;
            }

            public void Find()
            {
                Console.WriteLine("1 - Пооиск по названию" +
                    "\n2 - Поиск по автору" +
                    "\n3 - Поиск по году выпуска" +
                    "\n4 - Поиск по жанру");
                string command = Console.ReadLine();

                switch (command)
                {
                    case "1":
                        FindByTitle();
                        break;
                    case "2":
                        FindByAuthor();
                        break;
                    case "3":
                        FindByYear();
                        break;
                    case "4":
                        FindByGenre();
                        break;
                    default:
                        Console.WriteLine("Выход из поиска.\n");
                        break;
                }
            }

            private void FindByTitle()
            {
                Console.Write("Введите название книги: ");
                string title = Console.ReadLine();
                int index = 0;

                foreach (var book in _books)
                {
                    index++;

                    if (book.Title.ToLower() == title.ToLower())
                    {
                        Console.WriteLine($"{index}. {book.Title}: \"{book.Author}\", {book.YearOfRelease}, {book.Genre}");
                    }
                }
                CheckFinded(index);
                ShowMessage("Конец списка.");
            }
            
            private void FindByAuthor()
            {
                Console.Write("Введите автора книги: ");
                string author = Console.ReadLine();
                int index = 0;

                foreach (var book in _books)
                {
                    index++;

                    if (book.Author.ToLower() == author.ToLower())
                    {
                        Console.WriteLine($"{index}. {book.Title}: \"{book.Author}\", {book.YearOfRelease}, {book.Genre}");
                    }
                }
                CheckFinded(index);
                ShowMessage("Конец списка.");
            }

            private void FindByYear()
            {
                Console.Write("Введите год выпуска: ");
                int year = Convert.ToInt32(Console.ReadLine());
                int index = 0;

                foreach (var book in _books)
                {
                    index++;

                    if (book.YearOfRelease == year)
                    {
                        Console.WriteLine($"{index}. {book.Title}: \"{book.Author}\", {book.YearOfRelease}, {book.Genre}");
                    }
                }
                CheckFinded(index);
                ShowMessage("Конец списка.");
            }

            private void FindByGenre()
            {
                Console.Write("Введите жанр книги: ");
                string genre = Console.ReadLine();
                int index = 0;

                foreach (var book in _books)
                {
                    index++;

                    if (book.Genre.ToLower() == genre.ToLower())
                    {
                        Console.WriteLine($"{index}. {book.Title}: \"{book.Author}\", {book.YearOfRelease}, {book.Genre}");
                    }
                }
                CheckFinded(index);
                ShowMessage("Конец списка.");
            }

            private void ShowMessage(string message)
            {
                Console.WriteLine(message);
                Console.ReadKey();
                Console.Clear();
            }

            private void CheckFinded(int number)
            {
                if (number == 0)
                {
                    Console.Write("Книги не найдены!");
                }
            }
        }
    }
}
