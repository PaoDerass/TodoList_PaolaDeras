using ToDoList.VistaModelo;

namespace TodoList_PaolaDeras
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            
            BindingContext = new VistaModelo(); 
        }
    }
}
