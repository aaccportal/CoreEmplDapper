using System;
using System.Collections.Generic;

namespace CoreEmplDapper.Models
{
    public partial class Empl
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public DateTime? BirthDate { get; set; }
        public string City { get; set; }
    }
}
