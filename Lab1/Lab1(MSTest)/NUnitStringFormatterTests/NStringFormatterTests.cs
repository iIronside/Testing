using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyStringFormatter;

/*
 * В Production Code написать класс StringFormatter с методом string SafeString( string s ), 
 * который во входной строке экранирует все одинарные кавычки (дублирует их для защиты от 
 * sql-инъекций в Postgre), а также переводит все ключевые слова select, insert, update, 
 * delete в верхний регистр; если строка пустая, то метод возвращает также пустую строку; 
 * если строка является null, то метод бросает исключение NullReferenceException. 
 */
namespace NUnitStringFormatterTests
{
    [TestFixture]
    public class NStringFormatterTests
    {
        [Test]
        public void NSafeString_testStr_convertedStr()
        {
            string initialStr = "select * from users where fname like '%na' order by id;";
            string expectedStr = "SELECT * FROM users WHERE fname LIKE '''%na''' ORDER BY id;";

            StringFormatter strFormat = new StringFormatter();
            string resultStr = strFormat.SafeString(initialStr);

            Assert.AreEqual(resultStr, expectedStr);
        }

        [Test]
        public void NSafeString_emptyStr_emptyStr()
        {
            StringFormatter strFormat = new StringFormatter();
            string result = strFormat.SafeString("");

            Assert.AreEqual(result,"");
        }

        [Test]
        public void NSafeString_null_exception()
        {
            Assert.Throws<NullReferenceException>(() => 
            {
                StringFormatter strFormat = new StringFormatter();
                var result = strFormat.SafeString(null);
            });
        }
    }
}
