using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFContactsApp.Classes {
    public class Contact {

        public Contact() {
            Name = "Name LastName";
            Email = "example@domain.com";
            Phone = "123456789";
        }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
