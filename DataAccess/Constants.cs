namespace DataAccess
{
    public static class Constants
    {
        public const string SERVER_NAME = "";
        public const string DATABASE_NAME = "";
        public const string USERNAME = "";
        public const string PASSWORD_NAME = "";

        // SQL Server
        public static string GET_CONNECTION_STRING()
        {
            return $"Server={SERVER_NAME};Database={DATABASE_NAME};User Id={USERNAME};Password={PASSWORD_NAME};";
        }
    }
}