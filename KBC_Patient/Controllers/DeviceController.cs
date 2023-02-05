using System.Threading.Tasks;
using KBC_Patient.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KBC_Patient.Controllers
{
    [ApiController]
    [Route("api/device")]
    public class DeviceController:ControllerBase
    {
        
        private readonly IDeviceRepository _deviceRepository;
        public DeviceController(IDeviceRepository deviceRepository)
        {
            _deviceRepository = deviceRepository;
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatient(string id)
        {
            var device = await _deviceRepository.GetDeviceAsync(id);
            if (device != null)
            {
                return Ok(device);
            }
            return NotFound();
        }
        

        [HttpPut("device/{id}/{isWorking}")]
        public async Task<IActionResult> OnOffDevice(string id, bool isWorking)
        {
            var device = await _deviceRepository.GetDeviceAsync(id);
            if (device == null)
            {
                return NotFound();
            }

            if (device.IsWorking == isWorking)
            {
                return BadRequest();
            }

            device.IsWorking = isWorking;
            var updateResult = await _deviceRepository.UpdateAsync(device);
            if (updateResult) return Ok();
            return BadRequest();
        }

        [HttpPut("device/increase/{id}/{isIncreasing}")]
        public async Task<IActionResult> PutIncreasing(string id, bool isIncreasing)
        {
            var device = await _deviceRepository.GetDeviceAsync(id);
            if (device == null)
            {
                return NotFound();
            }

            if (device.IsIncreasing == isIncreasing)
            {
                return BadRequest();
            }

            device.IsIncreasing = isIncreasing;
            var updateResult = await _deviceRepository.UpdateAsync(device);
            if (updateResult) return Ok();
            return BadRequest();
            
        }
        
        [HttpPut("device/decrease/{id}/{isDecreasing}")]
        public async Task<IActionResult> PutDecreasing(string id, bool isDecreasing)
        {
            var device = await _deviceRepository.GetDeviceAsync(id);
            if (device == null)
            {
                return NotFound();
            }

            if (device.IsDecreasing == isDecreasing)
            {
                return BadRequest();
            }

            device.IsDecreasing = isDecreasing;
            var updateResult = await _deviceRepository.UpdateAsync(device);
            if (updateResult) return Ok();
            return BadRequest();
            
        }
    }
}