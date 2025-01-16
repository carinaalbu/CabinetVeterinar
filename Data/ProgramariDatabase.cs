using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using CabinetVeterinar.Models;
using Plugin.LocalNotification;


namespace CabinetVeterinar.Data
{
    public class ProgramariDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public ProgramariDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Programari>().Wait();
            _database.CreateTableAsync<Pet>().Wait();
        }

        public Task<List<Programari>> GetAppointmentsAsync()
        {
            return _database.Table<Programari>().ToListAsync();
        }

        public Task<Programari> GetAppointmentAsync(int id)
        {
            return _database.Table<Programari>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveAppointmentAsync(Programari appointment)
        {
            if (appointment.ID != 0)
            {
                return _database.UpdateAsync(appointment);
            }
            else
            {
                return _database.InsertAsync(appointment);
            }
        }

        public Task<int> DeleteAppointmentAsync(Programari appointment)
        {
            return _database.DeleteAsync(appointment);
        }
        public Task<List<Pet>> GetPetsAsync()
        {
            return _database.Table<Pet>().ToListAsync();
        }

        public Task<int> SavePetAsync(Pet pet)
        {
            if (pet.ID != 0)
            {
                return _database.UpdateAsync(pet);
            }
            else
            {
                return _database.InsertAsync(pet);
            }
        }

        public Task<int> DeletePetAsync(Pet pet)
        {
            return _database.DeleteAsync(pet);
        }

        public Task<List<Appointment>> GetAppointmentsForPetAsync(int petId)
        {
            return _database.Table<Appointment>().Where(a => a.PetID == petId).ToListAsync();
        }

        public void ScheduleNotificationForAppointment(Appointment appointment)
        {
            var notificationDate = appointment.AppointmentDate.AddDays(-1);

            if (notificationDate > DateTime.Now) // Asigură-te că notificarea este în viitor
            {
                var notification = new NotificationRequest
                {
                    NotificationId = appointment.ID,
                    Title = "Reminder Programare",
                    Description = $"Ai o programare pentru {appointment.Pet.Name} pe {appointment.AppointmentDate:dd MMM yyyy HH:mm}.",
                    Schedule =
            {
                NotifyTime = notificationDate
            }
                };

                LocalNotificationCenter.Current.Show(notification);
            }
        }

    }
}
