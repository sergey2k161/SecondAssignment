using SecondAssignment.Servise;
using Microsoft.EntityFrameworkCore;

namespace SecondAssignment.Models;

public class TaskService : ITaskService
{
    private readonly ApplicationDbContext _context;

    public TaskService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Tasks>> GetTasksAsync()
    {
        return await _context.Tasks.ToListAsync();
    }

    public async Task<Tasks> GetTaskByIdAsync(int taskId)
    {
        return await _context.Tasks.FindAsync(taskId);
    }

    public async Task<Tasks> CreateTaskAsync(Tasks task)
    {
        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();
        return task;
    }

    public async Task<Tasks> UpdateTaskAsync(int taskId, Tasks task)
    {
        _context.Entry(task).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return task;
    }

    public async Task<bool> DeleteTaskAsync(int taskId)
    {
        var task = await _context.Tasks.FindAsync(taskId);
        if (task == null)
        {
            return false;
        }

        _context.Tasks.Remove(task);
        await _context.SaveChangesAsync();
        return true;
    }    
}