using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public override string ToString()
        {
            return string.Format("Club Id: {0}, Name: {1} {2}", this.Id, this.Name, this.Description);
        }
    }
}
