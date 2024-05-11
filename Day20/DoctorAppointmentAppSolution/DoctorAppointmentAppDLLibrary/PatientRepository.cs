using DoctorAppointmentAppModelLib;
using DoctorAppointmentAppDLLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DoctorAppointmentAppDLLibrary
{
    public class PatientRepository : BaseRepository<int, Model.Patient>
    {
        protected readonly DoctorAppointmentDBContext _context;

        PatientRepository(DoctorAppointmentDBContext context) : base(context)
        {
            _context = context;
        }
    }
}
