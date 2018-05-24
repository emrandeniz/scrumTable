using System;
using System.Windows.Forms;

namespace ScrumTable
{
    public partial class TaskDetail : Form
    {
        private readonly Task _task;
        private readonly Story _story;
        private readonly Form1 _form1;

        public TaskDetail()
        {
            InitializeComponent();
        }

        public TaskDetail(Task task, Story story, Form1 form1)
        {
            InitializeComponent();
            _task = task;
            _story = story;
            _form1 = form1;
            textBox1.Text = task.Name;
            textBox2.Text = task.Assignee;
            comboBox1.DataSource = Enum.GetValues(typeof(Status));
            comboBox1.SelectedIndex = (int) task.Status;
        }

        private void TaskDetail_Load(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _story.Tasks.Remove(_task);
            _form1.UpdateTable();
            _form1.Refresh();
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                label5.Text = "All fields are necessary";
                return;
            }

            Status status;
            Enum.TryParse<Status>(comboBox1.SelectedValue.ToString(), out status);

            _task.Name = textBox1.Text;
            _task.Status = status;
            _task.Assignee = textBox2.Text;
            _task.DueDate = dateTimePicker1.Value;

            _form1.UpdateTable();
            _form1.Refresh();
        }
    }
}