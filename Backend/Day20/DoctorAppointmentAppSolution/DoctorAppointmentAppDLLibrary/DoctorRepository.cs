using DoctorAppointmentAppDLLibrary.Model;
using DoctorAppointmentAppModelLib;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DoctorAppointmentAppDLLibrary
{
    public class DoctorRepository : BaseRepository<int, Model.Doctor>
    {
        protected readonly DoctorAppointmentDBContext _context;

        DoctorRepository(DoctorAppointmentDBContext context) : base(context)
        {
            _context = context;
        }
    }
}
