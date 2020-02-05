using NUnit.Framework;
using Day3UnitTesting;

namespace Unt
{
    public class Tests
    {
        charachterCount character;
        _2 grade;
        _3 oE;
        _4 lY;
        _5 mR;
        _6 lR;
        _7 eP;
        _8 P;
        _9 rA;
        _10 aA;

        [SetUp]
        public void Setup()
        {
            character = new charachterCount();
            grade = new _2();
            oE = new _3();
            lY = new _4();
            mR = new _5();
            lR = new _6();
            eP = new _7();
            P = new _8();
            rA = new _9();
            aA = new _10();
        }

        [Test]
        public void characterCountTest1()
        {
            var result = character.words("saya");
            Assert.AreEqual(4, result);
        }

        [Test]
        public void characterCountTest2()
        {
            var result = character.words("lari pagi");
            Assert.AreEqual(9, result);
        }

        [Test]
        public void gradeTest1()
        {
            var result = grade.grading(30);
            Assert.AreEqual("E", result);
        }

        [Test]
        public void gradeTest2()
        {
            var result = grade.grading(75);
            Assert.AreEqual("C", result);
        }

        [Test]
        public void oddEvenTest1()
        {
            var result = oE.oddEven(43);
            Assert.AreEqual("odd", result);
        }

        [Test]
        public void oddEvenTest2()
        {
            var result = oE.oddEven(1032);
            Assert.AreEqual("even", result);
        }

        [Test]
        public void leapYearTest1()
        {
            var result = lY.leapYear(1900);
            Assert.AreEqual("Not Leap Year", result);
        }

        [Test]
        public void leapYearTest2()
        {
            var result = lY.leapYear(2000);
            Assert.AreEqual("Leap Year", result);
        }

        [Test]
        public void leapYearTest3()
        {
            var result = lY.leapYear(2001);
            Assert.AreEqual("Not Leap Year", result);
        }

        [Test]
        public void leapYearTest4()
        {
            var result = lY.leapYear(2016);
            Assert.AreEqual("Leap Year", result);
        }

        [Test]
        public void movieRatedTest1()
        {
            var result = mR.movieRated(15);
            Assert.AreEqual("Remaja", result);
        }

        [Test]
        public void movieRatedTest2()
        {
            var result = mR.movieRated(32);
            Assert.AreEqual("Dewasa", result);
        }

        [Test]
        public void loopWithRange()
        {
            var result = lR.loopRange(4, 8);
            Assert.AreEqual(new int[5] { 4, 5, 6, 7, 8 }, result);
        }

        [Test]
        public void oddPrint()
        {
            var result = eP.oddPrint(10);
            Assert.AreEqual(new int[5] { 1, 3, 5, 7, 9 }, result);
        }

        [Test]
        public void print()
        {
            var result = P.print(10);
            Assert.AreEqual(new string[10] { "Ganjil", "Genap", "Ganjil", "Genap", "Ganjil Kelipatan Lima", "Genap", "Ganjil", "Genap", "Ganjil", "Genap Kelipatan Lima" }, result);
        }

        [Test]
        public void reverseString()
        {
            var result = rA.reverseAgain("saya ingin makan nasi goreng");
            Assert.AreEqual("goreng nasi makan ingin saya", result);
        }

        [Test]
        public void addArray()
        {
            var arr = new string[5]{ "Meja", "Buku", "Topi", "Baju", "Kayu" };
            var result = aA.addArray(arr, "Handuk", "Celana");
            Assert.AreEqual(new string[7] { "Handuk", "Meja", "Buku", "Topi", "Baju", "Kayu", "Celana" }, result);
        }
    }
}