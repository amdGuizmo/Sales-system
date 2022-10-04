using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Table(Name = "TUsers")]
    public class TUsers
    {
        [PrimaryKey, Identity]
        public int ID { get; set; }

        [Column()]
        public string NID { get; set; }

        [Column()]
        public string LastName { get; set; }

        [Column()]
        public string Name { get; set; }

        [Column()]
        public string Email { get; set; }

        [Column()]
        public string Password { get; set; }

        [Column()]
        public string Users { get; set; }

        [Column()]
        public string Telephone { get; set; }

        [Column()]
        public string Role { get; set; }

        [Column()]
        public string Date { get; set; }

        [Column()]
        public byte[] Images { get; set; }
    }
}
