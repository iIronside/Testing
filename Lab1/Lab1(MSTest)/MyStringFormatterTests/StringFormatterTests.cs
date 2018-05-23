using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyStringFormatter;


/*
 * В Production Code написать класс StringFormatter с методом string SafeString( string s ), 
 * который во входной строке экранирует все одинарные кавычки (дублирует их для защиты от 
 * sql-инъекций в Postgre), а также переводит все ключевые слова select, insert, update, 
 * delete в верхний регистр; если строка пустая, то метод возвращает также пустую строку; 
 * если строка является null, то метод бросает исключение NullReferenceException. 
 */
namespace MyStringFormatterTests
{
    [TestClass]
    public class StringFormatterTests
    {
        [TestMethod]
        public void SafeString_testStr_convertedStr()
        {
            string initialStr = "select * from users where fname like '%na' order by id;";
            string expectedStr = "SELECT * FROM users WHERE fname LIKE '''%na''' ORDER BY id;";

            StringFormatter strFormat = new StringFormatter();
            string resultStr = strFormat.SafeString(initialStr);

            Assert.AreEqual(resultStr, expectedStr);
        }

        [TestMethod]
        public void SafeString_empty_emptyStr()
        {
            StringFormatter strFormat = new StringFormatter();
            string result = strFormat.SafeString("");

            Assert.AreEqual(result, "");
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void SafeString_null_exception()
        {
            StringFormatter strFormat = new StringFormatter();
            var result = strFormat.SafeString(null);
        }
    }
}
