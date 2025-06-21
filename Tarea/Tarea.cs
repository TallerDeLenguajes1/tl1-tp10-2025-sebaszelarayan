
namespace EspacioTarea;

//Vercion mas simplificada de Tarea para que trabaje solo el json
public class Tarea
{
    public int userId { get; set; }
    public int id { get; set; }
    public string title { get; set; }
    public bool completed { get; set; }
}

/*
public class Tarea
{
    private int userId;
    private int id;
    private string title;
    private bool completed;

    public int UserId { get => userId; set => userId = value; }
    public int Id { get => id; set => id = value; }
    public string Title { get => title; set => title = value; }
    public bool Completed { get => completed; set => completed = value; }

    public Tarea(int userId, int id, string title, bool completed)
    {
        this.userId = userId;
        this.id = id;
        this.title = title;
        this.completed = completed;
    }
}*/