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
    public class EmployeeSkillsController : ControllerBase
    {
        private readonly ILogger<EmployeeSkillsController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IEmployeeSkillsOperations _EmployeeSkillsoperations;
        private readonly ClientInfo _clientInfo;

        public EmployeeSkillsController(ILogger<EmployeeSkillsController> logger, IConfiguration configuration, IEmployeeSkillsOperations EmployeeSkillsoperations)
        {
            _logger = logger;
            _EmployeeSkillsoperations = EmployeeSkillsoperations;
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
                RequestInput<EmployeeSkillsGetFilterEntity> ObjRequestInput = new()
                {
                    Input = new EmployeeSkillsGetFilterEntity
                    {
                        ID = Id
                    },
                    ClientUserInfo = _clientInfo
                };

                DataSourceRequestEntities<List<EmployeeSkillsEntity>> Obj = _EmployeeSkillsoperations.GetEmployeeSkillsListing(ObjRequestInput);
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
        public async Task<ActionResult> InsertAsync([FromBody] EmployeeSkillsInsertRequestEntity Data)
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

                RequestInput<EmployeeSkillsDtEntity> ObjRequestInput = new()
                {
                    Input = new EmployeeSkillsDtEntity
                    {
                        Id = Guid.NewGuid(),
                        Name = Data.Name,
                        PhoneNo = Data.PhoneNo,
                        HireDate = Data.HireDate,
                        IsAdmin = false,
                        IsActive = true,
                        CreatedAt = DateTime.Now,
                        CreatedBy = Guid.Empty,
                        UpdatedAt = DateTime.Now,
                        UpdatedBy = Guid.Empty,
                        SkillsDt = dt
                    },
                    ClientUserInfo = _clientInfo
                };

                DataSourceRequestEntities<bool> Obj = await _EmployeeSkillsoperations.InsertEmployeeSkillsAsync(ObjRequestInput);
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
        public async Task<ActionResult> UpdateAsync([FromBody] EmployeeSkillsRequestEntity Data)
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

                RequestInput<EmployeeSkillsDtEntity> ObjRequestInput = new()
                {
                    Input = new EmployeeSkillsDtEntity
                    {
                        Id = Data.Id,
                        Name = Data.Name,
                        PhoneNo = Data.PhoneNo,
                        HireDate = Data.HireDate,
                        IsAdmin = false,
                        IsActive = true,
                        CreatedAt = DateTime.Now,
                        CreatedBy = Data.Id,
                        UpdatedAt = DateTime.Now,
                        UpdatedBy = Data.Id,
                        SkillsDt = dt
                    },
                    ClientUserInfo = _clientInfo
                };

                DataSourceRequestEntities<bool> Obj = await _EmployeeSkillsoperations.UpdateEmployeeSkillsAsync(ObjRequestInput);
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
                RequestInput<EmployeeSkillsEntity> ObjRequestInput = new()
                {
                    Input = new EmployeeSkillsEntity
                    {
                        Id = entity.Id,
                        UpdatedBy = Guid.NewGuid()
                    },
                    ClientUserInfo = _clientInfo
                };

                DataSourceRequestEntities<bool> Obj = await _EmployeeSkillsoperations.DeleteEmployeeSkillsAsync(ObjRequestInput);
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
