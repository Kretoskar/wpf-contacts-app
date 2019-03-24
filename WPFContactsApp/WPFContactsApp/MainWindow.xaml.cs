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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFContactsApp.Classes;

namespace WPFContactsApp {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            ReadDatabase();
        }

        private void NewContactButton_Click(object sender, RoutedEventArgs e) {
            ShowNewContactWindow();
            ReadDatabase();
        }

        /// <summary>
        /// Opens up the window for adding a new contact
        /// </summary>
        private void ShowNewContactWindow() {
            NewContactWindow newContactWindow = new NewContactWindow();
            newContactWindow.ShowDialog();
        }

        /// <summary>
        /// Read from the database
        /// </summary>
        private void ReadDatabase() {
            using (var connection = new SQLiteConnection(App.databasePath)) {
                connection.CreateTable<Contact>();
                var contacts = connection.Table<Contact>().ToList();
            }
        }
    }
}
