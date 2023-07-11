using DataAccessSql;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MVP.BusinessComponents;
using MVP.BusinessEntities;
using Newtonsoft.Json;
using System.Data;

namespace MVP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    [EnableCors("OpenCORSPolicy")]
    public class JobSkillsController : ControllerBase
    {
        private readonly ILogger<JobSkillsController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IJobSkillsOperations _JobSkillsoperations;
        private readonly ClientInfo _clientInfo;

        public JobSkillsController(ILogger<JobSkillsController> logger, IConfiguration configuration, IJobSkillsOperations JobSkillsoperations)
        {
            _logger = logger;
            _JobSkillsoperations = JobSkillsoperations;
            _configuration = configuration;
            _clientInfo = new ClientInfo
            {
                ConnectionString = this._configuration.GetConnectionString("DefaultConnection")
            };
        }

        [HttpGet]
        public ActionResult Get(Guid Id)
        {
            try
            {
                RequestInput<JobSkillsGetFilterEntity> ObjRequestInput = new()
                {
                    Input = new JobSkillsGetFilterEntity
                    {
                        ID = Id
                    },
                    ClientUserInfo = _clientInfo
                };

                DataSourceRequestEntities<List<JobSkillsEntity>> Obj = _JobSkillsoperations.GetJobSkillsListing(ObjRequestInput);
                if (Obj.HasErrors)
                {
                    _logger.LogError(Obj.Errors.ErrorMessage);
                    return BadRequest(Obj.Errors.ErrorMessage);
                }
                return Ok(Obj.Data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("insert")]
        public async Task<ActionResult> InsertAsync([FromBody] JobSkillsInsertRequestEntity Data)
        {
            try
            {
                DataTable dt = new();
                dt.Columns.Add("ID");

                for (int i = 0; i < Data.Skills.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr["ID"] = Data.Skills[i].Id == null ? Guid.NewGuid() : Data.Skills[i].Id;
                    dt.Rows.Add(dr);
                }

                RequestInput<JobSkillsDtEntity> ObjRequestInput = new()
                {
                    Input = new JobSkillsDtEntity
                    {
                        Id = Guid.NewGuid(),
                        Name = Data.Name,
                        Description = Data.Description,
                        IsActive = true,
                        CreatedAt = DateTime.Now,
                        CreatedBy = Guid.Empty,
                        UpdatedAt = DateTime.Now,
                        UpdatedBy = Guid.Empty,
                        SkillsDt = dt
                    },
                    ClientUserInfo = _clientInfo
                };

                DataSourceRequestEntities<bool> Obj = await _JobSkillsoperations.InsertJobSkillsAsync(ObjRequestInput);
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
        public async Task<ActionResult> UpdateAsync([FromBody] JobSkillsRequestEntity Data)
        {
            try
            {
                DataTable dt = new();
                dt.Columns.Add("ID");

                for (int i = 0; i < Data.Skills.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr["ID"] = Data.Skills[i].Id == null ? Guid.NewGuid() : Data.Skills[i].Id;
                    dt.Rows.Add(dr);
                }

                RequestInput<JobSkillsDtEntity> ObjRequestInput = new()
                {
                    Input = new JobSkillsDtEntity
                    {
                        Id = Data.Id,
                        Name = Data.Name,
                        Description = Data.Description,
                        IsActive = true,
                        CreatedAt = DateTime.Now,
                        CreatedBy = Data.Id,
                        UpdatedAt = DateTime.Now,
                        UpdatedBy = Data.Id,
                        SkillsDt = dt
                    },
                    ClientUserInfo = _clientInfo
                };

                DataSourceRequestEntities<bool> Obj = await _JobSkillsoperations.UpdateJobSkillsAsync(ObjRequestInput);
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
                RequestInput<JobSkillsEntity> ObjRequestInput = new()
                {
                    Input = new JobSkillsEntity
                    {
                        Id = Id,
                        UpdatedBy = Guid.NewGuid()
                    },
                    ClientUserInfo = _clientInfo
                };

                DataSourceRequestEntities<bool> Obj = await _JobSkillsoperations.DeleteJobSkillsAsync(ObjRequestInput);
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
