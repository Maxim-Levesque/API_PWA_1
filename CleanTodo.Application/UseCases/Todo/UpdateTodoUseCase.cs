using CleanTodo.Domain.DTOS;
using CleanTodo.Domain.Entities;
using CleanTodo.Domain.Interfaces.Repositories;
using System.ComponentModel.DataAnnotations;
using FluentValidation.Results;
using FluentValidation;

namespace CleanTodo.Application.UseCase;

public class UpdateTodoUseCase
{
    private readonly ITodoRepository _todoRepository;
    private readonly IValidator<UpdateTodoDto> _validator;

    public UpdateTodoUseCase(ITodoRepository todoRepository, IValidator<UpdateTodoDto> validator)
    {
        _todoRepository = todoRepository;
        _validator = validator;
    }

    public async Task<TodoDto?> Execute(Guid id, UpdateTodoDto updateTodoDto)
    {        
        FluentValidation.Results.ValidationResult validationResult = await _validator.ValidateAsync(updateTodoDto);
        if (!validationResult.IsValid)
        {
            throw new FluentValidation.ValidationException(validationResult.Errors);
        }
        
        var existing = await _todoRepository.FindById(id);
        if (existing == null)
            return null;
       
        existing.Text = updateTodoDto.Title;
        

        var updated = await _todoRepository.Update(existing);
        if (updated == null)
            return null;

        return new TodoDto(updated);
    }

}