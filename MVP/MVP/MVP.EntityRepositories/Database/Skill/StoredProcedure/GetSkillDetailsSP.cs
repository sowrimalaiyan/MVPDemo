using MVP.BusinessEntities;
using DataAccessSql;
using System.Data.SqlClient;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;

namespace MVP.EntityRepositories
{
    class GetSkillDetailsSP : StoreProcHavingOutputParam
    {
        #region Constants        

        private const string Id = "Id";

        private const string Name = "Name";

        private const string Description = "Description";

        private const string IsActive = "IsActive";

        private const string CreatedBy = "CreatedBy";

        private const string CreatedOn = "CreatedOn";

        private const string UpdatedBy = "UpdatedBy";

        private const string UpdatedOn = "UpdatedOn";

        #endregion

        #region Members    

        private Guid? InpID { get; set; }

        private String InpName { get; set; }

        private SkillEntity Details { get; set; }

        public override OutputParams OutputParams { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="connectionString"></param>
        public GetSkillDetailsSP(string connectionString, RequestInput<SkillGetFilterEntity> ObjRequestInput)
            : base(connectionString)
        {
            StoreProcName = SkillProcedureNames.GetSkillDetails;
            InpID = ObjRequestInput.Input.ID;
            InpName = ObjRequestInput.Input.Name;
            OutputParams = new OutputParams { ParamNameValuePairList = new Dictionary<string, object>() };
        }

        #endregion

        #region Map input
        public override bool MapInput()
        {
            AddInParameter("Id", ParamType.Int16, InpID);
            AddInParameter("Name", ParamType.String, InpName);
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
                GetSkill(reader);
            }
        }

        public override async Task MapOutputAsync(SqlDataReader reader)
        {
            if (reader != null)
            {
                await GetSkillAsync(reader);
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
        public static DataSourceRequestEntities<SkillEntity> Execute(RequestInput<SkillGetFilterEntity> ObjRequestInput)
        {
            GetSkillDetailsSP sp = new GetSkillDetailsSP(ObjRequestInput.ClientUserInfo.ConnectionString, ObjRequestInput);
            sp.ExecuteSP();
            return DataSourceRequest.GetData(sp.Details, sp);
        }

        /// <summary>
        /// Execute Async used for calling web api
        /// </summary>
        /// <param name="ObjRequestInput"></param>
        /// <returns>AddressEntity with DataSourceRequestEntities</returns>
        public static async Task<DataSourceRequestEntities<SkillEntity>> ExecuteAsync(RequestInput<SkillGetFilterEntity> ObjRequestInput)
        {
            GetSkillDetailsSP sp = new GetSkillDetailsSP(ObjRequestInput.ClientUserInfo.ConnectionString, ObjRequestInput);
            await sp.ExecuteSPAsync().ConfigureAwait(false);
            return await DataSourceRequest.GetDataAsync(sp.Details, sp).ConfigureAwait(false);
        }

        #endregion

        #region  Helper Method for Retrieving Data 

        public async Task<SkillEntity> GetSkillAsync(SqlDataReader reader)
        {
            Details = new SkillEntity();
            if (reader != null)
            {
                while (await reader.ReadAsync())
                {
                    Details = BindSkillDetails(reader);
                }
            }
            return Details;
        }

        public SkillEntity GetSkill(SqlDataReader reader)
        {
            Details = new SkillEntity();
            if (reader != null)
            {
                while (reader.Read())
                {
                    Details = BindSkillDetails(reader);
                }
            }
            return Details;
        }

        public SkillEntity BindSkillDetails(SqlDataReader reader)
        {
            SkillEntity ge = new SkillEntity
            {
                Id = HandleOutputParamValue<Guid>.Get(reader, Id),
                Name = HandleOutputParamValue<string>.Get(reader, Name),
                Description = HandleOutputParamValue<string>.Get(reader, Description),
                IsActive = HandleOutputParamValue<bool>.Get(reader, IsActive),
                CreatedBy = HandleOutputParamValue<Guid>.Get(reader, CreatedBy),
                CreatedAt = HandleOutputParamValue<DateTime>.Get(reader, CreatedOn),
                UpdatedBy = HandleOutputParamValue<Guid>.Get(reader, UpdatedBy),
                UpdatedAt = HandleOutputParamValue<DateTime>.Get(reader, UpdatedOn)
            };
            return ge;
        }

        #endregion
    }
}
