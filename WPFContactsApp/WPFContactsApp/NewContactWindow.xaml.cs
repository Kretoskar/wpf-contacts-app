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
using WPFContactsApp.Classes;

namespace WPFContactsApp {
    /// <summary>
    /// Interaction logic for NewContactWindow.xaml
    /// </summary>
    public partial class NewContactWindow : Window {
        public NewContactWindow() {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e) {
            AddNewContact();
            CloseWindow();
        }

        /// <summary>
        /// Adds a contact to the database
        /// in text boxes
        /// </summary>
        private void AddNewContact() {
            //Create contact object
            Contact contact = new Contact() {
                Name = nameTextBox.Text,
                Email = emailTextBox.Text,
                Phone = phoneNumberTextBox.Text
            };
            //Add the contact to database and close the database
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath)) {
                //Add a contact to the database
                connection.CreateTable<Contact>();
                connection.Insert(contact);
            }
        }

        /// <summary>
        /// Closes this window
        /// </summary>
        private void CloseWindow() {
            this.Close();
        }
    }
}
