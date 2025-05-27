using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using WordApp.Data;
using WordApp.Models;
using WordApp.Services;

namespace WordApp
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Giriş ekranını göster
            using (var loginForm = new LoginForm())
            {
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    Application.Run(new MainForm(loginForm.LoggedInUser));
                }
            }
        }
    }

    // Giriş Formu
    public class LoginForm : Form
    {
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button btnLogin;
        private Button btnRegister;
        private Label lblError;
        public User LoggedInUser { get; private set; }

        public LoginForm()
        {
            this.Text = "Giriş Yap";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new System.Drawing.Size(350, 250);
            this.BackColor = System.Drawing.Color.White;

            var lblTitle = new Label
            {
                Text = "WordApp Giriş",
                Font = new System.Drawing.Font("Segoe UI", 16, System.Drawing.FontStyle.Bold),
                AutoSize = false,
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 50
            };
            this.Controls.Add(lblTitle);

            var lblUsername = new Label { Text = "Kullanıcı Adı:", Left = 40, Top = 70, Width = 100 };
            txtUsername = new TextBox { Left = 150, Top = 65, Width = 140 };

            var lblPassword = new Label { Text = "Şifre:", Left = 40, Top = 110, Width = 100 };
            txtPassword = new TextBox { Left = 150, Top = 105, Width = 140, PasswordChar = '●' };

            btnLogin = new Button
            {
                Text = "Giriş Yap",
                Left = 150,
                Top = 150,
                Width = 140,
                BackColor = System.Drawing.Color.FromArgb(0, 120, 215),
                ForeColor = System.Drawing.Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnLogin.Click += BtnLogin_Click;

            btnRegister = new Button
            {
                Text = "Kayıt Ol",
                Left = 40,
                Top = 150,
                Width = 100,
                BackColor = System.Drawing.Color.LightGray
            };
            btnRegister.Click += BtnRegister_Click;

            lblError = new Label
            {
                ForeColor = System.Drawing.Color.Red,
                Left = 40,
                Top = 185,
                Width = 250,
                Height = 30,
                Visible = false
            };

            var lblRegisterInfo = new Label
            {
                Text = "Bir hesabın yok mu?",
                Left = 40,
                Top = 185,
                Width = 120,
                ForeColor = System.Drawing.Color.Black
            };
            this.Controls.Add(lblRegisterInfo);

            btnRegister.Left = 170; // Butonu açıklamanın yanına al
            btnRegister.Top = 180;
            btnRegister.Width = 120;

            lblError.Top = 220;

            this.Controls.Add(lblUsername);
            this.Controls.Add(txtUsername);
            this.Controls.Add(lblPassword);
            this.Controls.Add(txtPassword);
            this.Controls.Add(btnLogin);
            this.Controls.Add(btnRegister);
            this.Controls.Add(lblError);
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            // Basit örnek: Veritabanından kullanıcıyı kontrol et
            using (var db = new AppDbContext())
            {

            var user = db.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
                if (user != null)
                {
                    LoggedInUser = user;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    lblError.Text = "Kullanıcı adı veya şifre hatalı!";
                    lblError.Visible = true;
                }
            }
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            using (var registerForm = new RegisterForm())
            {
                registerForm.ShowDialog();
            }
        }
    }

    // Ana Form
    public class MainForm : Form
    {
        private User currentUser;
        private Label lblWelcome;
        private Button btnSettings;

        public MainForm(User user)
        {
            currentUser = user;
            this.Text = "WordApp Ana Ekran";
            this.Size = new System.Drawing.Size(900, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = System.Drawing.Color.FromArgb(245, 245, 255);

            lblWelcome = new Label
            {
                Text = $"Hoşgeldin, {currentUser.Username}!",
                Font = new System.Drawing.Font("Segoe UI", 18, System.Drawing.FontStyle.Bold),
                AutoSize = true,
                Top = 30,
                Left = 30
            };
            this.Controls.Add(lblWelcome);

            btnSettings = new Button
            {
                Text = "Ayarlar",
                Left = 30,
                Top = 80,
                Width = 120,
                Height = 40,
                BackColor = System.Drawing.Color.FromArgb(0, 120, 215),
                ForeColor = System.Drawing.Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnSettings.Click += BtnSettings_Click;
            this.Controls.Add(btnSettings);

            this.FormClosed += (s, e) => Application.Exit();

            // Buraya ana ekran için ek tasarım ve kontroller ekleyebilirsiniz
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            using (var settingsForm = new FormSettings())
            {
                settingsForm.ShowDialog();
            }
        }
    }

    // Ayarlar Formu (örnek)
    public class FormSettings : Form
    {
        public FormSettings()
        {
            this.Text = "Ayarlar";
            this.Size = new System.Drawing.Size(300, 200);
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = System.Drawing.Color.White;

            var lblInfo = new Label
            {
                Text = "Ayarlar burada olacak.",
                Dock = DockStyle.Fill,
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            };
            this.Controls.Add(lblInfo);
        }
    }
}

