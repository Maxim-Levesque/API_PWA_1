using CleanTodo.Domain.Entities;
using CleanTodo.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

public class TodoRepository : ITodoRepository
{
    private readonly AppDbContext _context;

    public TodoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Todo>> GetAll()
    {
        return await _context.Todos.ToListAsync();
    }

    public async Task<Todo> Add(Todo todo)
    {
        EntityEntry<Todo> newTodo = await _context.Todos.AddAsync(todo); // appelle la méthode AddAsync
        await _context.SaveChangesAsync(); // sauvegarde les changements dans la base de données
        return newTodo.Entity; // retourne l'entité ajoutée.
    }

    public async Task<Todo?> Update(Todo todo)
    {        
        var existingTodo = await _context.Todos.FindAsync(todo.Id);
        if (existingTodo == null)
        {
            return null;
        }

        existingTodo.Text = todo.Text;
        existingTodo.IsCompleted = todo.IsCompleted;

        await _context.SaveChangesAsync();
        return existingTodo;
    }

    public async Task<Todo?> Delete(Guid id)
    {
        var todo = await _context.Todos.FindAsync(id);
        if (todo == null)
        {
            return null;
        }
        _context.Todos.Remove(todo);
        await _context.SaveChangesAsync();
        return todo;
    }

    public async Task<Todo?> FindById(Guid id)
    {
        return await _context.Todos
            .Where(x => x.Id == id)
            .SingleOrDefaultAsync();
    }
}
