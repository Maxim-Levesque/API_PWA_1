using System;
using System.Threading.Tasks;
using CleanTodo.Domain.DTOS;
using CleanTodo.Domain.Entities;
using CleanTodo.Domain.Interfaces.Repositories;
using FluentValidation;
using System.ComponentModel.DataAnnotations;
using FluentValidation.Results;

namespace CleanTodo.Application.UseCase;

public class CreateTodoUseCase
{
    private readonly ITodoRepository _todoRepository;
    private readonly IValidator<CreateTodoDto> _validator;

    public CreateTodoUseCase(ITodoRepository todoRepository, IValidator<CreateTodoDto> validator)
    {
        _todoRepository = todoRepository;
        _validator = validator;
    }

    public async Task<TodoDto> Execute(CreateTodoDto createTodoDto)
    {
        FluentValidation.Results.ValidationResult validationResult = await _validator.ValidateAsync(createTodoDto);
        if (!validationResult.IsValid)
        {
            throw new FluentValidation.ValidationException(validationResult.Errors);
        }

        var todo = new Todo(createTodoDto.Title);
        var created = await _todoRepository.Add(todo);
        return new TodoDto(created);
    }
}