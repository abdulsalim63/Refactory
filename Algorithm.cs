using System;
using System.Collections.Generic;
using System.Linq;

namespace refactoryTraining
{
    class Algorithm
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(anagram("hello world", "world hello"));

            int[] arr = { 4, 2, 1, 3, 5 };
            Console.WriteLine(string.Join(",", sort(arr)));
            Console.WriteLine(string.Join(",", reverse(arr)));
            Console.WriteLine(string.Join(",", splice(arr, 3, 6)));

            Console.WriteLine(caesarCipher("I love JavaScript!", -100));

            fizzBuzz(12);

            Console.WriteLine(indexOf(arr, 3));
            Console.WriteLine(lastIndex(arr));
            Console.WriteLine(includes(arr, 2));
            Console.WriteLine(includes(arr, 7));
            Console.WriteLine(string.Join(",",fill(arr, 3)));
            Console.WriteLine(join(arr, "-"));
            Console.WriteLine(sum(arr));

            Console.WriteLine(maxCharacter("Hello World"));
            Console.WriteLine(palindrome("Cigar? Toss it in a can. It is so tragic")); //true
            Console.WriteLine(palindrome("Hello World")); //false

            Console.WriteLine(factorial(0));

            Console.WriteLine(string.Join(" ", bubbleSort(arr)));
            Console.WriteLine(string.Join(" ", insertionSort(arr)));
            Console.WriteLine(string.Join(" ", selectionSort(arr)));

            Console.WriteLine(capitalize("hello world"));
            Console.WriteLine(reverseString("hello world!!!"));
        }

        public static bool anagram(string s1, string s2)
        {
            var s1List = s1.Split(' ').ToList();
            var s2List = s2.Split(' ').ToList();
            foreach (var i in s1List)
            {
                if (s2List.Contains(i) == false)
				{
                    return false;
				}
            }
            return true;
        }

        public static int[] sort(int[] arr)
		{
            Array.Sort(arr);
            return arr;
		}

        public static int[] reverse(int[] arr)
		{
            Array.Reverse(arr);
            return arr;
		}

        public static int[] splice(int[] arr, int index, int element)
		{
            var result = new int[arr.Length + 1];
            bool inside = false;
            for (int i=0;i<result.Length;i++)
			{
                if (i == index)
				{
                    result[i] = element;
                    inside = true;
				}
                else if (inside)
				{
                    result[i] = arr[i - 1];
				}
                else { result[i] = arr[i];  }
			}
            return result;
		}

        public static string caesarCipher(string s1, int shift)
		{
            var alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray().ToList();
            var result = "";
            shift = shift % 26;
            if (shift<0) { shift += 26; }
            foreach (var i in s1)
			{
                if (alphabet.Contains(Char.ToLower(i)))
				{
                    if (i == char.ToLower(i))
					{
                        result += alphabet[(alphabet.IndexOf(i) + shift) % 26];
					}
                    else
					{
                        result += Char.ToUpper(alphabet[(alphabet.IndexOf(Char.ToLower(i)) + shift) % 26]);

                    }
				}
                else { result += i; }
			}
            return result;
		}

        public static void fizzBuzz(int number)
        {
            for (int i=1;i<=30;i++)
            {
                if (i%6 == 0) { Console.WriteLine("Fizz Buzz"); }
                else if (i%2 == 0) { Console.WriteLine("Fizz"); }
                else if (i%3 == 0) { Console.WriteLine("Buzz"); }
                else { Console.WriteLine(i); }
            }
        }

        public static int indexOf(int[] arr, int number)
        {
            return Array.IndexOf(arr, number);
        }

        public static int lastIndex(int[] arr)
        {
            return arr.Length-1;
        }

        public static bool includes(int[] arr, int number)
        {
            return (arr.ToList()).Contains(number);
        }

        public static int[] fill(int[] arr, int number)
        {
            int[] result = Enumerable.Repeat(number, arr.Length).ToArray();
            return result;
        }

        public static string join(int[] arr, string separator)
        {
            return string.Join(separator, arr);
        }

        public static int sum(int[] arr)
        {
            return arr.Sum();
        }

        public static char maxCharacter(string s1)
        {
            var character = new Dictionary<char, int>();
            foreach (var i in s1)
            {
                if (character.ContainsKey(i))
                {
                    var val = character[i];
                    character.Remove(i);
                    character.Add(i, val+1);
                }
                else { character.Add(i, 1); }
            }
            return character.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;
        }

        public static bool palindrome(string s1)
        {
            var alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray().ToList();
            var basis = new List<char>();
            foreach (var i in s1)
            {
                if(alphabet.Contains(Char.ToLower(i)))
                {
                    basis.Add(Char.ToLower(i));
                }
            }
            
            for (int j=0,k=basis.Count()-1;k>=0;j++,k--)
            {
                if (basis[j] != basis[k])
                {
                    return false;
                }
            }
            return true;
        }

        public static int factorial(int n)
        {
            if (n <= 1)
            {
                return 1;
            }
            return n*factorial(n-1);
        }

        public static int[] bubbleSort(int[] arr)
        {
            Array.Sort(arr);
            Array.Reverse(arr);
            return arr;
        }

        public static int[] insertionSort(int[] arr)
        {
            var newArr = new int[arr.Length*2];
            var arrList = arr.ToList();
            for (int i=0;i<newArr.Length;i++)
            {
                if (i%2 == 0)
                {
                    newArr[i] = arrList.Max();
                    arrList.Remove(arrList.Max());
                }
                else
                {
                    newArr[i] = arr[(i-1)/2];
                }
            }
            return newArr;
        }

        public static int[] selectionSort(int[] arr)
        {
            int min = arr.Min();
            arr[Array.IndexOf(arr, min)] = arr[0];
            arr[0] = min;
            return arr;
        }

        public static string capitalize(string s1)
        {
            var split = s1.Split(' ');
            for (int i=0;i<split.Length;i++)
            {
                split[i] = split[i].Substring(0,1).ToUpper() + Convert.ToString(split[i].Substring(1));
            }
            return string.Join(" ", split);
        }

        public static string reverseString(string s1)
        {
            var result = "";
            for (int i=s1.Length-1;i>=0;i--)
            {
                result += s1.Substring(i,1);
            }
            return result;
        }
    }
}