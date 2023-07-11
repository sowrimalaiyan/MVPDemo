using MVP.BusinessEntities;
using DataAccessSql;
using System.Data.SqlClient;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;

namespace MVP.EntityRepositories
{
    class GetEmployeeSkillsListingSP : StoreProcHavingOutputParam
    {
        #region Constants        

        private const string EmployeeSkillId = "EmployeeSkillId";

        private const string Id = "Id";

        private const string Name = "Name";

        private const string Description = "Description";

        private const string IsActive = "IsActive";

        private const string CreatedBy = "CreatedBy";

        private const string CreatedAt = "CreatedAt";

        private const string UpdatedBy = "UpdatedBy";

        private const string UpdatedAt = "UpdatedAt";

        #endregion

        #region Members    

        private Guid? InpID { get; set; }

        private List<EmployeeSkillsEntity> Lists { get; set; }

        public override OutputParams OutputParams { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="CompanyId"></param>
        public GetEmployeeSkillsListingSP(string connectionString, RequestInput<EmployeeSkillsGetFilterEntity> ObjRequestInput)
            : base(connectionString)
        {
            StoreProcName = EmployeeSkillsProcedureNames.GetEmployeeSkillsListing;
            InpID = ObjRequestInput.Input.ID;
            OutputParams = new OutputParams { ParamNameValuePairList = new Dictionary<string, object>() };
        }

        #endregion

        #region Map input
        public override bool MapInput()
        {
            AddInParameter("Id", ParamType.Guid, InpID);
            GetErrorMessageOutputParam();
            return true;
        }
        #endregion

        #region Map output

        /// <summary>
        /// Map output parameters
        /// </summary>
        /// <param name="reader"></param>
        public override void MapOutput(SqlDataReader reader)
        {
            if (reader != null)
            {
                GetEmployeeSkills(reader);
            }
        }

        public override async Task MapOutputAsync(SqlDataReader reader)
        {
            if (reader != null)
            {
                await GetEmployeeSkillsAsync(reader);
            }
        }

        public override void MapOutputParam()
        {
        }

        #endregion

        #region Execute

        /// <summary>
        /// Execute
        /// </summary>
        /// <param name="ObjRequestInput"></param>
        /// <returns>AddressEntity with DataSourceRequestEntities</returns>
        public static DataSourceRequestEntities<List<EmployeeSkillsEntity>> Execute(RequestInput<EmployeeSkillsGetFilterEntity> ObjRequestInput)
        {
            GetEmployeeSkillsListingSP sp = new GetEmployeeSkillsListingSP(ObjRequestInput.ClientUserInfo.ConnectionString, ObjRequestInput);
            sp.ExecuteSP();
            return DataSourceRequest.GetData(sp.Lists, sp);
        }

        /// <summary>
        /// Execute Async used for calling web api
        /// </summary>
        /// <param name="ObjRequestInput"></param>
        /// <returns>AddressEntity with DataSourceRequestEntities</returns>
        public static async Task<DataSourceRequestEntities<List<EmployeeSkillsEntity>>> ExecuteAsync(RequestInput<EmployeeSkillsGetFilterEntity> ObjRequestInput)
        {
            GetEmployeeSkillsListingSP sp = new GetEmployeeSkillsListingSP(ObjRequestInput.ClientUserInfo.ConnectionString, ObjRequestInput);
            await sp.ExecuteSPAsync().ConfigureAwait(false);
            return await DataSourceRequest.GetDataAsync(sp.Lists, sp).ConfigureAwait(false);
        }

        #endregion

        #region  Helper Method for Retrieving Data 

        public async Task<List<EmployeeSkillsEntity>> GetEmployeeSkillsAsync(SqlDataReader reader)
        {
            Lists = new List<EmployeeSkillsEntity>();
            if (reader != null)
            {
                while (await reader.ReadAsync())
                {
                    Lists.Add(BindEmployeeSkillsDetails(reader));
                }
            }
            return Lists;
        }

        public List<EmployeeSkillsEntity> GetEmployeeSkills(SqlDataReader reader)
        {
            Lists = new List<EmployeeSkillsEntity>();
            if (reader != null)
            {
                while (reader.Read())
                {
                    Lists.Add(BindEmployeeSkillsDetails(reader));
                }
            }
            return Lists;
        }

        public EmployeeSkillsEntity BindEmployeeSkillsDetails(SqlDataReader reader)
        {
            EmployeeSkillsEntity ge = new EmployeeSkillsEntity
            {
                EmployeeSkillId = HandleOutputParamValue<Guid>.Get(reader, EmployeeSkillId),
                Id = HandleOutputParamValue<Guid>.Get(reader, Id),
                Name = HandleOutputParamValue<string>.Get(reader, Name),
                Description = HandleOutputParamValue<string>.Get(reader, Description),
                IsActive = HandleOutputParamValue<bool>.Get(reader, IsActive),
                CreatedBy = HandleOutputParamValue<Guid>.Get(reader, CreatedBy),
                CreatedAt = HandleOutputParamValue<DateTime>.Get(reader, CreatedAt),
                UpdatedBy = HandleOutputParamValue<Guid>.Get(reader, UpdatedBy),
                UpdatedAt = HandleOutputParamValue<DateTime>.Get(reader, UpdatedAt)
            };
            return ge;
        }

        #endregion
    }
}
