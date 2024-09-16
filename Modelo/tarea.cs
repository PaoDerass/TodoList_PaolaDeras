﻿
using SQLite;

namespace ToDoList.modelo
{ 
public class Tarea
{
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
    public string Titulo { get; set; }
    public string Descripcion { get; set; }
    public string Estado { get; set; }
    public bool Completada { get; set; }

}
}
