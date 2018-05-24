using System;
using System.Windows.Forms;

namespace ScrumTable
{
    public partial class StoryDetail : Form
    {
        private readonly Story _story;
        private readonly Form1 _form1;

        public StoryDetail()
        {
            InitializeComponent();
        }

        public StoryDetail(Story story, Form1 form1)
        {
            InitializeComponent();
            _story = story;
            _form1 = form1;
            textBox1.Text = _story.Name;
            textBox2.Text = _story.Description;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                label3.Text = "All fields are necessary";
                return;
            }

            _story.Name = textBox1.Text;
            _story.Description = textBox2.Text;

            _form1.UpdateTable();
            _form1.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var taskAdd = new TaskAdd(_story, _form1);
            taskAdd.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _form1.Stories.Remove(_story);
            _form1.UpdateTable();
            _form1.Refresh();
            Close();
        }
    }
}
