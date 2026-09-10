using CleanTodo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanTodo.Domain.DTOS
{
    public class UpdateTodoDto
    {        
        public string Title { get; set; }
        public bool IsCompleted { get; set; }

        public UpdateTodoDto() { }


        // Devrait être fait dans Mapping -> automapper.
        public UpdateTodoDto(Todo todo)
        {            
            Title = todo.Text;
            IsCompleted = todo.IsCompleted;
        }
    }
}
