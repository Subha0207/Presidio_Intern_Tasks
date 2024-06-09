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

        [Route("GetAllDoctors")]
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
        [Route("GetDoctorBySpeciality")]
        public async Task<ActionResult<IList<Doctor>>> GetBySpeciality(string speciality)
        {
            try
            {
                var result = await _doctorService.GetDoctorBySpeciality(speciality);
                return Ok(result);
            }
            catch (Exception NoSuchDoctorFound)
            {
                return NotFound(NoSuchDoctorFound.Message);
            }
        }

        [HttpPut]

        [Route("UpdateDoctorExperience")]
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
