using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabinetVeterinar.Models
{
    public class Appointment
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [ForeignKey(typeof(Pet))]
        public int PetID { get; set; }

        public DateTime AppointmentDate { get; set; }
        public string Notes { get; set; }

        [ManyToOne]
        public Pet Pet { get; set; }
    }
}
