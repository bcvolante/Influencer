using InfuencerAPI.Data;
using InfuencerAPI.Models.Master;
using InfuencerAPI.Models.MasterDTO;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Hosting;

namespace InfuencerAPI.Services
{
    public class SettingsService: ISettingsService
    {
        private readonly InfluencerDbContext dbContext;

        public SettingsService(InfluencerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<MainResponse> GetAll()
        {
            var response = new MainResponse();
            try
            {
                response.Content = await dbContext.Settings.ToListAsync();
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
                response.IsSuccess = false;
            }
            return response;
        }

        public async Task<MainResponse> GetById(Guid id)
        {
            var response = new MainResponse();
            try
            {
                response.Content =
                    await dbContext.Settings.Where(b => b.Id == id).FirstOrDefaultAsync();
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
                response.IsSuccess = false;
            }
            return response;
        }

        public async Task<MainResponse> FilterBy(Guid typeId)
        {
            var response = new MainResponse();
            try
            {
                response.Content =
                    await dbContext.Settings.Where(b => b.TypeId == typeId).ToListAsync();
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
                response.IsSuccess = false;
            }
            return response;
        }

        public async Task<MainResponse> GetIndustryWithData(Guid typeId)
        {
            var response = new MainResponse();
            try
            {
                response.Content =
                    await (
                    from b in dbContext.Settings
                    join v in dbContext.Influencer on b.Id equals v.IndustryId
                    select b
                    )
                    .Where(bv => bv.TypeId == typeId)
                    //.Where(b.TypeId = typeId)
                    .Distinct()
                    .ToListAsync();

                //response.Content =z
                //    await dbContext.Settings
                //    .Where(bv => bv.TypeId == typeId)
                //    .GroupJoin(dbContext.Influencer,
                //    b => b.Id,
                //    v => v.IndustryId,
                //    (b, v) => new
                //    .Select(b =>


                //    )
                //    .ToListAsync();

                //(from o in db.Track
                // join i in db.MediaType
                // on o.MediaTypeId equals i.MediaTypeId
                // select new
                // {
                //     Name = o.Name,
                //     Composer = o.Composer,
                //     MediaType = i.Name
                // }).Take(5);


                //var query = from b in context.Set<Blog>()
                //            from p in context.Set<Post>().Where(p => b.BlogId == p.BlogId)
                //            select new { b, p };


                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
                response.IsSuccess = false;
            }
            return response;
        }

        public async Task<MainResponse> Create(CreateSettingsRequest createSettingsRequest)
        {
            var response = new MainResponse();
            try
            {
                if (dbContext.Settings.Any(b =>
                    b.TypeId == createSettingsRequest.TypeId
                    && b.Name == createSettingsRequest.Name
                ))
                {
                    response.ErrorMessage = "Record already exists.";
                    response.IsSuccess = false;
                }
                else
                {
                    await dbContext.AddAsync(new Settings
                    {
                        TypeId = createSettingsRequest.TypeId,
                        Name = createSettingsRequest.Name,
                        Description = createSettingsRequest.Description,
                        ImagePath = createSettingsRequest.ImagePath
                    });
                    await dbContext.SaveChangesAsync();

                    response.IsSuccess = true;
                    response.Content = "Record successfully added.";
                }


            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
                response.IsSuccess = false;
            }

            return response;
        }
        public async Task<MainResponse> Update(UpdateSettingsRequest updateSettingsRequest)
        {
            var response = new MainResponse();
            try
            {
                var settings = dbContext.Settings.Where(b => b.Id == updateSettingsRequest.Id).FirstOrDefault();

                if (settings != null)
                {
                    settings.TypeId = updateSettingsRequest.TypeId;
                    settings.Name = updateSettingsRequest.Name;
                    settings.Description = updateSettingsRequest.Description;
                    settings.ImagePath = updateSettingsRequest.ImagePath;
                    settings.IsActive = updateSettingsRequest.IsActive;
                    await dbContext.SaveChangesAsync();

                    response.IsSuccess = true;
                    response.Content = "Record successfully updated.";
                }
                else
                {
                    response.IsSuccess = false;
                    response.Content = "Record not found.";
                }

            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
                response.IsSuccess = false;
            }

            return response;
        }

        public async Task<MainResponse> Delete(DeleteSettingsRequest deleteSettingsRequest)
        {
            var response = new MainResponse();
            try
            {
                var settings = dbContext.Settings.Where(b => b.Id == deleteSettingsRequest.Id).FirstOrDefault();

                if (settings != null)
                {
                    dbContext.Remove(settings);
                    await dbContext.SaveChangesAsync();

                    response.IsSuccess = true;
                    response.Content = "Record successfully deleted.";
                }
                else
                {
                    response.IsSuccess = false;
                    response.Content = "Record not found.";
                }

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
