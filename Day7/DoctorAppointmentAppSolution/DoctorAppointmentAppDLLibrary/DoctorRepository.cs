using DoctorAppointmentAppModelLib;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DoctorAppointmentAppDLLibrary
{
    public class DoctorRepository : IRepository<int, Doctor>
    {
        readonly DoctorDictionary _doctors;

        public DoctorRepository()
        {
            _doctors = new DoctorDictionary();
        }

        int GenerateId()
        {
            if (_doctors.Doctors.Count == 0)
                return 1;
            int id = _doctors.Doctors.Keys.Max();
            return ++id;
        }

        public Doctor Add(Doctor item)
        {
            if (_doctors.Doctors.ContainsValue(item))
            {
                return null;
            }
            _doctors.Doctors.Add(GenerateId(), item);
            return item;
        }

        public Doctor Delete(int key)
        {
            if (_doctors.Doctors.ContainsKey(key))
            {
                var doctor = _doctors.Doctors[key];
                _doctors.Doctors.Remove(key);
                return doctor;
            }
            return null;
        }

        public Doctor Get(int key)
        {
            return _doctors.Doctors.ContainsKey(key) ? _doctors.Doctors[key] : null;
        }

        public List<Doctor> GetAll()
        {
            if (_doctors.Doctors.Count == 0)
                return null;
            return _doctors.Doctors.Values.ToList();
        }

        public Doctor Update(Doctor item)
        {
            if (_doctors.Doctors.ContainsKey(item.DoctorId))
            {
                _doctors.Doctors[item.DoctorId] = item;
                return item;
            }
            return null;
        }
    }

    public class DoctorDictionary
    {
        public Dictionary<int, Doctor> Doctors { get; set; }

        public DoctorDictionary()
        {
            Doctors = new Dictionary<int, Doctor>();
        }
    }
}
