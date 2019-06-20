using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static AR.Domain.Helpers.Enums;

namespace AR.Domain.Entities
{
    public class Contact : RecordInformation
    {
        public string Id { get; set; }
        public string OwnerId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public ContactStatus ContactStatus { get; set; }
    }
}
