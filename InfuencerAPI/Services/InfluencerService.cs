using InfuencerAPI.Data;
using InfuencerAPI.Models.Influencers;
using InfuencerAPI.Models.MasterDTO;
using Microsoft.EntityFrameworkCore;
using System;

namespace InfluencerAPI.Services
{
    public class InfluencerService: IInfluencerService
    {

        private readonly InfluencerDbContext dbContext;

        public InfluencerService(InfluencerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<MainResponse> GetInfluencerByRanking()
        {
            var response = new MainResponse();
            try
            {
                //response.Content =
                //await dbContext.Influencer
                //    .OrderBy(b => b.Name)
                //    .ToListAsync();

                response.Content =
                    await (
                    from b in dbContext.Influencer
                    join c in dbContext.Settings on b.NationalityId equals c.Id
                    join v in dbContext.Settings on b.IndustryId equals v.Id
                    join k in dbContext.Settings on b.GenderId equals k.Id
                    select new
                    {
                        b.Id,
                        b.Name,
                        b.ImagePath,
                        b.Description,
                        b.NationalityId,
                        b.IndustryId,
                        b.GenderId,
                        b.IsActive,
                        b.DateCreated,
                        Nationality = c.Name,
                        Industry = v.Name,
                        Gender = k.Name
                    })
                    .OrderBy(b => b.Name)
                    .ToListAsync();


                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
                response.IsSuccess = false;
            }
            return response;
        }

        public async Task<MainResponse> GetInfluencerById(Guid id)
        {
            var response = new MainResponse();
            try
            {
                response.Content =
                    await (
                    from b in dbContext.Influencer
                    join c in dbContext.Settings on b.NationalityId equals c.Id
                    join v in dbContext.Settings on b.IndustryId equals v.Id
                    join k in dbContext.Settings on b.GenderId equals k.Id
                    select new
                    {
                        b.Id,
                        b.Name,
                        b.ImagePath,
                        b.Description,
                        b.NationalityId,
                        b.IndustryId,
                        b.GenderId,
                        b.IsActive,
                        b.DateCreated,
                        Nationality = c.Name,
                        Industry = v.Name,
                        Gender = k.Name

                    })
                    .Where(bv => bv.Id == id)
                    .FirstOrDefaultAsync();

                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
                response.IsSuccess = false;
            }
            return response;
        }

        public async Task<MainResponse> GetInfluencerByFilter(string genderId, string industryId, string nationalityId, string name)
        {
            var response = new MainResponse();
            try
			{
				//Guid gender;
				//if (genderId == "Gender")
				//{
				//	gender = new("7dfb3f1b-b15f-4442-fea1-08db666f653d");
				//}
    //            else
    //            {
    //                gender = new(genderId);
    //            }
				//Guid industry;
				//if (industryId == "All Categories")
				//{
				//	industry = new("7dfb3f1b-b15f-4442-fea1-08db666f653d");
				//}
				//else
				//{
				//	industry = new(industryId);
				//}
				//Guid nationality;
				//if (nationalityId == "Nationality")
				//{
				//	nationality = new("7dfb3f1b-b15f-4442-fea1-08db666f653d");
				//}
				//else
				//{
				//	nationality = new(nationalityId);
				//}
    //            if (name == "vlnt")
    //            {
    //                name = string.Empty;
    //            }

				response.Content =
                    await (
                    from b in dbContext.Influencer
                    join c in dbContext.Settings on b.NationalityId equals c.Id
                    join v in dbContext.Settings on b.IndustryId equals v.Id
                    join k in dbContext.Settings on b.GenderId equals k.Id
                    select new
                    {
                        b.Id,
                        b.Name,
                        b.ImagePath,
                        b.Description,
                        b.NationalityId,
                        b.IndustryId,
                        b.GenderId,
                        b.IsActive,
                        b.DateCreated,
                        Nationality = c.Name,
                        Industry = v.Name,
                        Gender = k.Name
                    })
					//.Where(bv => genderId != "Gender" ? bv.GenderId == gender : true)
					//.Where(bv => industryId != "All Categories" ? bv.IndustryId == industry : true)
					//.Where(bv => nationalityId != "Nationality" ? bv.NationalityId == nationality : true)
					//.Where(bv => name != string.Empty ? bv.Name.Contains(name) : true)
					.Where(bv => genderId != "Gender" ? bv.GenderId.ToString() == genderId : true)
					.Where(bv => industryId != "All Categories" ? bv.IndustryId.ToString() == industryId : true)
					.Where(bv => nationalityId != "Nationality" ? bv.NationalityId.ToString() == nationalityId : true)
					.Where(bv => name != "vlnt" ? bv.Name.Contains(name) : true)
					.ToListAsync();
				

				response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
                response.IsSuccess = false;
            }
            return response;
        }
        public async Task<MainResponse> GetInfluencerServiceById(Guid id)
        {
            var response = new MainResponse();
            try
            {
                response.Content =
                    await (
                    from b in dbContext.InfluencerServices
                    join c in dbContext.Settings on b.TypeId equals c.Id
                    join v in dbContext.Settings on b.ServiceSettingId equals v.Id
                    select new
                    {
                        b.Id,
                        b.InfluencerId,
                        b.TypeId,
                        b.ServiceSettingId,
                        b.Amount,
                        b.DateCreated,
                        Type = c.Name,
                        ServiceSetting = v.Name,
                    })
                    .Where(bv => bv.InfluencerId == id)
                    .ToListAsync();

                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
                response.IsSuccess = false;
            }
            return response;
        }
        public async Task<MainResponse> GetInfluencerTimeTypeById(Guid id)
        {
            var response = new MainResponse();
            Guid typeId = new Guid("9A89ACE8-9AA3-4767-A25A-BFEAC9CAE8DE");
            try
            {
                response.Content =
                    await 
                    dbContext.InfluencerTime.Where(b => b.InfluencerId == id)
                    //from b in dbContext.Settings.Where(b => b.TypeId == typeId)
                    //from c in dbContext.InfluencerTime.DefaultIfEmpty()
                    //join c in dbContext.InfluencerTime.Where(b => b.InfluencerId == id)
                    //    on new { b.Id, id }
                    //    equals new { c.TimeSettingId, c.InfluencerId } into bc
                    //    on b.Id equals c.TimeSettingId into bc
                    //from v in bc.DefaultIfEmpty()
                    //where b.Id == c.TimeSettingId && id = c.InfluencerId
                    //select new (
                    //    b.Id,
                    //    b.TypeId,
                    //    b.Id = b..Where(b => b.InfluencerId == id).Select(b => b.TimeSettingId).SingleOrDefault()
                    //))
                    //.Where(bv => bv.TypeId == typeId)
                    .ToListAsync();
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
                response.IsSuccess = false;
            }
            return response;
        }
        public async Task<MainResponse> GetInfluencerRestDayById(Guid id)
        {
            var response = new MainResponse();
            try
            {
                response.Content =
                await dbContext.InfluencerRestDay
                    .Where(b => b.InfluencerId == id).ToListAsync();
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
                response.IsSuccess = false;
            }
            return response;
        }
    }
}
