using SQLite;
using ToDoList.modelo;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ToDoList.Data
{
    public class TaskDatabase
    {
        private readonly SQLiteAsyncConnection _database;


        public TaskDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<tarea>().Wait();
        }

        public Task<List<tarea>> GetTasksAsync()
        {
            return _database.Table<tarea>().ToListAsync();
        }

        public Task<int> SaveTaskAsync(tarea task)
        {
            if (task.id != 0)
            {
                return _database.UpdateAsync(task);
            }
            else
            {
                return _database.InsertAsync(task);
            }
        }

        public Task<int> DeleteTaskAsync(tarea task)
        {
            return _database.DeleteAsync(task);
        }
    }

}