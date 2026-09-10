using CleanTodo.Domain.Entities;

namespace CleanTodo.Domain.DTOS;

public class TodoDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime Date { get; set; }

    public TodoDto() { }


    // Devrait être fait dans Mapping -> automapper.
    public TodoDto(Todo todo)
    {
        Id = todo.Id;
        Title = todo.Text;
        Date = todo.Date;
        IsCompleted = todo.IsCompleted;
    }
}
