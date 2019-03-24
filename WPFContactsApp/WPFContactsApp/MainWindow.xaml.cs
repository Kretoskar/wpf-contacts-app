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

        List<Contact> contacts;

        public MainWindow() {
            InitializeComponent();
            contacts = new List<Contact>();
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
                contacts = connection.Table<Contact>().ToList();
            }
            UpdateListView(contacts);
        }

        /// <summary>
        /// Update the list view in the main window
        /// </summary>
        /// <param name="contacts">list of contacts to add to listview</param>
        private void UpdateListView(List<Contact> contacts) {
            if (contacts != null) {
                contactsListView.ItemsSource = contacts;  
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e) {
            TextBox searchTextBox = sender as TextBox;

            ListFilter(searchTextBox);
        }

        private void ListFilter(TextBox searchTextBox) {
            var filteredList = contacts.Where(c => c.Name.ToLower().Contains(searchTextBox.Text.ToLower())).ToList();
            contactsListView.ItemsSource = filteredList;
        }
    }
}
