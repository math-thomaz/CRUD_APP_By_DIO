using System;

namespace DIO.Series
{
    class Program
    {
        static SeriesRepository repository = new SeriesRepository();
        static void Main(string[] args)
        {
            string userOption = GetUserOption();

            while (userOption.ToUpper() != "X") {
                switch (userOption) {
                    case "1":
                        ListAllSeries();
                        break;
                    case "2":
                        AddNewSeries();
                        break;
                    case "3":
                        UpdateSelectedSeries();
                        break;
                    case "4":
                        RemoveSelectedSeries();
                        break;
                    case "5":
                        PreviewSelectedSeries();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                userOption = GetUserOption();
            }

            Console.WriteLine("Thank you for support our services!");
            Console.ReadLine();
        }

        private static void ListAllSeries()
        {
            Console.WriteLine("List All Series");

            var list = repository.ListSeries();

            if (list.Count == 0) {
                Console.WriteLine("There is no series registered, yet.");
                return;
            }
            foreach (var series in list) {
                var removed = series.returnRemovedItem();
                Console.WriteLine("#ID {0}: - {1} - {2}", series.returnId(),
                series.returnTitle(),
                (removed ? "Removed" : "Available")
                );
            }
        }

        private static void AddNewSeries()
        {
            Console.WriteLine("Insert a New Series");

            foreach (int i in Enum.GetValues(typeof(Genre))) {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genre), i));
            }
            Console.Write("Type the corresponding genre number between the options above: ");
            int genreEntry = int.Parse(Console.ReadLine());

            Console.Write("Insert the Series Title: ");
            string titleEntry = Console.ReadLine();

            Console.Write("Insert the Series Release Date (Year): ");
            int releaseYearDateEntry = int.Parse(Console.ReadLine());

            Console.Write("Insert a description for it Series: ");
            string descriptionEntry = Console.ReadLine();

            Series newSeries = new Series(id: repository.NextId(),
                genre: (Genre)genreEntry,
                title: titleEntry,
                releaseYear: releaseYearDateEntry,
                description: descriptionEntry);

            repository.AddSeries(newSeries);
        }

        private static void UpdateSelectedSeries()
        {
            Console.Write("Insert the Series Id: ");
            int seriesIndex = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genre))) {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genre), i));
            }
            Console.Write("Type the corresponding genre number between the options above: ");
            int genreEntry = int.Parse(Console.ReadLine());

            Console.Write("Insert the Series Title: ");
            string titleEntry = Console.ReadLine();

            Console.Write("Insert the Series Release Date (Year): ");
            int releaseYearDateEntry = int.Parse(Console.ReadLine());

            Console.Write("Insert a description for it Series: ");
            string descriptionEntry = Console.ReadLine();

            Series updatedSeries = new Series(id: seriesIndex,
                genre: (Genre)genreEntry,
                title: titleEntry,
                releaseYear: releaseYearDateEntry,
                description: descriptionEntry);

            repository.UpdateSeries(seriesIndex, updatedSeries);
        }

        private static void RemoveSelectedSeries()
        {
            Console.Write("Insert the Series Id: ");
            int seriesIndex = int.Parse(Console.ReadLine());

            repository.RemoveSeries(seriesIndex);
        }
        private static void PreviewSelectedSeries()
        {
            Console.Write("Insert the Series Id: ");
            int seriesIndex = int.Parse(Console.ReadLine());

            var series = repository.ReturnSeriesById(seriesIndex);

            Console.WriteLine(series);
        }

        private static string GetUserOption()
        {
            Console.WriteLine();
            Console.WriteLine("TSD - The Series Database");
            Console.WriteLine("Please choose the options below:");

            Console.WriteLine("1 - List All Series");
            Console.WriteLine("2 - Add New Series");
            Console.WriteLine("3 - Update Series");
            Console.WriteLine("4 - Remove Series");
            Console.WriteLine("5 - Preview Series");
            Console.WriteLine("C - Clear Screen");
            Console.WriteLine("X - Exit");
            Console.WriteLine();

            string userOption = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return userOption;
        }
    }
}
