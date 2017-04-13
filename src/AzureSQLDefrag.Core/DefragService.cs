using System;
using System.Collections.Generic;
using System.Text;

namespace AzureSQLDefrag
{
    public class DefragService
    {
        private readonly string _connectionString;
        private readonly int _reorganizeFragmentationThreshold;
        private readonly int _rebuildFragmentationThreshold;
        private readonly Logging.ILogger _logger;
        public DefragService(Logging.ILogger logger, string connectionString, int reorganizeFragmentationThreshold = 3, int rebuildFragmentationThreshold = 30)
        {
            _connectionString = connectionString;
            _reorganizeFragmentationThreshold = reorganizeFragmentationThreshold;
            _rebuildFragmentationThreshold = rebuildFragmentationThreshold;
            _logger = logger;
        }

        public void Run()
        {
            using (var database = new Database(_connectionString))
            {

                var tables = database.GetTables();

                
                reorganizeIndexs(database, tables);
                rebuildIndexs(database, tables);
            }
        }

        private void reorganizeIndexs(IDatabase database, IList<string> tables)
        {
            _logger.Debug("Reorganizing Indexs...");

            foreach (var table in tables)
            {
                _logger.Debug($"Reorganizing Indexs for table '{table}'");
                var indexs = database.GetFragmentedIndexes(table, _reorganizeFragmentationThreshold);

                foreach (var index in indexs)
                {
                    _logger.Information($"Reorganizing Indexs for table '{table}', Index '{index}'");

                    database.ReorganizeIndex(index, table);
                }
            }
        }

        private void rebuildIndexs(IDatabase database, IList<string> tables)
        {
            _logger.Debug("Rebuilding Indexs...");
            foreach (var table in tables)
            {
                _logger.Debug($"Rebuilding Indexs for table '{table}'");
                var indexs = database.GetFragmentedIndexes(table, _rebuildFragmentationThreshold);

                foreach (var index in indexs)
                {
                    _logger.Information($"Rebuilding Indexs for table '{table}', Index '{index}'");
                    database.RebuildIndex(index, table);
                }
            }
        }

    }
}
