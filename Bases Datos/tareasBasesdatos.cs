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
            _database.CreateTableAsync<Tarea>().Wait();
        }

        public Task<List<Tarea>> GetTasksAsync()
        {
            return _database.Table<Tarea>().ToListAsync();
        }

        public Task<int> SaveTaskAsync(Tarea task)
        {
            if (task.Id != 0)
            {
                return _database.UpdateAsync(task);
            }
            else
            {
                return _database.InsertAsync(task);
            }
        }

        public Task<int> DeleteTaskAsync(Tarea task)
        {
            return _database.DeleteAsync(task);
        }

    
    }

}