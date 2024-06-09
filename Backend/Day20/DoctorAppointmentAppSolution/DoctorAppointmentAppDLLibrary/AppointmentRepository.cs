using DoctorAppointmentAppDLLibrary.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentAppDLLibrary
{
    public class AppointmentRepository : BaseRepository<int, Model.Appointment>
    {
        protected readonly DoctorAppointmentDBContext _context;

        AppointmentRepository(DoctorAppointmentDBContext context) : base(context)
        {
            _context = context;
        }
    }

}
