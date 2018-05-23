namespace MySqlQueryPreparator
{
    public class SqlQueryPreparator
    {
        private readonly ISafeString _safeString;

        public SqlQueryPreparator(ISafeString safeString)
        {
            _safeString = safeString;
        }

        public string[] PrepareQueries(string[] queries)
        {

            for (int i = 0; i < queries.Length; i++)
            {
                queries[i] = _safeString.SafeString(queries[i]);
            }

            return queries;
        }
    }
}
