using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace CabinetVeterinar.Models
{
    public class Pet
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Name { get; set; }
        public string Breed { get; set; }
        public string OwnerName { get; set; }

        [OneToMany]
        public List<Programari> Appointments { get; set; }
    }
}
