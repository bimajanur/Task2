using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace ContactClassLibrary
{
    [ServiceContract]
    interface IContactService
    {
        [OperationContract]
        bool InsertContact(Contact obj);

        [OperationContract]
        List<Contact> GetAllContact();

        [OperationContract]
        bool DeleteContact(int Cid);

        [OperationContract]
        bool UpdateContact(Contact obj);
    }
}
