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

        public async Task<int> SaveTaskAsync(Tarea task)
        {
            try
            {
                if (task.Id != 0)
                {
                    return await _database.UpdateAsync(task);
                }
                else
                {
                    return await _database.InsertAsync(task);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"No se pudo guradar la tarea: {ex.Message}");
                return 0;
            }
        }

        public Task<int> DeleteTaskAsync(Tarea task)
        {
            return _database.DeleteAsync(task);
        }
    }
}
