using System.IO;
using ToDoList.Data;
using Xamarin.Essentials;

namespace TodoList_PaolaDeras
{
    public partial class App : Application
    {
        static TaskDatabase database;

        public static TaskDatabase Database
        {
            get
            {
                if (database == null)
                {
                    string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Tasks.db3");
                    database = new TaskDatabase(dbPath);
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();
        }
    }
}
