using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    if (arr[i] < arr[min])
                    {
                        min = j;
                    }
                }
                temp = arr[i];
                arr[i] = arr[min];
                arr[min] = temp;
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
