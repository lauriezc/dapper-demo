using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entity.THLotteryDB;

namespace Model.Common.Test
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestMethod1()
        {
            var list = FlowInfoExten.GetList("1=1");
            Assert.IsNotNull(list);
        }
    }
}
