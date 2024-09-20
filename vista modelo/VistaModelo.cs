using System.Collections.ObjectModel;
using System.Linq;
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

        private string _nuevoTituloTarea;
        public string NuevoTituloTarea
        {
            get => _nuevoTituloTarea;
            set
            {
                _nuevoTituloTarea = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddTaskCommand { get; }
        public ICommand UpdateTaskCommand { get; }
        public ICommand DeleteSelectedTasksCommand { get; }

        public VistaModelo()
        {
            Tasks = new ObservableCollection<Tarea>();
            AddTaskCommand = new Command(async () => await AddTask());
            UpdateTaskCommand = new Command<Tarea>(async (task) => await UpdateTaskAsync(task));
            DeleteSelectedTasksCommand = new Command(async () => await DeleteSelectedTasks());

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
            if (!string.IsNullOrWhiteSpace(NuevoTituloTarea))
            {
                var newTask = new Tarea
                {
                    Titulo = NuevoTituloTarea,
                    Descripcion = "Descripción",
                    Estado = "Por hacer",
                    Completada = false
                };

                await App.Database.SaveTaskAsync(newTask);
                Tasks.Add(newTask);
                NuevoTituloTarea = string.Empty;
            }
        }

        public async Task UpdateTaskAsync(Tarea task)
        {
            if (task != null)
            {
                await App.Database.SaveTaskAsync(task);
                await Application.Current.MainPage.DisplayAlert("Exito", "Tarea guardada con exito.", "Listo");

            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "No se ha seleccionado ninguna tarea para actualizar.", "Listo");
            }
        }

        private async Task DeleteSelectedTasks()
        {
            var tasksToDelete = Tasks.Where(t => t.Completada).ToList();

            foreach (var task in tasksToDelete)
            {
                await App.Database.DeleteTaskAsync(task);
                Tasks.Remove(task);
            }
        }
    }
}
