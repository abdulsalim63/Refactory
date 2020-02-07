using System;
using System.Text;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Day5Class
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            //Console.WriteLine(Hash.shaMd5("secret"));
            //Console.WriteLine(Hash.sha1("secret"));
            //Console.WriteLine(Hash.sha256("secret"));
            //Console.WriteLine(Hash.sha512("secret"));




            /* To use Auth class, first u need to create user because the database is empty
             */

            //Cart cart = new Cart();
            //cart.addItem(item_id: 1, price: 30000, quantity: 3)
            //    .addItem(item_id: 2, price: 10000)
            //    .addItem(item_id: 3, price: 5000, quantity: 2)
            //    .removeItem(item_id: 2)
            //    .addItem(item_id: 4, price: 400, quantity: 6)
            //    .addDiscount("50%");

            //Console.WriteLine(cart.totalItems());
            //Console.WriteLine(cart.totalQuantity());
            //Console.WriteLine(cart.totalPrice());
            //cart.showAll();
            //cart.checkout();
        }
    }

    class Hash
    {

        public static string shaMd5(string s)
        {
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(s);
            byte[] hash = md5.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();
            for (int i=0;i<hash.Length;i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

        public static string sha1(string s)
        {
            SHA1 sha1 = System.Security.Cryptography.SHA1.Create();
            byte[] inputbytes = System.Text.Encoding.ASCII.GetBytes(s);
            byte[] hash = sha1.ComputeHash(inputbytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

        public static string sha256(string s)
        {
            SHA256 sha256 = System.Security.Cryptography.SHA256.Create();
            byte[] inputbytes = System.Text.Encoding.ASCII.GetBytes(s);
            byte[] hash = sha256.ComputeHash(inputbytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

        public static string sha512(string s)
        {
            SHA512 sha512 = System.Security.Cryptography.SHA512.Create();
            byte[] inputbytes = System.Text.Encoding.ASCII.GetBytes(s);
            byte[] hash = sha512.ComputeHash(inputbytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }

    class Cipher
    {
        public static string encrypt(string s1, string s2)
        {
            return "Anyone without password can't read this message";
        }

        public static string decrypt(string s1, string s2)
        {
            return "Ini tulisan rahasia";
        }
    }

    class Log
    {

    }

    class Auth
    {
        public static List<user> database { get; set; }

        public static List<user> log { get; set; } 

        public static user currentUser { get; set; }

        public Auth()
        {
            database = new List<user>();
            log = new List<user>();
        }

        public static void createUser(string user, string pwd)
        {
            database.Add(new user { Username = user, Password = pwd });
        }

        public static void login(string username, string pwd)
        {
            var user = new user
            {
                Username = username,
                Password = pwd
            };
            if (database.Contains(user) && currentUser == null)
            {
                currentUser = user;
                log.Add(user);
                Console.WriteLine("Loggin Succesfully");
            }
            else { Console.WriteLine("Incorrect username or password")};
        }

        public static void validate(string username, string pwd)
        {
            var user = new user
            {
                Username = username,
                Password = pwd
            };
            if (database.Contains(user))
            {
                Console.WriteLine("Verify");
            }
            else { Console.WriteLine("Not Verify")};
        }

        public static void logout()
        {
            currentUser = null;
            Console.WriteLine("Logout Succesfull");
        }

        public static void user()
        {
            Console.WriteLine($"Current user logged in : {currentUser}");
        }

        public static void id()
        {
            foreach (var i in database)
            {
                Console.WriteLine($"user_id : {currentUser.Username}");
            }
        }

        public static bool check()
        {
            if (currentUser != null)
            {
                return true;
            }
            return false;
        }

        public static bool guest()
        {
            if (currentUser == null)
            {
                return true;
            }
            return false;
        }

        public static void lastlogin()
        {
            Console.WriteLine(log[log.Count - 1]);
        }
    }

    class user
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    class Cart : ICart
    {
        public List<int[]> total { get; set; }

        public Cart()
        {
            total = new List<int[]>();
        }

        public ICart addItem(int item_id, int price, int quantity = 1)
        {

            total.Add(new int[] { item_id, price, quantity});
            return this;
        }

        public ICart removeItem(int item_id)
        {
            total.RemoveAll(x => x[0]== item_id);
            return this;
        }

        public ICart addDiscount(string s1)
        {
            var disc = Convert.ToDouble(s1.Substring(0, s1.Length - 1))/100.0;
            foreach (var i in total)
            {
                i[1] = Convert.ToInt32(Convert.ToDouble(i[1]) * disc);
            }
            return this;
        }

        public int totalItems()
        {
            return total.Count;
        }

        public int totalQuantity()
        {
            return total.Sum(x => x[2]);
        }

        public int totalPrice()
        {
            return total.Sum(x => x[1] * x[2]);
        }

        public void showAll()
        {
            foreach (var i in total)
            {
                Console.WriteLine($"item_id : {i[0]}, price : {i[1]}, quantity : {i[2]}");
            }
        }

        public void checkout()
        {
            using (TextWriter tw = new StreamWriter("/Users/gigaming/Downloads/Refactory Image/Training/Refactory Task/Day5Class/Day5Class/Checkout.txt"))
            {
                foreach (var i in total)
                    tw.WriteLine($"item_id : {i[0]}, price : {i[1]}, quantity : {i[2]}");
            }
        }
    }
}
