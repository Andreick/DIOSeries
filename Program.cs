using System;
using Classes;
using Enums;

namespace DIOSeries
{
    class Program
    {
        static SerieRepository repository = new SerieRepository();
        static void Main(string[] args)
        {
            Console.WriteLine("DIO Series at your service!");

            string userOption = GetUserOption();

            while (userOption != "X")
            {
                switch (userOption)
                {
                    case "1":
                        ListSeries();
                        break;
                    case "2":
                        InsertSerie();
                        break;
                    case "3":
                        UpdateSerie();
                        break;
                    case "4":
                        DeleteSerie();
                        break;
                    case "5":
                        ViewSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                userOption = GetUserOption();
            }

            Console.WriteLine("Thank you for using our services.");
        }

        private static void ViewSerie()
        {
            throw new NotImplementedException();
        }

        private static void DeleteSerie()
        {
            throw new NotImplementedException();
        }

        private static void UpdateSerie()
        {
            throw new NotImplementedException();
        }

        private static void InsertSerie()
        {
            Console.WriteLine("Insert new series");

            int genre, year;

            do
            {
                foreach (int i in Enum.GetValues(typeof(Genre)))
                {
                    Console.WriteLine($"{i} - {Enum.GetName(typeof(Genre), i)}");
                }

                Console.WriteLine("Enter the genre between the options above: ");

                if (int.TryParse(Console.ReadLine(), out genre) && Enum.IsDefined(typeof(Genre), genre))
                {
                    break;
                }

                Console.WriteLine("Invalid option, try again.");

            } while(true);

            Console.WriteLine("Enter the series title");
            string title = Console.ReadLine();

            do
            {
                Console.WriteLine("Enter the series release year");
                
                if (int.TryParse(Console.ReadLine(), out year))
                {
                    break;
                }

                Console.WriteLine("Invalid year, try again.");

            } while(true);

            Console.WriteLine("Enter the series description: ");
            string description = Console.ReadLine();

            Serie newSerie = new Serie(id: repository.NextId(),
                                        genre: (Genre)genre,
                                        title: title,
                                        year: year,
                                        description: description);

            repository.Insert(newSerie);
        }

        private static void ListSeries()
        {
            Console.WriteLine("List series");

            var list = repository.List();

            if (list.Count == 0)
            {
                Console.WriteLine("No series registered.");
                return;
            }

            foreach (var serie in list)
            {
                Console.WriteLine($"#ID {serie.Id}: - {serie.Title}");
            }
        }

        private static string GetUserOption()
        {
            Console.WriteLine();
            Console.WriteLine("Enter the desired option:");

            Console.WriteLine("1 - List series");
            Console.WriteLine("2 - Insert series");
            Console.WriteLine("3 - Update series");
            Console.WriteLine("4 - Delete series");
            Console.WriteLine("5 - View series");
            Console.WriteLine("C - Clear window");
            Console.WriteLine("X - Exit");
            Console.WriteLine();

            Console.Write("Option: ");
            string userOption = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return userOption;
        }
    }
}
