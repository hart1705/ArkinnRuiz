using System;
using System.Collections.Generic;
using System.Text;

namespace AR.Domain.Entities
{
    public class Event : RecordInformation
    {
        public Event()
        {
            Registrations = new HashSet<Registration>();
        }
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public ICollection<Registration> Registrations { get; private set; }
    }
}
