using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using tyuiu.cources.programming.interfaces.Sprint5;
namespace Tyuiu.FominIN.Sprint5.TaskReview.V25.Lib
{
    public class DataService : ISprint5Task7V25
    {
        public string LoadDataAndSave(string path)
        {
            string inputFile = @"C:\DataSprint5\InPutDataFileTask7V25.txt";
            string outputFile = @"C:\DataSprint5\OutPutDataFileTask7V25.txt";

            string[] lines = File.ReadAllLines(inputFile);
            StringBuilder newData = new StringBuilder();

            foreach (var line in lines)
            {
                string[] words = line.Split(' ');

                foreach (var word in words)
                {
                    bool containsEnglishCharacters = ContainsEnglishCharacters(word);

                    if (!containsEnglishCharacters)
                    {
                        newData.Append(word + " ");
                    }
                    else
                    {
                        foreach (char c in word)
                        {
                            if (!((c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z')))
                            {
                                newData.Append(c);
                            }
                        }
                        newData.Append("");
                    }
                }
                newData.AppendLine();
            }

            File.WriteAllText(outputFile, newData.ToString());
            return outputFile;
        }

        private bool ContainsEnglishCharacters(string word)
        {
            foreach (char c in word)
            {
                if ((c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z'))
                {
                    return true;
                }
            }
            return false;
        }

    }
}
