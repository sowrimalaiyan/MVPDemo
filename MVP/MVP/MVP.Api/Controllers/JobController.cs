using DataAccessSql;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MVP.BusinessComponents;
using MVP.BusinessEntities;
using Newtonsoft.Json;

namespace MVP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    [EnableCors("OpenCORSPolicy")]
    public class JobController : ControllerBase
    {
        private readonly ILogger<JobController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IJobOperations _Joboperations;
        private readonly ClientInfo _clientInfo;

        public JobController(ILogger<JobController> logger, IConfiguration configuration, IJobOperations Joboperations)
        {
            _logger = logger;
            _Joboperations = Joboperations;
            _configuration = configuration;
            _clientInfo = new ClientInfo
            {
                ConnectionString = this._configuration.GetConnectionString("DefaultConnection")
            };
        }

        [HttpPost]
        [Route("get")]
        public ActionResult Get(JobGetFilterEntity Data)
        {
            try
            {
                RequestInput<JobGetFilterEntity> ObjRequestInput = new()
                {
                    Input = Data,
                    ClientUserInfo = _clientInfo
                };

                DataSourceRequestEntities<List<JobEntity>> Obj = _Joboperations.GetJobListing(ObjRequestInput);
                if (Obj.HasErrors)
                {
                    _logger.LogError(Obj.Errors.ErrorMessage);
                    return BadRequest(Obj.Errors.ErrorMessage);
                }
                return Ok(Obj.Data.Where(obj => obj.IsActive).ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("insert")]
        public async Task<ActionResult> InsertAsync([FromBody] JobInsertRequestEntity Data)
        {
            try
            {
                RequestInput<JobEntity> ObjRequestInput = new()
                {
                    Input = new JobEntity
                    {
                        Id = Guid.NewGuid(),
                        Name = Data.Name,
                        Description = Data.Description,
                        IsActive = true,
                        CreatedAt = DateTime.Now,
                        CreatedBy = Guid.Empty,
                        UpdatedAt = DateTime.Now,
                        UpdatedBy = Guid.Empty,
                    },
                    ClientUserInfo = _clientInfo
                };

                DataSourceRequestEntities<bool> Obj = await _Joboperations.InsertJobAsync(ObjRequestInput);
                if (Obj.HasErrors)
                {
                    _logger.LogError(Obj.Errors.ErrorMessage);
                    return BadRequest(Obj.Errors.ErrorMessage);
                }
                return Ok(Obj.PrimaryID);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("update")]
        public async Task<ActionResult> UpdateAsync([FromBody] JobRequestEntity Data)
        {
            try
            {
                RequestInput<JobEntity> ObjRequestInput = new()
                {
                    Input = new JobEntity
                    {
                        Id = Data.Id,
                        Name = Data.Name,
                        Description = Data.Description,
                        IsActive = true,
                        CreatedAt = DateTime.Now,
                        CreatedBy = Data.Id,
                        UpdatedAt = DateTime.Now,
                        UpdatedBy = Data.Id,
                    },
                    ClientUserInfo = _clientInfo
                };

                DataSourceRequestEntities<bool> Obj = await _Joboperations.UpdateJobAsync(ObjRequestInput);
                if (Obj.HasErrors)
                {
                    _logger.LogError(Obj.Errors.ErrorMessage);
                    return BadRequest(Obj.Errors.ErrorMessage);
                }
                return Ok(Obj.PrimaryID);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("delete")]
        public async Task<ActionResult> DeleteAsync(Guid Id)
        {
            try
            {
                RequestInput<JobEntity> ObjRequestInput = new()
                {
                    Input = new JobEntity
                    {
                        Id = Id,
                        UpdatedBy = Guid.NewGuid()
                    },
                    ClientUserInfo = _clientInfo
                };

                DataSourceRequestEntities<bool> Obj = await _Joboperations.DeleteJobAsync(ObjRequestInput);
                if (Obj.HasErrors)
                {
                    _logger.LogError(Obj.Errors.ErrorMessage);
                    return BadRequest(Obj.Errors.ErrorMessage);
                }
                return Ok(Obj.PrimaryID);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
