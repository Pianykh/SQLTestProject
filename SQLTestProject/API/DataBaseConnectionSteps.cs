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
        private readonly SqlHelper _sqlHelper = new SqlHelper("Shop");

        [Given(@"Establish a database connection")]
        public void GivenEstablishADatabaseConnection()
        {
            _sqlHelper.OpenConnection();
        }

        [When(@"I create row in table with data")]
        public void WhenICreateRowInTableWithData(Table table)
        {
            var productModels = table.CreateSet<ProductModel>().ToList();

            _sqlHelper.Insert("Products",
                new Dictionary<string, string> {
                    { "Id", $"{ productModels[0].Id }" },
                    { "Name", $"'{ productModels[0].Name }'" },
                    { "Count", $"{ productModels[0].Count }" }
                });
        }

        [Then(@"Row created with data")]
        public void ThenRowCreatedWithData(Table table)
        {
            var productModels = table.CreateSet<ProductModel>().ToList();

            _sqlHelper.IsRowExistedInTable("Products",
                new Dictionary<string, string> {
                    { "Id", $"{ productModels[0].Id }" },
                    { "Name", $"'{ productModels[0].Name }'" },
                    { "Count", $"{ productModels[0].Count }" }
                });
        }

        public class ProductModel
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string Count { get; set; }
        }
    }
}
