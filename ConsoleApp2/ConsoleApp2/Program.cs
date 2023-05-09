using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            string tableFileName = Console.ReadLine();
            string wordsFileName = Console.ReadLine();

            var matrix = ReadMatrix(tableFileName);
            var list = ReadWords(wordsFileName);

            list = list.Where(x => Contains(matrix, x)).ToList();

            Console.WriteLine(string.Join("\n", list));
        }

        public static bool Contains(char[,] matrix, string word)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string currentWord = "";
                string reversedWord = "";

                //current word
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    currentWord += matrix[i, j];
                }

                //reversed word
                for (int j = matrix.GetLength(1) - 1; j >= 0; j--)
                {
                    reversedWord += matrix[i, j];
                }

                if (currentWord.Contains(word))
                {
                    return true;
                }
                else if (reversedWord.Contains(word))
                {
                    return true;
                }
            }

            return false;
        }

        public static char[,] ReadMatrix(string fileName)
        {
            StreamReader sr1 = new StreamReader(fileName);

            int matrixRows = 0;
            int matrixCols = 0;
            while (!sr1.EndOfStream)
            {
                string line = sr1.ReadLine();
                matrixRows++;
                matrixCols = line.Length;
            }
            sr1.Close();

            try
            {
                StreamReader sr2 = new StreamReader(fileName);
                char[,] matrix = new char[matrixRows, matrixCols];

                while (!sr2.EndOfStream)
                {
                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        string line = sr2.ReadLine();

                        for (int j = 0; j < matrix.GetLength(1); j++)
                        {
                            matrix[i, j] = line[j];
                        }
                    }
                }

                return matrix;
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
        }

        public static List<string> ReadWords(string fileName)
        {
            List<string> list = new List<string>();

            try
            {
                StreamReader sr = new StreamReader(fileName);

                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();

                    list.Add(line);
                }

                return list;
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }

        }
    }
}
