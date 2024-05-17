using System.Collections.Generic;
using System.Threading.Tasks;
using SecondAssignment.Models;

namespace SecondAssignment.Servise;

public interface ITaskService
{
    Task<IEnumerable<Tasks >> GetTasksAsync(); // Получить список задач
    Task<Tasks> GetTaskByIdAsync(int taskId); // Получить задачу по идентификатору
    Task<Tasks> CreateTaskAsync(Tasks  task); // Создать новую задачу
    Task<Tasks> UpdateTaskAsync(int taskId, Tasks  task); // Обновить существующую задачу
    Task<bool> DeleteTaskAsync(int taskId); // Удалить задачу
}