using System;
using System.Threading.Tasks;
using CleanTodo.Domain.DTOS;
using CleanTodo.Domain.Entities;
using CleanTodo.Domain.Interfaces.Repositories;


namespace CleanTodo.Application.UseCase;

public class ToggleTodoCompleteStatusUseCase
{
    private readonly ITodoRepository _todoRepository;    

    public ToggleTodoCompleteStatusUseCase(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;        
    }

    public async Task<TodoDto> Execute(Guid id)
    {
        Todo? todo = await _todoRepository.FindById(id);
        if (todo == null)
        {
            throw new Exception($"Todo with id {id} not found.");
        }
        todo.ToggleCompleteStatus();
        var updatedTodo = await _todoRepository.Update(todo);
        return new TodoDto(updatedTodo);
    }
}