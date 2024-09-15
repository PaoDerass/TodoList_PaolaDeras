using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using TodoList.Modelo;
using Xamarin.Forms;


namespace TodoList.VistaModelo
{
    public class VistaModelo : BindableObject
    {
        public ObservableCollection<Task> Tasks { get; set; }

        public ICommand AddTaskCommand { get; }

        public VistaModelo()
        {
            Tasks = new ObservableCollection<Task>();
            AddTaskCommand = new Command(async () => await AddTask());

            LoadTasks();
        }

        private async void LoadTasks()
        {
            var tasks = await App.Database.GetTasksAsync();
            foreach (var task in tasks)
            {
                Tasks.Add(Tarea);
            }
        }

        private async Task AddTask()
        {
            var newTask = new Task { Title = "Crear nueva tarea", Description = "Descripción", Status = "Por hacer", IsCompleted = false };
            await App.Database.SaveTaskAsync(newTask);
            Tasks.Add(newTask);
        }

        public async Task UpdateTaskAsync(Task Tarea)
        {
            await App.Database.SaveTaskAsync(Tarea);
        }
    }
}
