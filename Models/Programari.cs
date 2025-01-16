using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;


namespace CabinetVeterinar.Models
{
    public class Programari
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        
        [MaxLength(250)]
        public string OwnerName { get; set; }
        public string PetName { get; set; }

        public DateTime AppointmentDate { get; set; }
    }
}
