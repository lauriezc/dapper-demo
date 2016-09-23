using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Model.Common.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestInsert()
        {
            var test = new Entity.dapper_test.Test();
            test.id = 1;
            test.name = "dapper_t4_insert_test_" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            test.Time = DateTime.Now;
            var count = test.Insert();
            Assert.AreEqual(count, 1);
        }
    }
}
