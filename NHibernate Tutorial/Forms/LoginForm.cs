using System;
using System.Windows.Forms;

namespace NHibernate_Tutorial.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void bOk_Click(object sender, EventArgs e)
        {
            if (tUser.Text == string.Empty)
            {
                MessageBox.Show("Informe o login do usuário");
                return;
            }
            if (tPassword.Text == string.Empty)
            {
                MessageBox.Show("Informe a senha do usuário");
                return;
            }

            try
            {
                Repository.UserRepository userRepo = new Repository.UserRepository();

                if ((userRepo.ValidateAcess(tUser.Text, tPassword.Text)))
                {
                    this.Hide();
                    MainForm MainForm = new MainForm();
                    MainForm.Show();
                }
                else
                {
                    MessageBox.Show("Login e/ou Senha inválidos", "Login Inválido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao acessar o sistema " + Environment.NewLine +  ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
