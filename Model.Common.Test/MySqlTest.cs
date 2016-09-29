using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entity.dapper_test;
using System.Linq;
using System.Collections.Generic;

namespace Model.Common.Test
{
    [TestClass]
    public class MySqlTest
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

        [TestMethod]
        public void TestInsertList()
        {
            var list = new List<Entity.dapper_test.Test>();
            for (var i = 0; i < 5; i++)
            {
                var test = new Entity.dapper_test.Test();
                test.id = 1;
                test.name = "dapper_t4_insert_test_" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                test.Time = DateTime.Now;
                list.Add(test);
            }
            var row = list.Insert();
            Assert.AreEqual(list.Count, row);
        }


        [TestMethod]
        public void TestUpdate()
        {
            var test = TestExten.GetModel("1=1", "id");
            test.Time = DateTime.Now;
            var row = test.Update();
            Assert.AreEqual(1, row);
        }

        [TestMethod]
        public void TestUpdateList()
        {
            var list = TestExten.GetList("1=1").Take(3).ToList();
            for(var i = 0; i < list.Count; i++)
            {
                list[i].Time = DateTime.Now;
            }
            var row = list.Update();
            Assert.AreEqual(list.Count, row);
        }

        [TestMethod]
        public void TestGetModel()
        {
            var test = TestExten.GetModel("1=1", "id desc");
            Assert.IsNotNull(test);
        }

        [TestMethod]
        public void TestGetModelByPrimary()
        {
            var data = TestExten.GetModel("1=1", "id");
            var test = TestExten.GetModel(data.id);
            Assert.IsNotNull(test);
        }

        [TestMethod]
        public void TestGetList()
        {
            var list = TestExten.GetList("name is not null");
            Assert.IsNotNull(list);
            Assert.IsTrue(list.Count > 0);
        }

        [TestMethod]
        public void TestDelete()
        {
            var test = TestExten.GetModel("1=1", "id");
            var row=test.Delete();
            Assert.AreEqual(1, row);
        }

        [TestMethod]
        public void TestDeleteByPrimary()
        {
            var test = TestExten.GetModel("1=1", "id");
            var row = TestExten.Delete(test.id);
            Assert.AreEqual(1, row);
        }

        [TestMethod]
        public void TestDeleteList()
        {
            var list = TestExten.GetList("1=1").Take(3).ToList();
            var row=list.Delete();
            Assert.AreEqual(list.Count, row);
        }

        [TestMethod]
        public void TestDeleteListByPrimaryArray()
        {
            var list = TestExten.GetList("1=1").Take(2).ToList();
            var row = TestExten.Delete(list.Select(m=>m.id).ToArray());
            Assert.AreEqual(list.Count, row);
        }

        [TestMethod]
        public void TestPageList()
        {
            var index = 2;
            var size = 3;
            var list = TestExten.GetPageList(index, size);
            var tarlist = TestExten.GetList("1=1").OrderByDescending(m => m.id).Skip((index-1)*size).Take(size).ToList();
            bool valid = true;
            var actual = list.Data as List<Entity.dapper_test.Test>;
            for (var i=0;i< actual.Count;i++)
            {

                if(!tarlist[i].id.Equals(actual[i].id))
                {
                    valid = false;
                }
            }
            Assert.IsTrue(valid);
        }
    }

}
