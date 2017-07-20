using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "test_workDataSet.telephone_directory". При необходимости она может быть перемещена или удалена.
            this.telephone_directoryTableAdapter.Fill(this.test_workDataSet.telephone_directory);

        }

        //Добавление новой записи в таблицу
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" | textBox2.Text == "" | comboBox2.Text == "" | textBox4.Text == "" | textBox5.Text == "" | textBox6.Text == "")
            {
                MessageBox.Show("Заполните все данные", "Ошибка", MessageBoxButtons.OK); //проверка на корректность заполнения данных
            }
            else //если введено все корректно то добавляем
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\test\test_work.mdf;Integrated Security=True;Connect Timeout=30");
                con.Open();

                SqlDataAdapter da = new SqlDataAdapter("INSERT INTO Telephone_directory (FIO,Doljnost,Podrazdel,Number_work,Number_private,Number_mob) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + comboBox2.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "');", con);
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                DataSet ds = new DataSet();
                da.Fill(ds, "Telephone_directory");
                this.telephone_directoryTableAdapter.Fill(this.test_workDataSet.telephone_directory);
                const string message = "Запись успешно добавлена. Добавить еще одну запись?";
                const string caption = "Добавление";
                var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    textBox1.Text = "";
                    textBox2.Text = "";
                    comboBox2.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox1.Visible = false; label1.Visible = false;
                    textBox2.Visible = false; label2.Visible = false;
                    comboBox2.Visible = false; label3.Visible = false;
                    textBox4.Visible = false; label4.Visible = false;
                    textBox5.Visible = false; label5.Visible = false;
                    textBox6.Visible = false; label6.Visible = false;
                    button1.Visible = false;

                }
                else
                {
                    textBox1.Text = "";
                    textBox2.Text = "";
                    comboBox2.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                }
            }
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Visible = true; label1.Visible = true;
            textBox2.Visible = true; label2.Visible = true;
            comboBox2.Visible = true; label3.Visible = true;
            textBox4.Visible = true; label4.Visible = true;
            textBox5.Visible = true; label5.Visible = true;
            textBox6.Visible = true; label6.Visible = true;
            button1.Visible = true;

        }

        //удаление выбранной записи
        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int cel_nom = dataGridView1.CurrentRow.Index; 
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\test\test_work.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("DELETE FROM Telephone_directory WHERE FIO = '" + dataGridView1.Rows[cel_nom].Cells[0].Value + "';", con);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            DataSet ds = new DataSet();
            da.Fill(ds, "Telephone_directory");
            MessageBox.Show("Запись успешно удалена!", "Удаление", MessageBoxButtons.OK);
            this.telephone_directoryTableAdapter.Fill(this.test_workDataSet.telephone_directory);
        }

        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int cel_nom = dataGridView1.CurrentRow.Index;
            textBox1.Visible = true; label1.Visible = true;
            textBox2.Visible = true; label2.Visible = true;
            comboBox2.Visible = true; label3.Visible = true;
            textBox4.Visible = true; label4.Visible = true;
            textBox5.Visible = true; label5.Visible = true;
            textBox6.Visible = true; label6.Visible = true;
            button2.Visible = true;
            textBox1.Text = (dataGridView1.Rows[cel_nom].Cells[0].Value).ToString();
            textBox2.Text = (dataGridView1.Rows[cel_nom].Cells[1].Value).ToString();
            comboBox2.Text = (dataGridView1.Rows[cel_nom].Cells[2].Value).ToString();
            textBox4.Text = (dataGridView1.Rows[cel_nom].Cells[3].Value).ToString();
            textBox5.Text = (dataGridView1.Rows[cel_nom].Cells[4].Value).ToString();
            textBox6.Text = (dataGridView1.Rows[cel_nom].Cells[5].Value).ToString();

        }

        //редактирование изменение выбранной записи
        private void button2_Click(object sender, EventArgs e)
        {
            int cel_nom = dataGridView1.CurrentRow.Index;
            if (textBox1.Text == "" | textBox2.Text == "" | comboBox2.Text == "" | textBox4.Text == "" | textBox5.Text == "" | textBox6.Text == "")
            {
                MessageBox.Show("Заполните все данные", "Ошибка", MessageBoxButtons.OK);
            }
            else
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\test\test_work.mdf;Integrated Security=True;Connect Timeout=30");
                con.Open();

                SqlDataAdapter da = new SqlDataAdapter("UPDATE Telephone_directory SET FIO='" + textBox1.Text + "',Doljnost='" + textBox2.Text + "',Podrazdel='" + comboBox2.Text + "',Number_work='" + textBox4.Text + "',Number_private='" + textBox5.Text + "',Number_mob='" + textBox6.Text + "' WHERE FIO = '" + dataGridView1.Rows[cel_nom].Cells[0].Value + "';", con);
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                DataSet ds = new DataSet();
                da.Fill(ds, "Telephone_directory");
                this.telephone_directoryTableAdapter.Fill(this.test_workDataSet.telephone_directory);
                MessageBox.Show("Запись успешно изменена", "Изменение", MessageBoxButtons.OK);
                    textBox1.Text = "";
                    textBox2.Text = "";
                    comboBox2.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox1.Visible = false; label1.Visible = false;
                    textBox2.Visible = false; label2.Visible = false;
                    comboBox2.Visible = false; label3.Visible = false;
                    textBox4.Visible = false; label4.Visible = false;
                    textBox5.Visible = false; label5.Visible = false;
                    textBox6.Visible = false; label6.Visible = false;
                    button2.Visible = false;
            }
        }

        private void поискПоФИОToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label7.Visible = true;
            textBox7.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
        }

        //поис по ФИО сотрудника
        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\test\test_work.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Telephone_directory WHERE (FIO LIKE '%" + textBox7.Text + "%');", con);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            DataSet ds = new DataSet();
            da.Fill(ds, "Telephone_directory");
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox7.Text = "";
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\test\test_work.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Telephone_directory;", con);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            DataSet ds = new DataSet();
            da.Fill(ds, "Telephone_directory");
            dataGridView1.DataSource = ds.Tables[0];

        }

        //выборка по подразделениям
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\test\test_work.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Telephone_directory WHERE Podrazdel = '"+ comboBox1.Text + "';", con);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            DataSet ds = new DataSet();
            da.Fill(ds, "Telephone_directory");
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button5_Click(object sender, EventArgs e)
        {
            comboBox1.Text = "";
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\test\test_work.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Telephone_directory;", con);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            DataSet ds = new DataSet();
            da.Fill(ds, "Telephone_directory");
            dataGridView1.DataSource = ds.Tables[0];
        }
    }
}
