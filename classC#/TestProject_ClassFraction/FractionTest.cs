/// Обыкновенные дроби и операции над ними
/// Тестирование методов класса
/// @author Будаев Г.Б.
using classFraction;

namespace TestProject_ClassFraction
{
    
    [TestClass]
    public class FractionTest
    {
        [TestMethod]
        public void ConstructorsTest() /// Тест конструкторов
        {
            Fraction F1 = new Fraction();
            Fraction F2 = new (3, 5);
            Assert.AreEqual(1, F1.GetNumerator(), "Constructor w/o params error ");
            Assert.AreEqual(1, F1.GetDenominator(), "Constructor w/o params error ");
            Assert.AreEqual(3, F2.GetNumerator(), "Constructor w/ params error ");
            Assert.AreEqual(5, F2.GetDenominator(), "Constructor w/ params error ");

            Fraction F3 = new(-3, 1);
            Assert.AreEqual(-3, F3.GetNumerator(), "Constructor w/ params error ");
            Assert.AreEqual(1, F3.GetDenominator(), "Constructor w/ params error ");

            /// Тест исключительной ситуации, когда знаменатель равен нулю
            Assert.ThrowsException<ArgumentException>(() => F3.SetDenominator(0));
        }

        [TestMethod]
        public void SetterGetterChangerTest() /// Тест сеттеров и геттеров
        {
            Fraction F = new Fraction();
            F.SetNumerator(5);
            F.SetDenominator(10);
            Assert.AreEqual(5, F.GetNumerator(), "Setter error ");
            Assert.AreEqual(10, F.GetDenominator(), "Setter error ");

            F.ChangeParams(6, 11);
            Assert.AreEqual(6, F.GetNumerator(), "Changer error ");
            Assert.AreEqual(11, F.GetDenominator(), "Changer error ");

            F.ChangeParams(-6, 11);
            Assert.AreEqual(-6, F.GetNumerator(), "Changer error ");
            Assert.AreEqual(11, F.GetDenominator(), "Changer error ");

            /// Тест исключительной ситуации, когда знаменатель равен нулю
            Assert.ThrowsException<ArgumentException>(() => F.ChangeParams(1,0));
        }

        [TestMethod]
        public void ToStringTest() /// Тест метода перевода в строковый тип
        {
            Fraction F = new Fraction(1,2);
            Assert.AreEqual("1/2", F.ToString(), "ToString error ");

            Fraction F2 = new Fraction(-55, 2);
            Assert.AreEqual("-55/2", F2.ToString(), "ToString error ");

            Fraction F3 = new Fraction(12, 12);
            Assert.AreEqual("1/1", F3.ToString(), "ToString error ");
        }

        [TestMethod]
        public void OperatorsTest() /// Тест операторов
        {
            Fraction F1 = new Fraction(1, 5);
            Fraction F2 = new Fraction(3, 5);
            Assert.AreEqual( "4/5", (F1 + F2).ToString(), "Operator+ error ");
            Assert.AreEqual("-2/5", (F1 - F2).ToString(), "Operator- error ");
            Assert.AreEqual("3/25", (F1 * F2).ToString(), "Operator* error ");
            Assert.AreEqual( "1/3", (F1 / F2).ToString(), "Operator/ error ");

            Fraction F3 = new Fraction(3, 6);
            Fraction F4 = new Fraction(1, 2);
            Assert.AreEqual("1/1", (F3 + F4).ToString(), "Operator+ error ");
            Assert.AreEqual("0/1", (F3 - F4).ToString(), "Operator- error ");
            Assert.AreEqual("1/4", (F3 * F4).ToString(), "Operator* error ");
            Assert.AreEqual("1/1", (F3 / F4).ToString(), "Operator/ error ");

            Fraction F5 = new Fraction(0, 5);

            /// Тест исключительной ситуации на деление на ноль
            Assert.ThrowsException<DivideByZeroException>(() => F4/F5);
        }

        [TestMethod]
        public void ShortenTest() /// Тест сокращения
        {
            Fraction F = new Fraction(2, 4);
            Assert.AreEqual("1/2", (F.Shorten()).ToString(), "Shorten error ");

            Fraction F2 = new Fraction(-2, 4);
            Assert.AreEqual("-1/2", (F2.Shorten()).ToString(), "Shorten error ");

            Fraction F3 = new Fraction(10, 5);
            Assert.AreEqual("2/1", (F3.Shorten()).ToString(), "Shorten error ");

        }

        [TestMethod]
        public void ConvertToDoubleTest() /// Тест перевода в вещественное число
        {
            Fraction F = new Fraction(1, 3);
            Assert.AreEqual(0.333, F.ConvertToDouble(), 0.001, "ConvertToDouble error");

            Fraction F2 = new Fraction(-5, 3);
            Assert.AreEqual(-1.666, F2.ConvertToDouble(), 0.001, "ConvertToDouble error");

            Fraction F3 = new Fraction(10, 5);
            Assert.AreEqual(2, F3.ConvertToDouble(), 0.001, "ConvertToDouble error");
        }

        [TestMethod]
        public void ComparisonTest() /// Тест сравнения
        {
            Fraction F1 = new Fraction(2, 3);
            Fraction F2 = new Fraction(1, 3);
            Assert.AreEqual(1, F1.Compare(F2), "Comparison error");
            Assert.AreEqual(-1, F2.Compare(F1), "Comparison error");
            Assert.AreEqual(0, F1.Compare(F2+F2), "Comparison error");
        }

    }
}