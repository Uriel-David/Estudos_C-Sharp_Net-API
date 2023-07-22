using System.ComponentModel;

namespace ToDoList.Enums
{
    public enum TaskStatus
    {
        [Description("To Do")]
        ToDoList = 1,
        [Description("Ongoing")]
        Ongoing = 2,
        [Description("Done")]
        Done = 3,
    }
}
