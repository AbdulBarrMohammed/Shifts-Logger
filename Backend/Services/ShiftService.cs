using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Data;
using Backend.Model;

namespace Backend.Services
{
    public class ShiftService : IShiftService
    {
         private readonly ShiftsDbContext _dbContext;

        public ShiftService(ShiftsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Shift CreateShift(Shift shift)
        {
            var savedShift = _dbContext.Shifts.Add(shift);
            _dbContext.SaveChanges();
            return savedShift.Entity;
        }

        public string? DeleteShfit(int id)
        {
            Shift savedShift = _dbContext.Shifts.Find(id);
            if (savedShift == null)
            {
                return null;
            }

            _dbContext.Shifts.Remove(savedShift);

            return $"Successfully deleted Shift with id: {id}";
        }

        public List<Shift> GetAllShifts()
        {
            return _dbContext.Shifts.ToList();
        }

        public Shift? GetShiftById(int id)
        {
            Shift savedShift = _dbContext.Shifts.Find(id);
            return savedShift == null ? null : savedShift;
        }

        public Shift UpdateShift(Shift updatedShift)
        {
            Shift savedShift = _dbContext.Shifts.Find(updatedShift.Id);

            if (savedShift == null)
            {
                return null;
            }

            _dbContext.Entry(savedShift).CurrentValues.SetValues(updatedShift);
            _dbContext.SaveChanges();
            return savedShift;
        }
    }
}
