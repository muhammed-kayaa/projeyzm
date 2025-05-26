using System;
using System.Windows.Forms;
using WordApp.Data;
using WordApp.Models;
using WordApp.Services;

namespace WordApp
{
    class Program
    {
        [STAThread] // Ekle
        static void Main(string[] args)
        {
            Application.EnableVisualStyles(); // Ekle
            Application.SetCompatibleTextRenderingDefault(false); // Ekle
            Application.Run(new MainForm()); // MainForm adında bir form oluşturmalısınız
        }
    }

    public class MainForm : Form
    {
        private int wordCount = 10; // Varsayılan değer
        private Button btnSettings;

        public MainForm()
        {
            this.Text = "Main Form";
            this.Width = 800;
            this.Height = 600;
            this.AutoScaleMode = AutoScaleMode.None; // Ekle

            btnSettings = new Button();
            btnSettings.Text = "Ayarlar";
            btnSettings.Location = new System.Drawing.Point(20, 20);
            btnSettings.Visible = true;   // Ekle
            btnSettings.Enabled = true;   // Ekle
            btnSettings.Click += BtnSettings_Click;
            this.Controls.Add(btnSettings);
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            using (var settingsForm = new FormSettings(wordCount))
            {
                if (settingsForm.ShowDialog() == DialogResult.OK)
                {
                    wordCount = settingsForm.NewWordCount;
                    MessageBox.Show($"Yeni kelime sayısı: {wordCount}");
                }
            }
        }
    }

    public class FormSettings : Form
    {
        public int NewWordCount { get; private set; }
        TextBox txtWordCount;
        Button btnSave;

        public FormSettings(int currentValue)
        {
            this.Text = "Settings";
            this.Size = new System.Drawing.Size(250, 100);

            txtWordCount = new TextBox();
            txtWordCount.Text = currentValue.ToString();
            txtWordCount.Location = new System.Drawing.Point(15, 15);
            txtWordCount.Width = 100;
            this.Controls.Add(txtWordCount);

            btnSave = new Button();
            btnSave.Text = "Save";
            btnSave.Location = new System.Drawing.Point(20, 50);
            btnSave.Click += BtnSave_Click;
            this.Controls.Add(btnSave);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            int value;
            if (int.TryParse(txtWordCount.Text, out value) && value >= 1 && value <= 100)
            {
                NewWordCount = value;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Please enter a valid number between 1 and 100.");
            }
        }
    }
}

