using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotnetWeek2HwTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine(Find(new int[] { 206847684, 1056521, 7, 17, 1901, 21104421, 7, 1, 35521, 1, 7781 }));
            // string myString = "";
            /*   Console.WriteLine(myString.score());
               List<int[]> peopleList = new List<int[]>() { new[] { 3, 0 }, new[] { 9, 1 }, new[] { 4, 8 }, new[] { 12, 2 }, new[] { 6, 1 }, new[] { 7, 8 } };
               Console.WriteLine(Number(peopleList));*/
            // Console.WriteLine(GetMiddle("middle"));
            // var x = Alternate(5, true, false);
            // Console.WriteLine(string.Join(',',x)); ;
            //
            // Console.WriteLine(     CreatePhoneNumber(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 }));
            // var x = UniqueInOrder("AAAABBBCCDAABBB");
            Console.WriteLine(CountBits(10));

        }

        public static int Find(int[] integers)
        {
            int oddCount = 0, evenCount = 0;
            for (int i = 0; i < 3; i++)
            {
                if (integers[i] % 2 == 0)
                {
                    ++evenCount;
                }
                else
                {
                    ++oddCount;
                }
            }

   
            return (evenCount > oddCount ? getOutlier(integers, false) : getOutlier(integers, true));
        }

        private static int getOutlier(int[] integers, bool even)
        {
            int outlier = 0;
            for (int i = 0; i < integers.Length; i++)
            {
                if (even)
                {
                    if (integers[i] % 2 == 0)
                    {
                        outlier = integers[i];
                        break;
                    }
                }
                else
                {
                    if (integers[i] % 2 != 0)
                    {
                        outlier = integers[i];
                        break;
                    }
                }

            }
            return outlier;
        }

        public static string Likes(string[] name)
        {
            string statement = "";
            switch (name.Length)
            {
                case 0:
                    {
                        statement = "no one likes this";
                        break;
                    }
                case 1:
                    {
                        statement = $"{name[0]}likes this";
                        break;
                    }
                case 2:
                    {
                        statement = $"{name[0]} and {name[1]} like this";
                        break;
                    }
                case 3:
                    {
                        statement = $"{name[0]} , {name[1]}  and {name[2]} like this";
                        break;
                    }
                default:
                    {
                        statement = $"{name[0]} , {name[1]}  and {name.Length - 2} others like this";

                        break;
                    }
            }

            return statement;
        }


        public static int Number(List<int[]> peopleListInOut)
        {


            /*int peopleCountInBus = 0;
            foreach(var item in peopleListInOut)
            {
                peopleCountInBus += item[0] - item[1];
            }

            return peopleCountInBus;*/
            return peopleListInOut.Sum(x => x[0] - x[1]);


        }

        public static string GetMiddle(string s)
        {
            /* char[] letters = s.ToCharArray();
             int indexMiddle = (int)(letters.Length / 2);
             return letters.Length % 2 != 0 ? letters[indexMiddle].ToString()
                 : letters[indexMiddle - 1].ToString() + letters[indexMiddle].ToString();*/
            return s.Substring(s.Length / 2 - 1, 2 - s.Length % 2);
        }

        public static object[] Alternate(int n, object firstValue, object secondValue)
        {
            /* object[] array = new object[n];
             bool flagForFirstValue = true;
             for(int i=0;i<n;i++)
             {
                 if(flagForFirstValue)
                 { array[i] = firstValue;
                    flagForFirstValue = false;
                 }
                 else
                 {
                     array[i] = secondValue;
                     flagForFirstValue = true; 

                 }
             }

             return array;*/

            return Enumerable.Range(0, n).Select(x => x % 2 == 1 ? secondValue : firstValue).ToArray();
        }

        public static string CreatePhoneNumber(int[] numbers)
        {
            var phNo = new StringBuilder("(",100) ;

            for (int i=0;i<10;i++)
            {
                phNo.Append(numbers[i].ToString());
                if (i==2)
                { 
                    phNo.Append(") ");
                }
                else if (i == 5 ) 
                {
                  
                    phNo.Append("-");
                }
               
            }
            return phNo.ToString();
        }

        public static IEnumerable<T> UniqueInOrder<T>(IEnumerable<T> iterable)
        {
            //var result = new List<T>();

            //foreach(T item in iterable)
            //{
            //    if(result.Count==0 || !result.Last().Equals(item))
            //    {
            //        result.Add(item);
            //    }

            //}
            //return result;

            T previous = default(T);
            foreach(var current in iterable)
            {
                if (!current.Equals(previous))
                {
                    previous = current;
                    yield return current;
                }
                    
            }
        }

        public static int CountBits(int n)
        {

            List<int> binary = new();
            while(n>0)
            {
                binary.Add(n % 2);
                n = n / 2;
            }
            return binary.FindAll(x => x == 1).Count();
           
        }
    }

}
