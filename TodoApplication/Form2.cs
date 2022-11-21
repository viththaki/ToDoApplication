using System;
using System.ComponentModel;
using System.Data;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Net.Mime.MediaTypeNames;



namespace TodoApplication
{
    public partial class Form2 : Form
    {
        string text = string.Empty;
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var parts = textBox1.Text.Split(',');
            checkedListBox1.Items.Clear();
            checkedListBox1.Items.AddRange(parts);


        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=F:\\C# Projects\\TodoApplication\\Database.mdf;Integrated Security=True");
            con.Open();

            if (checkedListBox1.Items.Count > 0)
            {
                text = checkedListBox1.SelectedItems[0].ToString();
            }
            string cmdf = "DELETE FROM ListViewItems WHERE Listitems = '" + text + "'";
            SqlCommand commandDelete = new SqlCommand(cmdf, con);
            commandDelete.ExecuteNonQuery();
            con.Close();
            
            MessageBox.Show("Succussfull deleted information");
            textBox1.Text = "";
            checkedListBox1.Items.RemoveAt(checkedListBox1.Items.IndexOf(checkedListBox1.SelectedItems[0]));
            while (checkedListBox1.SelectedItems.Count > 0)
            {
                label4.Text = "done";
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= checkedListBox1.Items.Count - 1; i++)
            {
                SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=F:\\C# Projects\\TodoApplication\\Database.mdf;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("INSERT INTO ListViewItems (Listitems,ischecked) VALUES (@Listitems,@ischecked)", conn);
                cmd.Parameters.AddWithValue("Listitems", checkedListBox1.Items[i]);
                cmd.Parameters.AddWithValue("ischecked", checkedListBox1.GetItemCheckState(i));
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            MessageBox.Show("Information successfully saved");



        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form newform = new Form1();
            this.Hide();
            newform.ShowDialog();
            this.Show();
        }
    }
}
