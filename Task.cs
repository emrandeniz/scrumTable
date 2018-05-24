using System;

namespace ScrumTable
{
    public class Task
    {
        public string Name { get; set; }
        public string Assignee { get; set; }
        public DateTime DueDate { get; set; }
        public Status Status { get; set; }
    }
}
