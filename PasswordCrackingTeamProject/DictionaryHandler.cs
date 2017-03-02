using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordCrackingTeamProject
{
    class DictionaryHandler
    {
        public static List<string> ReadDictionary(String filename)
        {
            List<string> result = new List<string>();

            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
            using (StreamReader sr = new StreamReader(fs))
            {
                while (!sr.EndOfStream)
                {
                    result.Add(sr.ReadLine()); 
                }
                return result;
            }
        }
    }
}
