using System.Diagnostics.Metrics;

namespace otusParallelismHomeWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Старт!");

            var listPath = new List<string>
            {
                Path.GetFullPath(@"Documents\\Test1.txt"),
                Path.GetFullPath(@"Documents\\Test2.txt"),
                Path.GetFullPath(@"Documents\\Test3.txt")
            };

            var parallelismClass = new ParallelismReadFileClass();
            parallelismClass.ReadFileParallelism(listPath);

            Console.WriteLine("Для продолжения нажмите любую клавишу..");
            Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Введите путь до папки с файлами: ");
            //C:\Users\pasternaka\Desktop\тексты
            string path = Console.ReadLine();

            if(!ReadFolderClass.CheckFolder(path))
            {
                Console.WriteLine("Это не папка!");
                return;
            }

            var listPathInFolder = ReadFolderClass.GetAllFileInFolder(path);
            parallelismClass.ReadFileParallelism(listPathInFolder);

            Console.ReadLine();
        }
    }
}
