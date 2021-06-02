using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SQLTestProject
{
    [Binding]
    public class Hooks
    {
        private readonly ScenarioContext _scenarioContext;

        public Hooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario("db")]
        public void BeforeScenario()
        {
            SqlHelper sqlHelper = new SqlHelper("Shop");
            sqlHelper.OpenConnection();
            _scenarioContext.Add(Context.SqlHelper, sqlHelper);
        }

        [AfterScenario("db")]
        public void AfterScenario()
        {
            _scenarioContext.Get<SqlHelper>(Context.SqlHelper).ClearTable("Products");
            _scenarioContext.Get<SqlHelper>(Context.SqlHelper).CloseConnection();
        }
    }
}
