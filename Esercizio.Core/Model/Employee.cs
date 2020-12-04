using System;
using System.Collections.Generic;
using System.Text;

namespace Esercizio.Core.Model
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int BadgeNumber { get; set; }
        public string Indirizzo { get; set; }
        public string Telefono { get; set; }
        public int OfficeId { get; set; } //Foreign Key => Office

        public virtual Office Office { get; set; }
    }
}
