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
    /// Interaction logic for DetailsWindow.xaml
    /// </summary>
    public partial class DetailsWindow : Window {

        Contact contact;

        public DetailsWindow(Contact contact) {
            InitializeComponent();

            this.contact = contact;

            InitializeTexBoxes();
        }

        /// <summary>
        /// Initialize text boxes with contact's object properties
        /// </summary>
        private void InitializeTexBoxes() {
            nameTextBox.Text = contact.Name;
            phoneNumberTextBox.Text = contact.Phone;
            emailTextBox.Text = contact.Email;
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e) {

            UpdateContact();

            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath)) {
                connection.CreateTable<Contact>();
                connection.Update(contact);
            }
            Close();
        }

        /// <summary>
        /// Updates the contact object's properties with values in textboxes
        /// </summary>
        private void UpdateContact() {
            contact.Name = nameTextBox.Text;
            contact.Phone = phoneNumberTextBox.Text;
            contact.Email = emailTextBox.Text;

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e) {
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath)) {
                connection.CreateTable<Contact>();
                connection.Delete(contact);
            }
            Close();
        }
    }
}
