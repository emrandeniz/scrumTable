using System.Collections.Generic;
using System.Drawing;

namespace ScrumTable
{
    public class Story
    {
        public string Description { get; set; }
        public string Name { get; set; }
        public List<Task> Tasks { get; set; }
        public Color BackgroundColor { get; set; }
    }
}
