namespace MongoChat.Data
{
    using MongoDB.Driver;
    using MongoChat.Models;

    public class MongoDbContext
    {
        private readonly string connectionString;
        private readonly string databaseName;
        private MongoServer mongoServer;

        public MongoDbContext()
            : this(Settings.Default.MongoDBCloudServer, Settings.Default.MongoDBDefaultDatabase)
        {
        }

        public MongoDbContext(string connectionString, string databaseName)
        {
            this.connectionString = connectionString;
            this.databaseName = databaseName;
        }

        public MongoCollection<Post> Posts
        {
            get
            {
                return this.GetCollection<Post>("Posts");
            }
        }

        public MongoCollection<UserSession> Users
        {
            get
            {
                return this.GetCollection<UserSession>("Users");
            }
        }

        private MongoCollection<T> GetCollection<T>(string collectionName)
        {
            var database = this.GetDatabase();
            return database.GetCollection<T>(collectionName);
        }

        private MongoDatabase GetDatabase()
        {
            var server = this.GetServer();
            return server.GetDatabase(this.databaseName);
        }

        private MongoServer GetServer()
        {
            if (this.mongoServer == null)
            {
                var mongoClient = new MongoClient(this.connectionString);
                this.mongoServer = mongoClient.GetServer();
            }

            return this.mongoServer;
        }
    }
}
