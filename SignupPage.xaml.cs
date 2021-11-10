using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace UserAuthencticationSystem
{
    /// <summary>
    /// Interaction logic for SignupPage.xaml
    /// </summary>
    public partial class SignupPage : Window
    {
        public SignupPage()
        {
            InitializeComponent();
        }

        private void SignupBtn_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=UserAuthsys;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                    sqlcon.Open();

                string query = "INSERT INTO Users (username,password) VALUES (@Username,@Password)";
                SqlCommand sqlcmd = new SqlCommand(query, sqlcon);
                sqlcmd.CommandType = CommandType.Text;
                sqlcmd.Parameters.AddWithValue("@Username", Username.Text);
                sqlcmd.Parameters.AddWithValue("@Password", Password.Password);

                int count = sqlcmd.ExecuteNonQuery();
                if (count != 0)
                {
                    MessageBox.Show("Signup Successfully");
                }
                else
                {
                    MessageBox.Show("Invalid Username or password");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlcon.Close();
            }
        
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            MainWindow LoginPage = new MainWindow();
            LoginPage.Show();
            this.Close();
        }
    }
}
