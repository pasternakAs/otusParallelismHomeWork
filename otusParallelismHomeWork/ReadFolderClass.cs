using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace otusParallelismHomeWork
{
    public static class ReadFolderClass
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pathFolder"></param>
        /// <returns></returns>
        public static List<string> GetAllFileInFolder(string pathFolder)
        {
            try
            {
                var listPath = new List<string>();

                string[] fileEntries = Directory.GetFiles(pathFolder);

                foreach (var item in fileEntries)
                {
                    listPath.Add(item);
                }

                return listPath;
            }
            catch (Exception)
            {
                return new List<string>();
            }
        }

        /// <summary>
        /// Проверка что путь к папке
        /// </summary>
        /// <param name="pathFolder">путь к папке</param>
        /// <returns></returns>
        public static bool CheckFolder(string pathFolder)
        {
            return Directory.Exists(pathFolder);
        }
    }
}
