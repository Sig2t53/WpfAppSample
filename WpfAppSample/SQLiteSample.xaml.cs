using SQLite;
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
using System.Windows.Shapes;
using WpfAppSample.Object;

namespace WpfAppSample
{
    /// <summary>
    /// SQLiteSample.xaml の相互作用ロジック
    /// </summary>
    public partial class SQLiteSample : Window
    {
        public SQLiteSample()
        {
            InitializeComponent();
        }
        
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var customer = new Customer()
            {
                Name = NameTextBox.Text,
                Phone = PhoneTextBox.Text,
            };

            string databaseName = "Shop.db";
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string databasePath = System.IO.Path.Combine(folderPath,databaseName);
            using (var connection = new SQLiteConnection(databasePath))
            {
                connection.CreateTable<Customer>();
                connection.Insert(customer);
            }

        }
    }
}
