using Microsoft.AspNetCore.Mvc;
using SecondAssignment.Models;
using System;
using Microsoft.EntityFrameworkCore.Migrations;
using SecondAssignment.Servise;

[ApiController]
[Route("[controller]")]
public class TaskController : Controller
{
    private readonly ITaskService _taskService;

    public TaskController(ITaskService taskService)
    {
        _taskService = taskService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Tasks>> GetTaskById(int id)
    {
        var task = await _taskService.GetTaskByIdAsync(id);
        if (task == null)
        {
            return NotFound();
        }

        return task;
    }

    [HttpPost]
    public async Task<ActionResult<Tasks>> CreateTask(Tasks task)
    {
        var createdTask = await _taskService.CreateTaskAsync(task);
        return CreatedAtAction(nameof(GetTaskById), new { id = createdTask.TaskId }, createdTask);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTask(int id, Tasks task)
    {
        if (id != task.TaskId)
        {
            return BadRequest();
        }

        var updatedTask = await _taskService.UpdateTaskAsync(id, task);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTask(int id)
    {
        var task = await _taskService.GetTaskByIdAsync(id);
        if (task == null)
        {
            return NotFound();
        }

        await _taskService.DeleteTaskAsync(id);

        return NoContent();
    }
}