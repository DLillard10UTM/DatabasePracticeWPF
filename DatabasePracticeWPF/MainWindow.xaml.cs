using System;
using System.Collections.Generic;
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
using System.Data.OleDb;

namespace DatabasePracticeWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OleDbConnection cn;
        public MainWindow()
        {
            InitializeComponent();
            
            cn = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source =|DataDirectory|\\EmployeesAndAssets.accdb");
        }

        private void seeAssets_Click(object sender, RoutedEventArgs e)
        {
            string query = "SELECT * FROM Assets";
            OleDbCommand cmd = new OleDbCommand(query, cn);
            cn.Open();
            OleDbDataReader read = cmd.ExecuteReader();
            string data = "";
            while (read.Read())
            {
                //FieldCount allows us to work the loop off of the Access database.
                for(int i = 0; i < read.FieldCount; i++)
                {
                    // i is repesenting col number here.
                    data += read[i].ToString() + " ";
                }
                data += "\n";
            }
            AssetDisplay.Text = data;
            cn.Close();
        }

        //Button press for employee text, will show the text for employees.
        private void button_Click(object sender, RoutedEventArgs e)
        {
            string query = "SELECT * FROM Employees";
            OleDbCommand cmd = new OleDbCommand(query, cn);
            cn.Open();
            OleDbDataReader read = cmd.ExecuteReader();
            string data = "";
            while (read.Read())
            {
                //FieldCount allows us to work the loop off of the Access database.
                for (int i = 0; i < read.FieldCount; i++)
                {
                    // i is repesenting col number here.
                    data += read[i].ToString() + " ";
                }
                data += "\n";
            }
            EmployeeDisplay.Text = data;
            cn.Close();
        }
    }
}
