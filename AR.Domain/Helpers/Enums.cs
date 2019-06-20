using System;
using System.Collections.Generic;
using System.Text;

namespace AR.Domain.Helpers
{
    public class Enums
    {
        public enum Status
        {
            Active = 0,
            Inactive = 1
        }
        public enum AccessType
        {
            User = 0,
            Organization = 1
        }
        public enum ContactStatus
        {
            Submitted,
            Approved,
            Rejected
        }
        public enum UnitType
        {
            Current = 0,
            New = 1
        }
        public enum ApprovalType
        {
            Committee = 0,
            Additional = 1
        }
    }
}
