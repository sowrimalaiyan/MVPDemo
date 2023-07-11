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
    public class SkillsController : ControllerBase
    {
        private readonly ILogger<SkillsController> _logger;
        private readonly IConfiguration _configuration;
        private readonly ISkillOperations _skilloperations;
        private readonly ClientInfo _clientInfo;

        public SkillsController(ILogger<SkillsController> logger, IConfiguration configuration, ISkillOperations skilloperations)
        {
            _logger = logger;
            _skilloperations = skilloperations;
            _configuration = configuration;
            _clientInfo = new ClientInfo
            {
                ConnectionString = this._configuration.GetConnectionString("DefaultConnection")
            };
        }

        [HttpPost]
        [Route("get")]
        [AllowAnonymous]
        public ActionResult Get(SkillGetFilterEntity Data)
        {
            try
            {
                RequestInput<SkillGetFilterEntity> ObjRequestInput = new()
                {
                    Input = Data,
                    ClientUserInfo = _clientInfo
                };

                DataSourceRequestEntities<List<SkillEntity>> Obj = _skilloperations.GetSkillListing(ObjRequestInput);
                if (Obj.HasErrors)
                {
                    _logger.LogError(Obj.Errors.ErrorMessage);
                    return BadRequest(Obj.Errors.ErrorMessage);
                }
                return Ok(Obj.Data.Where(obj=>obj.IsActive).ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("insert")]
        public async Task<ActionResult> InsertAsync([FromBody] SkillInsertRequestEntity Data)
        {
            try
            {
                RequestInput<SkillEntity> ObjRequestInput = new()
                {
                    Input = new SkillEntity
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

                DataSourceRequestEntities<bool> Obj = await _skilloperations.InsertSkillAsync(ObjRequestInput);
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
        public async Task<ActionResult> UpdateAsync([FromBody] SkillRequestEntity Data)
        {
            try
            {
                RequestInput<SkillEntity> ObjRequestInput = new()
                {
                    Input = new SkillEntity
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

                DataSourceRequestEntities<bool> Obj = await _skilloperations.UpdateSkillAsync(ObjRequestInput);
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
        public async Task<ActionResult> DeleteAsync(SkillIdEntity entity)
        {
            try
            {
                RequestInput<SkillEntity> ObjRequestInput = new()
                {
                    Input = new SkillEntity
                    {
                        Id = entity.Id,
                        UpdatedBy = Guid.NewGuid()
                    },
                    ClientUserInfo = _clientInfo
                };

                DataSourceRequestEntities<bool> Obj = await _skilloperations.DeleteSkillAsync(ObjRequestInput);
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
