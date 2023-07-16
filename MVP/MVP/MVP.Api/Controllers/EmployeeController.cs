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
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IEmployeeOperations _Employeeoperations;
        private readonly ClientInfo _clientInfo;

        public EmployeeController(ILogger<EmployeeController> logger, IConfiguration configuration, IEmployeeOperations Employeeoperations)
        {
            _logger = logger;
            _Employeeoperations = Employeeoperations;
            _configuration = configuration;
            _clientInfo = new ClientInfo
            {
                ConnectionString = this._configuration.GetConnectionString("DefaultConnection")
            };
        }

        [HttpPost]
        [Route("get")]
        public ActionResult Get(EmployeeGetFilterEntity Data)
        {
            try
            {
                RequestInput<EmployeeGetFilterEntity> ObjRequestInput = new()
                {
                    Input = Data,
                    ClientUserInfo = _clientInfo
                };

                DataSourceRequestEntities<List<EmployeeEntity>> Obj = _Employeeoperations.GetEmployeeListing(ObjRequestInput);
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
        public async Task<ActionResult> InsertAsync([FromBody] EmployeeInsertRequestEntity Data)
        {
            try
            {
                RequestInput<EmployeeEntity> ObjRequestInput = new()
                {
                    Input = new EmployeeEntity
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
                    },
                    ClientUserInfo = _clientInfo
                };

                DataSourceRequestEntities<bool> Obj = await _Employeeoperations.InsertEmployeeAsync(ObjRequestInput);
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
        public async Task<ActionResult> UpdateAsync([FromBody] EmployeeRequestEntity Data)
        {
            try
            {
                RequestInput<EmployeeEntity> ObjRequestInput = new()
                {
                    Input = new EmployeeEntity
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
                        UpdatedBy = Data.Id
                    },
                    ClientUserInfo = _clientInfo
                };

                DataSourceRequestEntities<bool> Obj = await _Employeeoperations.UpdateEmployeeAsync(ObjRequestInput);
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
                RequestInput<EmployeeEntity> ObjRequestInput = new()
                {
                    Input = new EmployeeEntity
                    {
                        Id = Id,
                        UpdatedBy = Guid.NewGuid()
                    },
                    ClientUserInfo = _clientInfo
                };

                DataSourceRequestEntities<bool> Obj = await _Employeeoperations.DeleteEmployeeAsync(ObjRequestInput);
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
