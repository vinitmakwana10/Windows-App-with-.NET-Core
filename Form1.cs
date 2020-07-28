using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace TextEditor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string UserName = UserName_Tb.Text;
            string Password = Password_Tb.Text;
            bool userFound = false;
            string[] lines = System.IO.File.ReadAllLines("login.txt");
            string[] splits = new string[] { };
            File.Create("Users.txt").Close();
            foreach (string set in lines)
            {
                splits = set.Split(',');
                string UserName1 = splits[0];
                string Password1 = splits[1];
                string UserType = splits[2];
                File.AppendAllText("Users.txt", UserName1 + "|" + Password1 + "|" + UserType + Environment.NewLine);
                if (UserName == UserName1 && Password == Password1)
                {
                    this.Hide();
                    TextEditor t1 = new TextEditor();
                    userFound = true;
                    UserName_Tb.Clear();
                    Password_Tb.Clear();
                    t1.UserName = UserName1;
                    t1.UserType = UserType;
                    t1.ShowDialog();
                    break;
                }
            }
            if (userFound == false)
            {
                UserName_Tb.Clear();
                Password_Tb.Clear();
                MessageBox.Show("Incorrect Credentials", "User Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            NewUser n1 = new NewUser();
            n1.ShowDialog();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}
