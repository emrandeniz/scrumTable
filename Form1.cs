using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ScrumTable
{
    public partial class Form1 : Form
    {
        public List<Story> Stories { get; set; }

        public Form1()
        {
            Stories = new List<Story>();
            InitializeComponent();
        }

       
        private void button1_Click(object sender, EventArgs e)
        {
            var storyAddForm = new StoryAdd(this);
            storyAddForm.Show();
        }

        public void UpdateTable()
        {
            ClearTable();
            foreach (var story in Stories)
            {
                tableLayoutPanel.RowCount++;
                tableLayoutPanel.RowStyles.Insert(0, new RowStyle(SizeType.Percent, 50F));

                foreach (Control c in tableLayoutPanel.Controls)
                {
                    tableLayoutPanel.SetRow(c, tableLayoutPanel.GetRow(c) + 1);
                }

                var label = new Label()
                {
                    Text = "Name:  " + story.Name + "\n\n" + "Description:  " + story.Description,
                    AutoSize = true,
                    Anchor = AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Top,
                    TextAlign = ContentAlignment.MiddleCenter,
                    BackColor = story.BackgroundColor
                };

                label.Click += (sender, args) =>
                {
                    var storyDetail = new StoryDetail(story, this);
                    storyDetail.Show();
                };
                tableLayoutPanel.Controls.Add(label, 0, 0);

                InsertTableForStatus(story, Status.NotStarted, 1);
                InsertTableForStatus(story, Status.InProgress, 2);
                InsertTableForStatus(story, Status.Done, 3);
            }
        }

        private void ClearTable()
        {
            tableLayoutPanel.Controls.Clear();
            tableLayoutPanel.RowStyles.Clear();
            tableLayoutPanel.RowCount = 0;

            tableLayoutPanel.Controls.Add(button1, 0, 0);
            tableLayoutPanel.RowCount++;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
        }

        private void InsertTableForStatus(Story story, Status status, int index)
        {
            var tasks = story.Tasks.Where(x => x.Status == status).ToList();
            var tempTableLayoutPanel = CreateEmptyTable(story, status.ToString(), index);

            foreach (var task in tasks)
            {
                tempTableLayoutPanel.RowCount++;
                tempTableLayoutPanel.RowStyles.Insert(0,
                    new RowStyle(SizeType.Percent, 50F));

                foreach (Control c in tempTableLayoutPanel.Controls)
                {
                    tempTableLayoutPanel.SetRow(c, tempTableLayoutPanel.GetRow(c) + 1);
                }

                var label = new Label()
                {
                    Text = task.Name,
                    BackColor = story.BackgroundColor
                };

                label.Click += (sender, args) =>
                {
                    var taskDetail = new TaskDetail(task, story, this);
                    taskDetail.Show();
                };

                tempTableLayoutPanel.Controls.Add(label, 0, 0);
            }

            tableLayoutPanel.Controls.Add(tempTableLayoutPanel, index, 0);
        }

        private TableLayoutPanel CreateEmptyTable(Story story, string state, int index)
        {
            var layoutPanel = new TableLayoutPanel
            {
                AutoSize = true,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Single,
                ColumnCount = 1
            };

            switch (index)
            {
                case 1:
                    layoutPanel.ColumnCount = 1;
                    layoutPanel.ColumnStyles.Add(
                        new ColumnStyle(SizeType.Percent, 50F));
                    layoutPanel.Location = new Point(258, 4);
                    layoutPanel.Name = "tableLayoutPanel1" + story.Name;
                    layoutPanel.RowCount = 0;
                    layoutPanel.Size = new Size(247, 19);
                    layoutPanel.TabIndex = 1;
                    break;
                case 2:
                    layoutPanel.ColumnCount = 1;
                    layoutPanel.ColumnStyles.Add(
                        new ColumnStyle(SizeType.Percent, 50F));
                    layoutPanel.Location = new Point(512, 4);
                    layoutPanel.Name = "tableLayoutPanel2" + story.Name;
                    layoutPanel.Size = new Size(247, 19);
                    layoutPanel.TabIndex = 2;
                    break;
                case 3:
                    layoutPanel.ColumnCount = 1;
                    layoutPanel.ColumnStyles.Add(
                        new ColumnStyle(SizeType.Percent, 50F));
                    layoutPanel.Location = new Point(772, 4);
                    layoutPanel.Name = "tableLayoutPanel3" + story.Name;
                    layoutPanel.Size = new Size(240, 19);
                    layoutPanel.TabIndex = 3;
                    break;
            }

            return layoutPanel;
        }
    }
}