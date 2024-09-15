using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using ToDoList.modelo;
using Microsoft.Maui.Controls;
using TodoList_PaolaDeras;


namespace ToDoList.VistaModelo
{
    public class VistaModelo : BindableObject
    {
        public ObservableCollection<Tarea> Tasks { get; set; }

        public ICommand AddTaskCommand { get; }

        public VistaModelo()
        {
            Tasks = new ObservableCollection<Tarea>();
            AddTaskCommand = new Command(async () => await AddTask());

            LoadTasks();
        }

        private async void LoadTasks()
        {
            var tasks = await App.Database.GetTasksAsync();
            foreach (var task in tasks)
            {
                Tasks.Add(task);
            }
        }

        private async Task AddTask()
        {
            var newTask = new Tarea { Titulo = "Crear nueva tarea", Descripcion = "Descripción", Estado = "Por hacer", Completada = false };
            await App.Database.SaveTaskAsync(newTask);
            Tasks.Add(newTask);
        }

        public async Task UpdateTaskAsync(Tarea tarea)
        {
            await App.Database.SaveTaskAsync(tarea);
        }
    }
}
