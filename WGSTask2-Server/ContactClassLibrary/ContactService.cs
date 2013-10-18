using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContactClassLibrary
{
    public class ContactService : IContactService
    {
        //contact service 

        public bool InsertContact(Contact obj)
        {
            contactList.Add(obj);
            return true;
        }

        public List<Contact> GetAllContact()
        {
            return contactList;
        }

        public bool DeleteContact(int Cid)
        {
            var item = contactList.First(x => x.cID == Cid);

            contactList.Remove(item);
            return true;
        }

        public bool UpdateContact(Contact obj)
        {
            var list = contactList;
            contactList.Where(p => p.cID == obj.cID).Update(p => p.cName = obj.cName);
            return true;
        }

        public static List<Contact> contactList = new List<Contact>()
        {
            new Contact {cID = 1, cName="Didin", cNoHP="085620111111" },
            new Contact {cID = 2, cName="Dadang", cNoHP="085620111112" },
            new Contact {cID = 3, cName="Cecep", cNoHP="085620111113" }
        };

    }

    public static class LinqUpdates
    {
        public static void Update<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (var item in source)
                action(item);
        }
    }
}
