namespace SecondAssignment.Models;

public class Tasks
{
    public long TaskId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Deadline {  get; set; }
    public string TaskStatus {  get; set; }
    public User AssignedUser { get; set; } 
}