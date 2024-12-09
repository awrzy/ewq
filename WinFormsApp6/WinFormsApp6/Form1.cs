using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace WinFormsApp6
{
    public partial class Form1 : Form
    {
        List<Data> orders = new List<Data>();

        private int _selectedIndex = 0;
        private int SelectedIndex
        {
            get => _selectedIndex;
            set
            {
                if (value == -1) value = 0;
                _selectedIndex = value;
            }
        }

        public Form1()
        {
            InitializeComponent();

            orders = new List<Data>();
            orders.Add(new Data() { OrderID = "1", Date = "9 декабря 2024 г.", Equipment = "Телевизор", ProblemDescription = "Не работает", Client = "Иванов Иван Иванович", Status = "В работе" });

            dataGridView1.Columns.Add("Order", "Заявка");
            dataGridView1.Columns.Add("Date", "Дата");
            dataGridView1.Columns.Add("Equipment", "Оборудование");
            dataGridView1.Columns.Add("ProblemDescription", "Описание проблемы");
            dataGridView1.Columns.Add("Client", "Клиент");
            dataGridView1.Columns.Add("Status", "Статус");

            for (int i = 0; i < orders.Count; i++)
            {
                dataGridView1.Rows.Add(orders[i].OrderID, orders[i].Date, orders[i].Equipment, orders[i].ProblemDescription, orders[i].Client, orders[i].Status);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Data order = new Data
            {
                OrderID = textBox1.Text,
                Date = dateTimePicker1.Text,
                Equipment = textBox3.Text,
                ProblemDescription = textBox4.Text,
                Client = textBox5.Text,
                Status = comboBox1.Text,
            };
            orders.Add(order);
            dataGridView1.Rows.Add(order.OrderID, order.Date, order.Equipment, order.ProblemDescription, order.Client, order.Status);
        }

        private void SetData(Data order)
        {
            textBox1.Text = order.OrderID;
            dateTimePicker1.Text = order.Date;
            textBox3.Text = order.Equipment;
            textBox4.Text = order.ProblemDescription;
            textBox5.Text = order.Client;
            comboBox1.Text = order.Status;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            orders.RemoveAt(SelectedIndex);
            dataGridView1.Rows.RemoveAt(SelectedIndex);
            SelectedIndex = 0;
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            Data order = orders[SelectedIndex];
            order.ProblemDescription = textBox4.Text;
            order.Status = comboBox1.Text;
            dataGridView1.Rows[SelectedIndex].Cells[3].Value = order.ProblemDescription;
            dataGridView1.Rows[SelectedIndex].Cells[5].Value = order.Status;
        }

        private void SelectRow()
        {
            if (dataGridView1.Rows.Count <= 0) return;

            SetData(orders[SelectedIndex]);
            dataGridView1.Rows[SelectedIndex].Selected = true;
        }
    }
}
