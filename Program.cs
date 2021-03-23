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
            int id;

            Console.WriteLine("View series");

            Console.Write("Enter the series id: ");
                
            if (!(int.TryParse(Console.ReadLine(), out id) && id < repository.NextId()))
            {
                Console.WriteLine();
                Console.WriteLine("- Invalid id, try again.");
                return;
            }

            Console.WriteLine();
            Console.WriteLine(repository.ReturnById(id));
        }

        private static void DeleteSerie()
        {
            int id;

            Console.WriteLine("Delete series");

            Console.Write("Enter the series id: ");
                
            if (!(int.TryParse(Console.ReadLine(), out id) && id < repository.NextId()))
            {
                Console.WriteLine();
                Console.WriteLine("- Invalid id, try again.");
                return;
            }

            repository.Delete(id);
        }

        private static void UpdateSerie()
        {
            int id, genre, year;

            Console.WriteLine("Update series");

            Console.Write("Enter the series id: ");
                
            if (!(int.TryParse(Console.ReadLine(), out id) && id < repository.NextId()))
            {
                Console.WriteLine();
                Console.WriteLine("- Invalid id, try again.");
                return;
            }

            do
            {
                foreach (int i in Enum.GetValues(typeof(Genre)))
                {
                    Console.WriteLine($"{i} - {Enum.GetName(typeof(Genre), i)}");
                }

                Console.Write("Enter the genre between the options above: ");

                if (int.TryParse(Console.ReadLine(), out genre) && Enum.IsDefined(typeof(Genre), genre))
                {
                    break;
                }

                Console.WriteLine();
                Console.WriteLine("- Invalid option, try again.");

            } while(true);

            Console.Write("Enter the series title: ");
            string title = Console.ReadLine();

            do
            {
                Console.Write("Enter the series release year: ");
                
                if (int.TryParse(Console.ReadLine(), out year))
                {
                    break;
                }

                Console.WriteLine();
                Console.WriteLine("- Invalid year, try again.");

            } while(true);

            Console.Write("Enter the series description: ");
            string description = Console.ReadLine();

            Serie updatedSerie = new Serie(id: id,
                                        genre: (Genre)genre,
                                        title: title,
                                        year: year,
                                        description: description);

            repository.Update(id, updatedSerie);
        }

        private static void InsertSerie()
        {
            int genre, year;

            Console.WriteLine("Insert new series");

            do
            {
                foreach (int i in Enum.GetValues(typeof(Genre)))
                {
                    Console.WriteLine($"{i} - {Enum.GetName(typeof(Genre), i)}");
                }

                Console.Write("Enter the genre between the options above: ");

                if (int.TryParse(Console.ReadLine(), out genre) && Enum.IsDefined(typeof(Genre), genre))
                {
                    break;
                }

                Console.WriteLine("Invalid option, try again.");

            } while(true);

            Console.Write("Enter the series title: ");
            string title = Console.ReadLine();

            do
            {
                Console.Write("Enter the series release year: ");
                
                if (int.TryParse(Console.ReadLine(), out year))
                {
                    break;
                }

                Console.WriteLine("Invalid year, try again.");

            } while(true);

            Console.Write("Enter the series description: ");
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
                Console.WriteLine($"#ID {serie.Id}: - {serie.Title} {(serie.IsDeleted ? "*Deleted*" : "")}");
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
