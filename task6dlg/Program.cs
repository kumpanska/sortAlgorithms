using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace task6dlg
{
    public delegate void SortingMethod(double[] arr);
    class Sort
    { 
        public static void DeveloperShakerSort(double[]arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                double temp;
                bool swap = false;
                for (int j = i; j < arr.Length - 1; j++)
                {
                    if (arr[j + 1] < arr[j])
                    {
                        temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                        swap = true;
                    }
                }
                for (int j = arr.Length - i - 2; j > i; j--)
                {
                    if (arr[j - 1] > arr[j])
                    {
                        temp = arr[j - 1];
                        arr[j - 1] = arr[j];
                        arr[j] = temp;
                        swap = true;
                    }
                }
                if (swap == false)
                { break; }
            }
        }
        public static void DeveloperSelectionSort(double[] arr)
        {
            double temp;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[min])
                    {
                        min = j;
                    }
                }
                temp = arr[i];
                arr[i] = arr[min];
                arr[min] = temp;
            }
        }
        public static void StudentSelectionSort(double[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                int smallestVal = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (arr[j] < arr[smallestVal])
                    {
                        smallestVal = j;
                    }
                }
                double temp = arr[smallestVal];
                arr[smallestVal] = arr[i];
                arr[i] = temp;
            }
        }
        public static void StudentShakerSort(double[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                bool swapped = false;
                double temp;
                for (int j = i; j < arr.Length - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                        swapped = true;
                    }
                }
                for (int j = arr.Length - 1 - i; j > i; j--)
                {
                    if (arr[j - 1] > arr[j])
                    {
                        temp = arr[j - 1];
                        arr[j - 1] = arr[j];
                        arr[j] = temp;
                        swapped = true;
                    }
                }
                if (!swapped)
                {
                    break;
                }
            }
        }
        public static long MeasureSortingTime(SortingMethod sortMethod, double[] arr)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            sortMethod(arr);
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }
        public static bool IsTimeComparable(long teta, long tstud)
        {
            return tstud >= Math.Max(0, teta / 5 - 200) && tstud <= 5 * teta + 200;
        }
        public static bool IsEqualAfterSorting(double[] array1, double[] array2)
        {
            if (array1.Length != array2.Length)
            { return false; }
            for (int i = 0; i < array1.Length; i++)
            {
                if (array1[i] != array2[i])
                { return false; }
            }    
            return true;
        }
        public static void OutputSortedArray(double[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i]+" ");
            }
            Console.WriteLine();
        }
        public static void CheckSortMethods(SortingMethod developerSort, SortingMethod studentSort, double[] arr)
        {
            double[] devArr = (double[])arr.Clone();
            double[] studArr = (double[])arr.Clone();
            long developerSortTime = MeasureSortingTime(developerSort, devArr);
            long studentSortTime = MeasureSortingTime(studentSort, studArr);
            Console.WriteLine($"Time of developer sort method: {developerSortTime} ms");
            OutputSortedArray(devArr);
            Console.WriteLine($"Time of student sort method: {studentSortTime} ms");
            OutputSortedArray(studArr);
            bool isEqualArrays = IsEqualAfterSorting(devArr, studArr);
            bool isTimeComparable = IsTimeComparable(developerSortTime, studentSortTime);
            Console.WriteLine(isTimeComparable && isEqualArrays ?"Algorithm worked correctly": "Algorithm is not correct");
            if (!isTimeComparable)
            { Console.WriteLine("Time is not comparable"); }
            if (!isEqualArrays)
            { Console.WriteLine("Arrays are not equal"); }
           
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] path = Directory.GetFiles("C:\\c#labs\\task6dlg\\task6dlg\\TXT", "*.txt");
            foreach (string filePath in path)
            {
                double[] array = Array.ConvertAll(File.ReadAllText(filePath).Split(' '), Convert.ToDouble);
                Console.WriteLine("Check Selection sort: ");
                Sort.CheckSortMethods(Sort.DeveloperSelectionSort, Sort.StudentSelectionSort, array);
                Console.WriteLine("Check Shaker sort: ");
                Sort.CheckSortMethods(Sort.DeveloperShakerSort, Sort.StudentShakerSort, array);
            }
            
        }
    }
}
