using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SQLTestProject.API
{
    [Binding]
    public class DataBaseConnectionSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly SqlHelper _sqlHelper;

        public DataBaseConnectionSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _sqlHelper = _scenarioContext.Get<SqlHelper>(Context.SqlHelper);
        }

        [When(@"I create row in table with data")]
        public void WhenICreateRowInTableWithData(Table table)
        {
            var productModels = table.CreateSet<ProductModel>().ToList();
            try
            {
                _sqlHelper.Insert("Products",
                   new Dictionary<string, string> {
                    { "Id", $"{ productModels[0].Id }" },
                    { "Name", $"'{ productModels[0].Name }'" },
                    { "Count", $"{ productModels[0].Count }" }
                   });
            }
            catch (Exception exception)
            {
                _scenarioContext.Add(Context.ExceptionMessage, exception);

            }
        }

        [Then(@"Row created with data")]
        public void ThenRowCreatedWithData(Table table)
        {
            var productModels = table.CreateSet<ProductModel>().ToList();

            var isRowExist = _sqlHelper.IsRowExistedInTable("Products",
                new Dictionary<string, string> {
                    { "Id", $"{ productModels[0].Id }" },
                    { "Name", $"'{ productModels[0].Name }'" },
                    { "Count", $"{ productModels[0].Count }" }
                });

            Assert.IsTrue(isRowExist);
        }

        [Given(@"Row created in database with data")]
        public void GivenRowCreatedInDatabaseWithData(Table table)
        {
            var productModels = table.CreateSet<ProductModel>().ToList();

            _sqlHelper.Insert("Products",
                new Dictionary<string, string> {
                    { "Id", $"{ productModels[0].Id }" },
                    { "Name", $"'{ productModels[0].Name }'" },
                    { "Count", $"{ productModels[0].Count }" }
                });
        }

        [When(@"I delete row in table with data")]
        public void WhenIDeleteRowInTableWithData(Table table)
        {
            var productModels = table.CreateSet<ProductModel>().ToList();

            _sqlHelper.Delete("Products",
                new Dictionary<string, string> {
                    { "Id", $"{ productModels[0].Id }" },
                    { "Name", $"'{ productModels[0].Name }'" },
                    { "Count", $"{ productModels[0].Count }" }
                });
        }

        [Then(@"Row with data deleted")]
        public void ThenRowWithDataDeleted(Table table)
        {
            var productModels = table.CreateSet<ProductModel>().ToList();

            var isRowExist = _sqlHelper.IsRowExistedInTable("Products",
                new Dictionary<string, string> {
                    { "Id", $"{ productModels[0].Id }" },
                    { "Name", $"'{ productModels[0].Name }'" },
                    { "Count", $"{ productModels[0].Count }" }
                });

            Assert.IsFalse(isRowExist);
        }

        [When(@"I edit row in table with data")]
        public void WhenIEditRowInTableWithData(Table table)
        {
            var productModels = table.CreateSet<ProductModel>().ToList();

            _sqlHelper.Edit("Products",
                new Dictionary<string, string> {
                    { "Id", $"{ productModels[0].Id }" },
                    { "Name", $"'{ productModels[0].Name }'" },
                    { "Count", $"{ productModels[0].Count }" }
                },
                new Dictionary<string, string> {
                    { "Id", $"{ productModels[0].NewId }" },
                    { "Name", $"'{ productModels[0].NewName }'" },
                    { "Count", $"{ productModels[0].NewCount }" }
                });
        }

        [Then(@"Row modified with data")]
        public void ThenRowModifiedWithData(Table table)
        {
            var productModels = table.CreateSet<ProductModel>().ToList();

            var isRowExist = _sqlHelper.IsRowExistedInTable("Products",
                new Dictionary<string, string> {
                    { "Id", $"{ productModels[0].Id }" },
                    { "Name", $"'{ productModels[0].Name }'" },
                    { "Count", $"{ productModels[0].Count }" }
                });

            Assert.IsTrue(isRowExist);
        }

        [Then(@"Displayed exception message '(.*)'")]
        public void ThenDisplayedExceptionMessage(string message)
        {
            Assert.AreEqual(message, _scenarioContext.Get<Exception>(Context.ExceptionMessage).Message);
        }


        public class ProductModel
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string Count { get; set; }
            public string NewId { get; set; }
            public string NewName { get; set; }
            public string NewCount { get; set; }


        }
    }
}
