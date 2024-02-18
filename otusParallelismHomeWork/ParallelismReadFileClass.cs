using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace otusParallelismHomeWork
{
    //Прочитать 3 файла параллельно и вычислить количество пробелов в них(через Task).
    public class ParallelismReadFileClass
    {
        private readonly Stopwatch _stopWatch;
        private List<string> _pathList = new List<string>();
        private int _allCountWhiteSpace;

        public ParallelismReadFileClass()
        {
            _stopWatch = new Stopwatch();
        }

        public void ReadFileParallelism(List<string> pathList)
        {
            _pathList = pathList;
            RunTask();
        }

        /// <summary>
        /// 
        /// </summary>
        private void RunTask()
        {
            var tasks = new List<Task>();
            _stopWatch.Reset();
            _stopWatch.Start();

            foreach (var item in _pathList)
            {
                tasks.Add(Task.Run(() =>
                {
                    var readText = File.ReadAllText(item);
                    var countWs = CountWhiteSpaceClass.CountWhiteSpace(readText);
                    var nameFile = Path.GetFileName(item);
                    _allCountWhiteSpace += countWs;

                    Console.WriteLine(@"Количество пробелов в файле " + nameFile + " - " + countWs);
                }));
            }

            Task.WaitAll(tasks.ToArray());

            _stopWatch.Stop();

            GetElapsed();
        }

        /// <summary>
        /// 
        /// </summary>
        private void GetElapsed()
        {
            TimeSpan ts = _stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);

            Console.WriteLine(@"Общее количество пробелов - " + _allCountWhiteSpace);
            Console.WriteLine(@"Время выполнения - " + elapsedTime);
        }
    }
}