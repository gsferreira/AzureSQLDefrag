using System.Collections.Generic;

namespace AzureSQLDefrag
{
    public interface IDatabase
    {
        IList<string> GetFragmentedIndexes(string table, int fragmentationThreshold);
        IList<string> GetTables();
        void RebuildIndex(string indexName, string table);
        void ReorganizeIndex(string indexName, string table);
    }
}