using System;
using System.Linq;
using System.Windows.Forms;
using WordApp.Models;
using WordApp.Services;
using WordApp.Data;

public class RegisterForm : Form
{
    private TextBox txtUsername;
    private TextBox txtPassword;
    private Button btnRegister;
    private Label lblError;

    public RegisterForm()
    {
        this.Text = "Kayıt Ol";
        this.Size = new System.Drawing.Size(300, 220);
        this.StartPosition = FormStartPosition.CenterParent;

        var lblUsername = new Label { Text = "Kullanıcı Adı:", Left = 30, Top = 30, Width = 80 };
        txtUsername = new TextBox { Left = 120, Top = 25, Width = 120 };

        var lblPassword = new Label { Text = "Şifre:", Left = 30, Top = 70, Width = 80 };
        txtPassword = new TextBox { Left = 120, Top = 65, Width = 120, PasswordChar = '●' };

        btnRegister = new Button
        {
            Text = "Kayıt Ol",
            Left = 120,
            Top = 110,
            Width = 120
        };
        btnRegister.Click += BtnRegister_Click;

        lblError = new Label
        {
            ForeColor = System.Drawing.Color.Red,
            Left = 30,
            Top = 150,
            Width = 210,
            Height = 30,
            Visible = false
        };

        this.Controls.Add(lblUsername);
        this.Controls.Add(txtUsername);
        this.Controls.Add(lblPassword);
        this.Controls.Add(txtPassword);
        this.Controls.Add(btnRegister);
        this.Controls.Add(lblError);
    }

    private void BtnRegister_Click(object sender, EventArgs e)
    {
        string username = txtUsername.Text.Trim();
        string password = txtPassword.Text.Trim();

        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            lblError.Text = "Kullanıcı adı ve şifre zorunlu!";
            lblError.Visible = true;
            return;
        }

        try
        {
            using (var db = new AppDbContext())
            {
                // Kullanıcı zaten var mı kontrol et
                var existingUser = db.Users.FirstOrDefault(u => u.Username == username);
                if (existingUser != null)
                {
                    lblError.Text = "Bu kullanıcı adı zaten kayıtlı!";
                    lblError.Visible = true;
                    return;
                }

                var userService = new UserService(db);
                userService.CreateUser(new User { Username = username, Password = password });
            }
            MessageBox.Show("Kayıt başarılı! Giriş ekranına dönebilirsiniz.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
            lblError.Visible = true;
        }
    }
}