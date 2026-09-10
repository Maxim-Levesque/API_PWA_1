using CleanTodo.Domain.DTOS;
using CleanTodo.Domain.Interfaces.Repositories;

namespace CleanTodo.Application.UseCase;

public class DeleteTodoUseCase
{
    private readonly ITodoRepository _todoRepository;

    public DeleteTodoUseCase(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    public async Task<TodoDto?> Execute(Guid id)
    {
        var todo = await _todoRepository.Delete(id);
        return todo != null ? new TodoDto(todo) : null;
    }
}