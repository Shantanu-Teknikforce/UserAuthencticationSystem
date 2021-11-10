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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UserAuthencticationSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=UserAuthsys;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            try
            {
                if (sqlcon.State == ConnectionState.Closed)
                    sqlcon.Open();

                string query = "SELECT COUNT(1) FROM Users WHERE Username=@Username AND Password=@Password";
                SqlCommand sqlcmd = new SqlCommand(query,sqlcon);
                sqlcmd.CommandType = CommandType.Text;
                sqlcmd.Parameters.AddWithValue("@Username", Username.Text);
                sqlcmd.Parameters.AddWithValue("@Password", Password.Password);
                int count = Convert.ToInt32(sqlcmd.ExecuteScalar());
                if (count!=0)
                {
                    SuccessPage successpage = new SuccessPage(this);
                    successpage.Show();
                    this.Close();
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

        private void signupHere_Click(object sender, RoutedEventArgs e)
        {
            SignupPage signup = new SignupPage();
            signup.Show();
            this.Close();
        }
    }
}
