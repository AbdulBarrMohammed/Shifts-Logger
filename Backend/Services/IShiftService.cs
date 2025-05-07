using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Model;

namespace Backend.Services
{
    public interface IShiftService
    {
        public List<Shift> GetAllShifts();
        public Shift? GetShiftById(int id);
        public Shift CreateShift(Shift shift);
        public Shift UpdateShift(int id, Shift shift);
        public string? DeleteShfit(int id);
    }
}
