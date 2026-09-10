using CleanTodo.Domain.DTOS;
using FluentValidation;

namespace CleanTodo.Application.Validators;

// Valide automatiquement UpdateTodoDto quand il est créé dans le controller
// Validator ci-dessous
public class UpdateTodoValidation : AbstractValidator<UpdateTodoDto>
{
    public UpdateTodoValidation()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(200);
    }
}