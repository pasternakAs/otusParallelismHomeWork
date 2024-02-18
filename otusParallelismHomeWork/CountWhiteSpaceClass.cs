using System.Diagnostics.Metrics;

namespace otusParallelismHomeWork
{
    public static class CountWhiteSpaceClass
    {
        /// <summary>
        /// Подсчет пробелов
        /// </summary>
        /// <param name="str">текст</param>
        /// <returns></returns>
        public static int CountWhiteSpace(string str)
        {
			try
			{
                var countSpaces = str.Count(Char.IsWhiteSpace);
                return countSpaces;
            }
            catch (Exception)
			{
                Console.WriteLine(@"Ошибка полсчета пробелов!");
                return -1;
            }
        }
    }
}
