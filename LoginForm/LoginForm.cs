using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginForm
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                using (SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True"))
                {
                    string query = "SELECT * FROM Login WHERE Username ='" + txtUserName.Text.Trim() + "'AND Password = '" + txtPassword.Text.Trim() + "'";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    if (dt.Rows.Count == 1)
                    {
                        Dashboard dashboard = new Dashboard();
                        this.Hide();
                        dashboard.Show();
                    }
                }
            }
        }

        private bool isValid()
        {
            if (txtUserName.Text.TrimStart() == string.Empty)
            {
                MessageBox.Show("Enter valid user name please!", "Error");
                return false;
            }
            else if (txtPassword.Text.TrimStart() == string.Empty)
            {
                MessageBox.Show("Enter valid password please!", "Error");
                return false;
            }
            return true;
        }
    }
}
