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

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" | textBox2.Text == "" | textBox3.Text == "" | textBox4.Text == "" | textBox5.Text == "" | textBox6.Text == "")
            {
                MessageBox.Show("Заполните все данные", "Ошибка", MessageBoxButtons.OK);
            }
            else
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\test\test_work.mdf;Integrated Security=True;Connect Timeout=30");
                con.Open();

                SqlDataAdapter da = new SqlDataAdapter("INSERT INTO Telephone_directory (FIO,Doljnost,Podrazdel,Number_work,Number_private,Number_mob) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "');", con);
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                DataSet ds = new DataSet();
                da.Fill(ds, "Telephone_directory");
                this.telephone_directoryTableAdapter.Fill(this.test_workDataSet.telephone_directory);
                const string message = "Запись успешно добавлена. Добавить еще одну запись?";
                const string caption = "Добавление";
                var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // If the no button was pressed ...
                if (result == DialogResult.No)
                {
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox1.Visible = false; label1.Visible = false;
                    textBox2.Visible = false; label2.Visible = false;
                    textBox3.Visible = false; label3.Visible = false;
                    textBox4.Visible = false; label4.Visible = false;
                    textBox5.Visible = false; label5.Visible = false;
                    textBox6.Visible = false; label6.Visible = false;
                    button1.Visible = false;

                }
                else
                {
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
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
            textBox3.Visible = true; label3.Visible = true;
            textBox4.Visible = true; label4.Visible = true;
            textBox5.Visible = true; label5.Visible = true;
            textBox6.Visible = true; label6.Visible = true;
            button1.Visible = true;

        }

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
            textBox3.Visible = true; label3.Visible = true;
            textBox4.Visible = true; label4.Visible = true;
            textBox5.Visible = true; label5.Visible = true;
            textBox6.Visible = true; label6.Visible = true;
            button2.Visible = true;
            textBox1.Text = (dataGridView1.Rows[cel_nom].Cells[0].Value).ToString();
            textBox2.Text = (dataGridView1.Rows[cel_nom].Cells[1].Value).ToString();
            textBox3.Text = (dataGridView1.Rows[cel_nom].Cells[2].Value).ToString();
            textBox4.Text = (dataGridView1.Rows[cel_nom].Cells[3].Value).ToString();
            textBox5.Text = (dataGridView1.Rows[cel_nom].Cells[4].Value).ToString();
            textBox6.Text = (dataGridView1.Rows[cel_nom].Cells[5].Value).ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int cel_nom = dataGridView1.CurrentRow.Index;
            if (textBox1.Text == "" | textBox2.Text == "" | textBox3.Text == "" | textBox4.Text == "" | textBox5.Text == "" | textBox6.Text == "")
            {
                MessageBox.Show("Заполните все данные", "Ошибка", MessageBoxButtons.OK);
            }
            else
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\test\test_work.mdf;Integrated Security=True;Connect Timeout=30");
                con.Open();

                SqlDataAdapter da = new SqlDataAdapter("UPDATE Telephone_directory SET FIO='" + textBox1.Text + "',Doljnost='" + textBox2.Text + "',Podrazdel='" + textBox3.Text + "',Number_work='" + textBox4.Text + "',Number_private='" + textBox5.Text + "',Number_mob='" + textBox6.Text + "' WHERE FIO = '" + dataGridView1.Rows[cel_nom].Cells[0].Value + "';", con);
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                DataSet ds = new DataSet();
                da.Fill(ds, "Telephone_directory");
                this.telephone_directoryTableAdapter.Fill(this.test_workDataSet.telephone_directory);
                MessageBox.Show("Запись успешно изменена", "Изменение", MessageBoxButtons.OK);
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox1.Visible = false; label1.Visible = false;
                    textBox2.Visible = false; label2.Visible = false;
                    textBox3.Visible = false; label3.Visible = false;
                    textBox4.Visible = false; label4.Visible = false;
                    textBox5.Visible = false; label5.Visible = false;
                    textBox6.Visible = false; label6.Visible = false;
                    button2.Visible = false;
            }
        }
    }
}
