using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AR.Domain.Entities
{
    public class Registration : RecordInformation
    {
        public string Id { get; set; }
        public int StubNumber { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MobileNumber { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Course { get; set; }
        public string EventId { get; set; }
        public Event Event { get; set; }
    }
}
