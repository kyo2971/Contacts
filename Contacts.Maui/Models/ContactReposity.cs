using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.Maui.Models
{
    public static class ContactReposity
    {
        public static List<Contact> _contacts = new List<Contact>()
        {
            new Contact() {ContactId=1 ,Name="John1 Doe", Email="JohnDoe@gmail.com"},

            new Contact() {ContactId=2 ,Name="Jane2 Doe", Email="JaneDoe@gmail.com"},

            new Contact() {ContactId=3 ,Name="Tom3 Hanks", Email="TomHanks@gmail.com"},

            new Contact() {ContactId=4 ,Name="Frank4 Liu", Email="FrankLiu@gmail.com"}

        };

        public static List<Contact> GetContacts() => _contacts;

        public static Contact GetContactById(int contactId) 
        {
             return _contacts.FirstOrDefault(x=>x.ContactId== contactId);
        }
    }
}
