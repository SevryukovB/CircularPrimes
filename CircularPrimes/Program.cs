using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircularPrimes
{
    class Program
    {
        static void Main(string[] args)
        {
            FindNumber();
            Console.ReadKey();
        }

        public static void FindNumber()
        {            
            //Collection of all simple numbers
            List<int> listAllSimpleNumbers = new List<int>();

            //Collection of all circular prime numbers
            List<int> listCircularSimpleNumbers = new List<int>();

            FindAllSimpleNumbers(1000000, listAllSimpleNumbers);
            FindCircularPrimeNumbers(listAllSimpleNumbers, listCircularSimpleNumbers);
            ShowCircularPrimeNumbers(listCircularSimpleNumbers);



        }
        //Check on simple number
        public static bool isSimple(int n)
        {
            //For check on simple number, need divide this number on numbers up to half of its
            for (int i = 2; i <= (int)(n / 2); i++)
            {
                if (n % i == 0)
                    return false;
            }
            return true;
        }

        //Find all simple numbers and add to list
        public static void FindAllSimpleNumbers(int k, List<int> listAllSimpleNumbers)
        {
            for (int i = 2; i < k; i++)
            {
                if (isSimple(i))
                {
                    listAllSimpleNumbers.Add(i);
                }
            }
        }

        //Find circular prime numbers and add to list 
        public static void FindCircularPrimeNumbers(List<int> listAllSimpleNumbers, List<int> listCircularSimpleNumbers)
        {
            
                foreach (var VARIABLE in listAllSimpleNumbers)
                {
                //For find circular prime i convert int to char[], and changing elements places, and convert back to int
                //This operation is performed until arr.length -1. 123-231-312
                //Need to get first element and write him in end of array, other elements need shift to the left
                //Convertation number to string
                var strNumber = VARIABLE.ToString();
                char[] arr = strNumber.ToCharArray();
                if (arr.Length >= 2)
                {
                    int count = 0;
                    char firstElement = arr[0];
                    for (int i = 1; i < arr.Length; i++)
                    {
                        arr[i - 1] = arr[i];
                        arr[arr.Length - 1] = firstElement;
                        string str = new string(arr);
                        var intNumber = Convert.ToInt32(str);
                        if (isSimple(intNumber))
                        {
                            count++;
                            if (count == arr.Length - 1)
                            {
                                listCircularSimpleNumbers.Add(VARIABLE);
                            }
                        }
                    }
                }
                else
                {
                    listCircularSimpleNumbers.Add(VARIABLE);
                }
            }
        }

        //Show all circular prime numbers
        public static void ShowCircularPrimeNumbers(List<int> listCircularSimpleNumbers)
        {
            foreach (var VARIABLE in listCircularSimpleNumbers)
            {
                Console.WriteLine(VARIABLE.ToString());
            }
        }
    }
}
