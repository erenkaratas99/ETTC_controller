using System;
using System.Threading.Tasks;
using KBC_Patient.Entities;
using KBC_Patient.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace KBC_Patient.Controllers
{
    [ApiController]
    [Route("api")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientRepository _patientRepository;

        public PatientController(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetOne()
        {
            var patients = await _patientRepository.GetPatientsAsync();
            return Ok(patients);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var patients = await _patientRepository.GetPatientsAllAsync();
            return Ok(patients);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatient(string id)
        {
            var patient = await _patientRepository.GetPatientAsync(id);
            if (patient != null)
            {
                return Ok(patient);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AddPatient()
        {
            var createdPatient = await _patientRepository.AddPatientAsync(new Patient());
            return Ok(createdPatient);
        }

        [HttpPut("{id}/{pressure}")]
        public async Task<IActionResult> UpdatePatient(string id, double pressure)
        {

            var patient =await _patientRepository.GetPatientAsync(id);
            if (patient == null)
            {
                return NotFound();
            }

            patient.Pressure = pressure;

            var updateResult = await _patientRepository.UpdateAsync(patient);

            if (!updateResult)
            {
                return BadRequest();
            }

            return Ok();
        }
        
        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePatientAll(string id, [FromBody] PatientForUpdate patientNew)
        {

            var patient =await _patientRepository.GetPatientAsync(id);
            if (patient == null)
            {
                return NotFound();
            }

            patient.Name = patientNew.Name;
            patient.Surname = patientNew.Surname;
            patient.Pressure = patientNew.Pressure;
            patient.BottomLimit = patientNew.BottomLimit;
            patient.UpperLimit = patientNew.UpperLimit;


            var updateResult = await _patientRepository.UpdateAsync(patient);

            if (!updateResult)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(string id)
        {
            var deleteResult = await _patientRepository.DeleteAsync(id);
            if (!deleteResult)
            {
                return NotFound();
            }

            return Ok();
        }
       
    }
}