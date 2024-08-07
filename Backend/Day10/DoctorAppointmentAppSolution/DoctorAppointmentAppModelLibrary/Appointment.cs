﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentAppModelLibrary
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public DateTime AppointmentDate { get; set; }

        public Doctor? Doctor { get; set; }
        public Patient? Patient { get; set; }
        public bool Availability { get; set; }

        public Appointment()
        {
            AppointmentId = 0;
            AppointmentDate = new DateTime();

            Doctor = null;
            Patient = null;
            Availability = true; // Default value
        }

        public Appointment(int appointmentId, DateTime appointmentDate, Doctor doctor, Patient patient, bool availability)
        {
            AppointmentId = appointmentId;
            AppointmentDate = appointmentDate;

            Doctor = doctor;
            Patient = patient;
            Availability = availability;
        }
    }


}

