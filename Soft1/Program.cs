using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Mime;

namespace Soft1
{
    internal class Program
    {

        public static void Main(string[] args)
        {

            int nummas;
            string path = String.Empty;
            Console.WriteLine("1 маленький массив 2 и прочии цифры большой массив");
            nummas = Convert.ToInt32(Console.ReadLine());
            switch (nummas)
            {
                case 1:
                    path = "f1.txt";
                    break;
                default:
                    path = "f2.txt";
                    break;

            }
            #region Запись из файл в массив

            int[][] list = File.ReadAllLines(path)
                   .Select(l => l.Split(' ').Select(i => int.Parse(i)).ToArray())
                   .ToArray();
            #endregion

            #region Запись в двумерный массив
            int[,] arrayInts = new int[list.Length, list.Length];


            for (int i = 0; i < list.Length; i++)
            {
                for (int j = 0; j < list.Length; j++)
                {
                    try
                    {
                        arrayInts[i, j] = list[i][j];
                    }
                    catch (Exception)
                    {
                    }
                }

            }
            #endregion


            for (int i = list.Length - 2; i >= 0; i--)
            {
                for (int j = 0; j < list.Length - 1; j++)
                {
                    arrayInts[i, j] = Math.Max(arrayInts[i, j] + arrayInts[i + 1, j], arrayInts[i, j] + arrayInts[i + 1, j + 1]);
                }
            }
            Console.WriteLine("Maximum sum: {0}", arrayInts[0, 0]);

            Console.ReadKey();



        }
    }
}


