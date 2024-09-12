
using SQLite;

namespace ToDoList.modelo
{ 
public class tarea
{
    public int id { get; set; }
    public string titulo { get; set; }
    public string descripcion { get; set; }
    public string status { get; set; }
    public bool Completada { get; set; }

}
}
