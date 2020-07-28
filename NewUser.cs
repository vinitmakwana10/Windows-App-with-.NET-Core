using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace TextEditor
{
    public partial class NewUser : Form
    {
        public NewUser()
        {
            InitializeComponent();
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (NewUsername_Tb.Text == String.Empty || New_Password_Tb.Text == String.Empty || New_Password_Tb2.Text == String.Empty || New_FirstName_Tb.Text == String.Empty || New_LastName_Tb.Text == String.Empty || New_Dob_Picker.Value.ToString() == String.Empty || New_UserType_Cb.Text == String.Empty)
            {
                MessageBox.Show("Please enter All details", "Incomplete details", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                NewUsername_Tb.Clear(); New_Password_Tb.Clear(); New_Password_Tb2.Clear(); New_FirstName_Tb.Clear(); New_LastName_Tb.Clear();
            }
            else
            {
                string NewUsername = NewUsername_Tb.Text;
                string NewPassword = New_Password_Tb.Text;
                string NewFirstName = New_FirstName_Tb.Text;
                string NewLastName = New_LastName_Tb.Text;
                New_Dob_Picker.Format = DateTimePickerFormat.Custom;
                string Dob = New_Dob_Picker.Value.ToString("dd-MM-yyyy");
                string UserType = New_UserType_Cb.GetItemText(this.New_UserType_Cb.SelectedItem);
                using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(@"C:\Users\User\source\repos\TextEditor\TextEditor\bin\Debug\login.txt", true))
                {
                    file.WriteLine(NewUsername + "," + NewPassword + "," + UserType + "," + NewFirstName + "," + NewLastName + "," + Dob);
                }
                MessageBox.Show("New User Created", "New User Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
        private void New_Password_Tb2_TextChanged(object sender, EventArgs e)
        {
            if (New_Password_Tb2.Text == New_Password_Tb.Text)
            {
                Passoword_Label.ForeColor = Color.Green;
                Passoword_Label.Text = "Match";
            }
            else
            {
                Passoword_Label.ForeColor = Color.Red;
                Passoword_Label.Text = "No Match";
            }
        }
        private void label8_Click(object sender, EventArgs e)
        {
        }
        private void NewUser_Load(object sender, EventArgs e)
        {
        }
    }
}
