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
             var contact =_contacts.FirstOrDefault(x=>x.ContactId== contactId);
            if (contact != null)
            {
                return new Contact 
                {
                    ContactId = contactId,
                    Name = contact.Name,
                    Email = contact.Email,
                    Address = contact.Address,
                    Phone = contact.Phone
                };
            }

            return null;
        }

        public static void UpdateContact(int contactId, Contact contact)
        { 
            if(contactId != contact.ContactId) return;

            //var contactToUpdate = GetContactById(contactId);
            var contactToUpdate = _contacts.FirstOrDefault(x => x.ContactId == contactId);
            if (contactToUpdate != null) 
            {
                contactToUpdate.Name = contact.Name;
                contactToUpdate.Email = contact.Email;
                contactToUpdate.Phone = contact.Phone;
                contactToUpdate.Address = contact.Address;


            }

        }

        public static void AddContact(Contact contact)
        { 
            var maxId=_contacts.Max(x => x.ContactId);
            contact.ContactId = maxId+1;
            _contacts.Add(contact);
        }

        public static void DeleteContact(int contactId)
        {
            var contact = _contacts.FirstOrDefault(x => x.ContactId==contactId);
            if (contact != null) 
            {
                 _contacts.Remove(contact);
            }
        }

        public static List<Contact> SearchContacts(string filterText)
        {
            var contacts=_contacts.Where(x => x.Name.StartsWith(filterText, StringComparison.OrdinalIgnoreCase))?.ToList();

            if (contacts == null || contacts.Count <= 0)
            {contacts = _contacts.Where(x => !string.IsNullOrWhiteSpace(x.Name) && x.Email.StartsWith(filterText, StringComparison.OrdinalIgnoreCase))?.ToList();}
            else
            { return contacts; }

            if (contacts == null || contacts.Count <= 0)
            { contacts = _contacts.Where(x => !string.IsNullOrWhiteSpace(x.Phone) && x.Phone.StartsWith(filterText, StringComparison.OrdinalIgnoreCase))?.ToList(); }
            else
            { return contacts; }

            if (contacts == null || contacts.Count <= 0)
            { contacts = _contacts.Where(x => !string.IsNullOrWhiteSpace(x.Address) && x.Address.StartsWith(filterText, StringComparison.OrdinalIgnoreCase))?.ToList(); }
            else
            { return contacts; }

            return contacts;
        }

    }
}
