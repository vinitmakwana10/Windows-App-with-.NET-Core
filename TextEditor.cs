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
    public partial class TextEditor : Form
    {
        public TextEditor()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            MessageBox.Show("User Logged Out", "Logged Out!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Form1 f1 = new Form1();
            f1.ShowDialog();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Title = "Open a File..";
            open.Filter = "txt files(*.txt)| *.txt|Rich text File (*.rtf)|*.rtf";
            if (open.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Clear();
                using (StreamReader sr = new StreamReader(open.FileName))
                {
                    richTextBox1.Rtf = sr.ReadToEnd();
                }
                CurrentFile = open.FileName;
            }
        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }
        public string UserName { get; set; }
        public string UserType { get; set; }
        private void TextEditor_Load(object sender, EventArgs e)
        {
            UserNameLabel.Text = "UserName: " + UserName;
            toolStripComboBox1.SelectedIndex = 0;
            if (UserType == "View")
            {
                richTextBox1.ReadOnly = true;
            }
            else
            {
                richTextBox1.ReadOnly = false;
            }
        }
        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            using (var stream = File.Create("Untitled.txt"))
            {

            }
            StreamReader sr = new StreamReader("Untitled.txt");
            richTextBox1.Rtf = sr.ReadToEnd();
            sr.Close();
            CurrentFile = "Untitled.txt"; richTextBox1.Clear();
        }
        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Title = "Open a File..";
            open.Filter = "txt files(*.txt)| *.txt|Rich text File (*.rtf)|*.rtf";
            if (open.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Clear();
                using (StreamReader sr = new StreamReader(open.FileName))
                {
                    richTextBox1.Rtf = sr.ReadToEnd();
                }
                CurrentFile = open.FileName;
            }
        }
        public string CurrentFile { get; set; }
        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            if (CurrentFile == "Untitled.txt")
            {
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.Title = "Save a File..";
                saveFile.Filter = "txt files(*.txt)| *.txt|Rich text File (*.rtf)|*.rtf";
                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter sw = new StreamWriter(saveFile.FileName);
                    sw.WriteLine(richTextBox1.Rtf);
                    sw.Close();
                    MessageBox.Show("File Saved", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                StreamWriter sw = new StreamWriter(CurrentFile);
                sw.WriteLine(richTextBox1.Rtf);
                sw.Close();
                MessageBox.Show("File Saved", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void printToolStripButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Title = "Save a File..";
            saveFile.Filter = "txt files(*.txt)| *.txt|Rich text File (*.rtf)|*.rtf";
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(saveFile.FileName);
                sw.WriteLine(richTextBox1.Rtf);
                sw.Close();
            }
        }
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var stream = File.Create("Untitled.txt"))
            {

            }
            StreamReader sr = new StreamReader("Untitled.txt");
            richTextBox1.Rtf = sr.ReadToEnd();
            sr.Close();
            CurrentFile = "Untitled.txt";
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CurrentFile == "Untitled.txt")
            {
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.Title = "Save a File..";
                saveFile.Filter = "txt files(*.txt)| *.txt|Rich text File (*.rtf)|*.rtf";
                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter sw = new StreamWriter(saveFile.FileName);
                    sw.WriteLine(richTextBox1.Rtf);
                    sw.Close();
                }
            }
            else
            {
                StreamWriter sw = new StreamWriter(CurrentFile);
                sw.WriteLine(richTextBox1.Rtf);
                sw.Close();
            }
            MessageBox.Show("File Saved", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Title = "Save a File..";
            saveFile.Filter = "txt files(*.txt)| *.txt|Rich text File (*.rtf)|*.rtf";
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(saveFile.FileName);
                sw.WriteLine(richTextBox1.Rtf);
                sw.Close();
            }
        }
        private void cutToolStripButton1_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }
        private void copyToolStripButton1_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }
        private void pasteToolStripButton1_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }
        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }
        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }
        private void cutToolStripButton_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font(this.Font, FontStyle.Bold);
        }
        private void copyToolStripButton_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font(this.Font, FontStyle.Italic);
        }
        private void pasteToolStripButton_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font(this.Font, FontStyle.Underline);
        }
        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {
            string FontSize = this.toolStripComboBox1.Text;
            float FontSize1 = float.Parse(FontSize);
            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily.Name, FontSize1, FontStyle.Regular);
        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About a1 = new About();
            a1.ShowDialog();
        }
    }
}



