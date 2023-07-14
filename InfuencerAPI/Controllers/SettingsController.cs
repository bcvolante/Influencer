using InfuencerAPI.Models.MasterDTO;
using InfuencerAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InfuencerAPI.Controllers
{
    [Route("api/[controller]")]
    //[Authorize]
    [ApiController]
    public class SettingsController : ControllerBase
    {
        private readonly ISettingsService settingsService;

        public SettingsController(ISettingsService settingsService)
        {
            this.settingsService = settingsService;
        }

        // GET ALL RECORDS
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = await settingsService.GetAll();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return ErrorResponse.ReturnErrorResponse(ex.Message);
            }
        }

        // GET RECORD BY ID
        [HttpGet("GetById/{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            try
            {
                var response = await settingsService.GetById(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return ErrorResponse.ReturnErrorResponse(ex.Message);
            }
        }

        // GET RECORDS BY FILTER
        [HttpGet("FilterBy/{typeId:guid}")]
        public async Task<IActionResult> FilterBy([FromRoute] Guid typeId)
        {
            try
            {
                var response = await settingsService.FilterBy(typeId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return ErrorResponse.ReturnErrorResponse(ex.Message);
            }
        }

        // GET INDUSTRY WITH TAG
        [HttpGet("GetIndustryWithData/{typeId:guid}")]
        public async Task<IActionResult> GetIndustryWithData([FromRoute] Guid typeId)
        {
            try
            {
                var response = await settingsService.GetIndustryWithData(typeId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return ErrorResponse.ReturnErrorResponse(ex.Message);
            }
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateSettingsRequest createSettingsRequest)
        {
            try
            {
                var response = await settingsService.Create(createSettingsRequest);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return ErrorResponse.ReturnErrorResponse(ex.Message);
            }

        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateSettingsRequest updateSettingsRequest)
        {
            try
            {
                var response = await settingsService.Update(updateSettingsRequest);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return ErrorResponse.ReturnErrorResponse(ex.Message);
            }

        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteSettingsRequest deleteSettingsRequest)
        {
            try
            {
                var response = await settingsService.Delete(deleteSettingsRequest);
                return Ok(response);

            }
            catch (Exception ex)
            {
                return ErrorResponse.ReturnErrorResponse(ex.Message);
            }

        }
    }
}
