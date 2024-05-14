using DoctoeClinicAPI.Exceptions;
using DoctoeClinicAPI.Interfaces;
using DoctoeClinicAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace DoctoeClinicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {


        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }
        [HttpGet]
        public async Task<ActionResult<IList<Doctor>>> Get()
        {
            try
            {
                var doctors = await _doctorService.GetDoctors();
                return Ok(doctors.ToList());
            }
            catch (NoDoctorFoundException nefe)
            {
                return NotFound(nefe.Message);
            }
        }
        [HttpGet]
        public async Task<ActionResult<Doctor>> GetDoctorBySpeciality(string specilaity)
        {
            try
            {
                var doctors = await _doctorService.GetDoctors();
                Doctor result = null;
                foreach (var doctor in doctors)
                {
                    if (doctor.Speciality == specilaity)
                    {
                        result = doctor;
                        break;
                    }
                }
                if (result == null)
                {
                    throw new NoDoctorFoundException();
                }
                return Ok(result);

            }
            catch (NoDoctorFoundException nefe)
            {
                return NotFound(nefe.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<Doctor>> Put(int id, float experience)
        {
            try
            {
                var doctor = await _doctorService.UpdateDoctorExperience(id, experience);
                return Ok(doctor);
            }
            catch (NoSuchDoctorException nsee)
            {
                return NotFound(nsee.Message);
            }
        }
    }
}
