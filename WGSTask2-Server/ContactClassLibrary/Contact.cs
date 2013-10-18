using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ContactClassLibrary
{
    //interface untuk contact service

    [DataContract]
    public class Contact
    {
        [DataMember]
        public int cID;

        [DataMember]
        public string cName;

        [DataMember]
        public string cNoHP;
    }
}
