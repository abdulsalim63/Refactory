using System;
using System.Text;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;

namespace Day5Class
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine(Hash.shaMd5("secret"));
            Console.WriteLine(Hash.sha1("secret"));
            Console.WriteLine(Hash.sha256("secret"));
            Console.WriteLine(Hash.sha512("secret"));

            //Console.WriteLine(Cipher.Encrypt("Ini Tulisan Rahasia", "gigaming"));
            //Console.WriteLine(Cipher.Decrypt("Ini Tulisan Rahasia", "gigaming"));

            SimpleLogger trial = new SimpleLogger(); //This is a sample from the internet, it's beyond my knowledge
            trial.Debug("some text");

            // To use Auth class, first u need to create user because the database is empty
            Auth gigaming = new Auth();
            var user = new user
            {
                Username = "salim",
                Password = "gigaming"
            };
            Auth.createUser(user.Username, user.Password);
            Auth.createUser("salimAgain", "different");

            Auth.login("salim", "gigaming");
            Auth.validate("salimAgain", "different");
            Auth.validate("salim_again", "different");
            Auth.logout();
            Auth.logout();
            Auth.login("salimAgain", "different");
            Auth.user();
            Auth.id();
            Console.WriteLine(Auth.check());
            Console.WriteLine(Auth.guest());
            Auth.logout();
            Console.WriteLine(Auth.guest());
            Auth.lastlogin();

            Cart cart = new Cart();
            cart.addItem(item_id: 1, price: 30000, quantity: 3)
                .addItem(item_id: 2, price: 10000)
                .addItem(item_id: 3, price: 5000, quantity: 2)
                .removeItem(item_id: 2)
                .addItem(item_id: 4, price: 400, quantity: 6)
                .addDiscount("50%");

            Console.WriteLine(cart.totalItems());
            Console.WriteLine(cart.totalQuantity());
            Console.WriteLine(cart.totalPrice());
            cart.showAll();
            cart.checkout();
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
            return sb.ToString().ToLower();
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
            return sb.ToString().ToLower();
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
            return sb.ToString().ToLower();
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
            return sb.ToString().ToLower();
        }
    }

    public static class Cipher
    {
        // This constant is used to determine the keysize of the encryption algorithm in bits.
        // We divide this by 8 within the code below to get the equivalent number of bytes.
        private const int Keysize = 256;

        // This constant determines the number of iterations for the password bytes generation function.
        private const int DerivationIterations = 1000;

        public static string Encrypt(string plainText, string passPhrase)
        {
            var saltStringBytes = Generate256BitsOfRandomEntropy();
            var ivStringBytes = Generate256BitsOfRandomEntropy();
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            using (var password = new Rfc2898DeriveBytes(passPhrase, saltStringBytes, DerivationIterations))
            {
                var keyBytes = password.GetBytes(Keysize / 8);
                using (var symmetricKey = new RijndaelManaged())
                {
                    symmetricKey.BlockSize = 256;
                    symmetricKey.Mode = CipherMode.CBC;
                    symmetricKey.Padding = PaddingMode.PKCS7;
                    using (var encryptor = symmetricKey.CreateEncryptor(keyBytes, ivStringBytes))
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                            {
                                cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                                cryptoStream.FlushFinalBlock();
                                var cipherTextBytes = saltStringBytes;
                                cipherTextBytes = cipherTextBytes.Concat(ivStringBytes).ToArray();
                                cipherTextBytes = cipherTextBytes.Concat(memoryStream.ToArray()).ToArray();
                                memoryStream.Close();
                                cryptoStream.Close();
                                return Convert.ToBase64String(cipherTextBytes);
                            }
                        }
                    }
                }
            }
        }

        public static string Decrypt(string cipherText, string passPhrase)
        {
            // Get the complete stream of bytes that represent:
            // [32 bytes of Salt] + [32 bytes of IV] + [n bytes of CipherText]
            var cipherTextBytesWithSaltAndIv = Convert.FromBase64String(cipherText);
            // Get the saltbytes by extracting the first 32 bytes from the supplied cipherText bytes.
            var saltStringBytes = cipherTextBytesWithSaltAndIv.Take(Keysize / 8).ToArray();
            // Get the IV bytes by extracting the next 32 bytes from the supplied cipherText bytes.
            var ivStringBytes = cipherTextBytesWithSaltAndIv.Skip(Keysize / 8).Take(Keysize / 8).ToArray();
            // Get the actual cipher text bytes by removing the first 64 bytes from the cipherText string.
            var cipherTextBytes = cipherTextBytesWithSaltAndIv.Skip((Keysize / 8) * 2).Take(cipherTextBytesWithSaltAndIv.Length - ((Keysize / 8) * 2)).ToArray();

            using (var password = new Rfc2898DeriveBytes(passPhrase, saltStringBytes, DerivationIterations))
            {
                var keyBytes = password.GetBytes(Keysize / 8);
                using (var symmetricKey = new RijndaelManaged())
                {
                    symmetricKey.BlockSize = 256;
                    symmetricKey.Mode = CipherMode.CBC;
                    symmetricKey.Padding = PaddingMode.PKCS7;
                    using (var decryptor = symmetricKey.CreateDecryptor(keyBytes, ivStringBytes))
                    {
                        using (var memoryStream = new MemoryStream(cipherTextBytes))
                        {
                            using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                            {
                                var plainTextBytes = new byte[cipherTextBytes.Length];
                                var decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                                memoryStream.Close();
                                cryptoStream.Close();
                                return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
                            }
                        }
                    }
                }
            }
        }

        private static byte[] Generate256BitsOfRandomEntropy()
        {
            var randomBytes = new byte[32];
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetBytes(randomBytes);
            }
            return randomBytes;
        }
    }


    public class SimpleLogger
    {
        private const string FILE_EXT = ".log";
        private readonly string datetimeFormat;
        private readonly string logFilename;

        /// <summary>
        /// Initiate an instance of SimpleLogger class constructor.
        /// If log file does not exist, it will be created automatically.
        /// </summary>
        public SimpleLogger()
        {
            datetimeFormat = "yyyy-MM-dd HH:mm:ss.fff";
            logFilename = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + FILE_EXT;

            // Log file header line
            string logHeader = logFilename + " is created.";
            if (!System.IO.File.Exists(logFilename))
            {
                WriteLine(System.DateTime.Now.ToString(datetimeFormat) + " " + logHeader, false);
            }
        }

        /// <summary>
        /// Log a DEBUG message
        /// </summary>
        /// <param name="text">Message</param>
        public void Debug(string text)
        {
            WriteFormattedLog(LogLevel.DEBUG, text);
        }

        /// <summary>
        /// Log an ERROR message
        /// </summary>
        /// <param name="text">Message</param>
        public void Error(string text)
        {
            WriteFormattedLog(LogLevel.ERROR, text);
        }

        /// <summary>
        /// Log a FATAL ERROR message
        /// </summary>
        /// <param name="text">Message</param>
        public void Fatal(string text)
        {
            WriteFormattedLog(LogLevel.FATAL, text);
        }

        /// <summary>
        /// Log an INFO message
        /// </summary>
        /// <param name="text">Message</param>
        public void Info(string text)
        {
            WriteFormattedLog(LogLevel.INFO, text);
        }

        /// <summary>
        /// Log a TRACE message
        /// </summary>
        /// <param name="text">Message</param>
        public void Trace(string text)
        {
            WriteFormattedLog(LogLevel.TRACE, text);
        }

        /// <summary>
        /// Log a WARNING message
        /// </summary>
        /// <param name="text">Message</param>
        public void Warning(string text)
        {
            WriteFormattedLog(LogLevel.WARNING, text);
        }

        private void WriteLine(string text, bool append = true)
        {
            try
            {
                using (System.IO.StreamWriter writer = new System.IO.StreamWriter(logFilename, append, System.Text.Encoding.UTF8))
                {
                    if (!string.IsNullOrEmpty(text))
                    {
                        writer.WriteLine(text);
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        private void WriteFormattedLog(LogLevel level, string text)
        {
            string pretext;
            switch (level)
            {
                case LogLevel.TRACE:
                    pretext = System.DateTime.Now.ToString(datetimeFormat) + " [TRACE]   ";
                    break;
                case LogLevel.INFO:
                    pretext = System.DateTime.Now.ToString(datetimeFormat) + " [INFO]    ";
                    break;
                case LogLevel.DEBUG:
                    pretext = System.DateTime.Now.ToString(datetimeFormat) + " [DEBUG]   ";
                    break;
                case LogLevel.WARNING:
                    pretext = System.DateTime.Now.ToString(datetimeFormat) + " [WARNING] ";
                    break;
                case LogLevel.ERROR:
                    pretext = System.DateTime.Now.ToString(datetimeFormat) + " [ERROR]   ";
                    break;
                case LogLevel.FATAL:
                    pretext = System.DateTime.Now.ToString(datetimeFormat) + " [FATAL]   ";
                    break;
                default:
                    pretext = "";
                    break;
            }

            WriteLine(pretext + text);
        }

        [System.Flags]
        private enum LogLevel
        {
            TRACE,
            INFO,
            DEBUG,
            WARNING,
            ERROR,
            FATAL
        }
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
            Console.WriteLine($"Total user : {database.Count}");
        }

        public static void login(string username, string pwd)
        {
            var nonExists = true;
            foreach (var i in database)
            {
                if (i.Username == username && i.Password == pwd)
                {
                    currentUser = new user { Username = username, Password = pwd };
                    log.Add(new user { Username = username, Password = pwd }) ;
                    nonExists = false;
                    Console.WriteLine("Loggin Succesfull");
                    break;
                }
            }
            if (nonExists) { Console.WriteLine("Incorrect username or password"); }
        }

        public static void validate(string username, string pwd)
        {
            var nonExists = true;
            foreach (var i in database)
            {
                if (i.Username == username && i.Password == pwd)
                {
                    nonExists = false;
                    Console.WriteLine("Verify");
                    break;
                }
            }
            if (nonExists) { Console.WriteLine("Not Verified User"); }
        }

        public static void logout()
        {
            if (currentUser != null)
            {
                currentUser = null;
                Console.WriteLine("Logout Succesfull");
            }
            else { Console.WriteLine("No user currently logged in");  }
        }

        public static void user()
        {
            Console.WriteLine($"Current user logged in : {currentUser.Username}");
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
            Console.WriteLine(log[log.Count - 1].Username);
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
