using System;
using System.Collections.Generic;
using System.Text;

namespace Esercizio.Core.Model
{
    public class Office
    {
        public int Id { get; set; }
        public string Nome{ get; set; }
       

        public virtual List<Employee> Employees { get; set; }
    }
}
