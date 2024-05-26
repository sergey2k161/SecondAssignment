namespace SecondAssignment.Models;
using System.ComponentModel.DataAnnotations;
public class Tasks
{
    [Key]
    public int TaskId { get; set; }
    
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Deadline {  get; set; }
    public string TaskStatus {  get; set; }
    public User AssignedUser { get; set; } 
}