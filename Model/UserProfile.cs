using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Allo.Model {
    public class UserProfile {

        public string Name {get;set;}
        public string Position {get;set;}

        public string Company {get;set;}

        public IEnumerable<Contact> Contact {get;set;}

        public IEnumerable<Handle> Handles {get;set;}

        public string ID {get;set;}
    }
    
    public class Contact
    {
        public string Type { get; set; }

        public string Value { get; set; }
    }
    
    public class Handle
    {
        public string Type { get; set; }

        public string Value { get; set; }
    }
}