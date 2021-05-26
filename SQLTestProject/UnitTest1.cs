using NUnit.Framework;
using System.Collections.Generic;

namespace SQLTestProject
{
    public class Tests
    {
        private SqlHelper _sqlHelper;

        [SetUp]
        public void Setup()
        {
            _sqlHelper = new SqlHelper("Shop");
            _sqlHelper.OpenConnection();
        }

        [TearDown]
        public void TearDown()
        {
            _sqlHelper.ExecuteNonQuery("delete from [Shop].[dbo].[Products] where id = 22");
            _sqlHelper.ExecuteNonQuery("delete from [Shop].[dbo].[Products] where id = 23");
            _sqlHelper.CloseConnection();
        }

        [Test]
        public void Test1()
        {
            _sqlHelper.Insert("Products",
                new Dictionary<string, string> { { "Id", "23" }, { "Name", "'Test23'" }, { "Count", "234" } });
            var res = _sqlHelper.IsRowExistedInTable("Products",
                new Dictionary<string, string> { { "Id", "23" }, { "Name", "'Test23'" }, { "Count", "234" } });

            Assert.True(res);
        }

        [Test]
        public void Test2()
        {
            _sqlHelper.Insert("Products",
                new Dictionary<string, string> { { "Id", "23" }, { "Name", "'Test23'" }, { "Count", "234" } });
            _sqlHelper.Delete("Products",
                new Dictionary<string, string> { { "Name", "'Test23'" }, { "Count", "234" } });
            var res = _sqlHelper.IsRowExistedInTable("Products",
                new Dictionary<string, string> { { "Id", "23" }, { "Name", "'Test23'" }, { "Count", "234" } });

            Assert.IsFalse(res);
        }

        [Test]
        public void Test3()
        {
            _sqlHelper.Insert("Products",
                new Dictionary<string, string> { { "Id", "23" }, { "Name", "'Test23'" }, { "Count", "234" } });
            _sqlHelper.Edit("Products",
                new Dictionary<string, string> { { "Id", "23" }, { "Name", "'Test23'" }, { "Count", "234" } },
                new Dictionary<string, string> { { "Id", "22" }, { "Name", "'Test22'" }, { "Count", "224" } });

            var res = _sqlHelper.IsRowExistedInTable("Products",
                new Dictionary<string, string> { { "Id", "22" }, { "Name", "'Test22'" }, { "Count", "224" } });

            Assert.IsTrue(res);
        }
    }
}
