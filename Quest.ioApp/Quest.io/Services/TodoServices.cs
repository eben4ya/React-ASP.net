using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Quest.io.Data;
using Quest.io.Models;

namespace Quest.io.Services
{
    public class TodoServices
    {
        private readonly IMongoCollection<Todo> _todoCollection;

        public TodoServices(IOptions<DatabaseSettings> settings)
        {
            var mongoClient = new MongoClient(settings.Value.Connection);
            var mongoDb = mongoClient.GetDatabase(settings.Value.DatabaseName);
            _todoCollection = mongoDb.GetCollection<Todo>(settings.Value.CollectionName);
        }

        // get all task
        public async Task<List<Todo>> GetAsync() => await _todoCollection.Find(_ => true).ToListAsync();

        // get task by id
        public async Task<Todo> GetAsync(string id) => await _todoCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        // add new task
        public async Task CreateAsync(Todo newTodo) => await _todoCollection.InsertOneAsync(newTodo);

        // update task

        public async Task UpdateAsync(string id, Todo updateTodo) => await _todoCollection.ReplaceOneAsync(x => x.Id == id, updateTodo);

        // delete student
        public async Task RemoveAsync(string id) => await _todoCollection.DeleteOneAsync(x => x.Id == id);




    }
}
