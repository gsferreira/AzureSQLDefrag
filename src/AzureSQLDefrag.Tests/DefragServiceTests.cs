using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using Xunit;

namespace AzureSQLDefrag.Tests
{
    public class DefragServiceTests
    {
        [Fact]
        public void TestRun()
        {
            var logger = new Logging.Logger();

            var defragService = new DefragService(logger, "Data Source=.;Initial Catalog=tempdb;Integrated Security=True;");
            
            defragService.Run();

            Assert.True(true);
        }

    
    }
}
