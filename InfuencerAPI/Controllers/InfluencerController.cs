using InfluencerAPI.Services;
using InfuencerAPI.Data;
using InfuencerAPI.Models.InfluencersDTO;
using InfuencerAPI.Models.MasterDTO;
using InfuencerAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace InfuencerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfluencerController : ControllerBase
    {
        private readonly InfluencerDbContext dbContext;

        private readonly IInfluencerService InfluencerService;

        public InfluencerController(InfluencerDbContext dbContext, IInfluencerService influencerService)
        {
            this.dbContext = dbContext;
            InfluencerService = influencerService;
        }

        // GET ALL RECORDS
        [HttpGet]
        public IActionResult GetAll()
        {
            // Get Data From Database - Using Models
            var influencers = dbContext.Influencer.ToList();

            // Map Models to DTO
            var influencersResponse = new List<CreateInfluencerRequest>();
            foreach (var influencer in influencers)
            {
                influencersResponse.Add(new CreateInfluencerRequest()
                {
                    Name = influencer.Name,
                    ImagePath = influencer.ImagePath,
                    Description = influencer.Description
                });
            }

            return Ok(influencersResponse);
        }

        // GET ALL RECORDS
        [HttpGet("GetInfluencerByRanking")]
        public async Task<IActionResult> GetInfluencerByRanking()
        {
            try
            {
                var response = await InfluencerService.GetInfluencerByRanking();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return ErrorResponse.ReturnErrorResponse(ex.Message);
            }
        }

        // GET ALL RECORDS
        [HttpGet("GetInfluencerServiceById/{id:guid}")]
        public async Task<IActionResult> GetInfluencerServiceById(Guid id)
        {
            try
            {
                var response = await InfluencerService.GetInfluencerServiceById(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return ErrorResponse.ReturnErrorResponse(ex.Message);
            }
        }

        // GET ALL RECORDS
        [HttpGet("GetInfluencerById/{id:guid}")]
        public async Task<IActionResult> GetInfluencerById(Guid id)
        {
            try
            {
                var response = await InfluencerService.GetInfluencerById(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return ErrorResponse.ReturnErrorResponse(ex.Message);
            }
		}

		// GET ALL RECORDS
		[HttpGet("GetInfluencerRestDayById/{id:guid}")]
		public async Task<IActionResult> GetInfluencerRestDayById(Guid id)
		{
			try
			{
				var response = await InfluencerService.GetInfluencerRestDayById(id);
				return Ok(response);
			}
			catch (Exception ex)
			{
				return ErrorResponse.ReturnErrorResponse(ex.Message);
			}
		}


        // GET ALL RECORDS
        [HttpGet("GetInfluencerByFilter/{genderId}/{industryId}/{nationalityId}/{name}")]
        public async Task<IActionResult> GetInfluencerByFilter(string genderId, string industryId, string nationalityId, string name)
        {
            try
            {
                var response = await InfluencerService.GetInfluencerByFilter(genderId, industryId, nationalityId, name);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return ErrorResponse.ReturnErrorResponse(ex.Message);
            }
        }

        // GET ALL RECORDS
        [HttpGet("GetInfluencerTimeTypeById/{id:guid}")]
        public async Task<IActionResult> GetInfluencerTimeTypeById(Guid id)
        {
            try
            {
                var response = await InfluencerService.GetInfluencerTimeTypeById(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return ErrorResponse.ReturnErrorResponse(ex.Message);
            }
        }

        // GET RECORD BY FILTER
        [HttpGet]
        [Route("{id}")]
        public IActionResult FilterBy([FromRoute] Guid id)
        {
            // Only for ID or Primary Key
            var influencer = dbContext.Influencer.Find(id);

            // For Any Columns in the Table
            //var influencer = dbContext.Influencer.FirstOrDefault(x => x.Id == id);

            if (influencer == null)
            {
                return NotFound();
            }

            // Map Models to DTO
            var influencerResponse = new CreateInfluencerRequest
            {
                Name = influencer.Name,
                ImagePath = influencer.ImagePath,
                Description = influencer.Description
            };

            return Ok(influencerResponse);
        }

    }
}