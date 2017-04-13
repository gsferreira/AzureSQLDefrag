using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AzureSQLDefrag.Tests
{
    public class DatabaseTests
    {
        [Fact]
        public void TestGetTables()
        {
            int numberOfTables = 0;
            using (var database = new Database(@"Data Source=.;Initial Catalog=tempdb;Integrated Security=True"))
            {

                var tables = database.GetTables();
                numberOfTables = tables.Count;

            }

            Assert.Equal(0, numberOfTables);
        }

    
    }
}
