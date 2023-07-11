using MVP.BusinessEntities;
using DataAccessSql;
using System.Data.SqlClient;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;

namespace MVP.EntityRepositories
{
    class GetJobListingSP : StoreProcHavingOutputParam
    {
        #region Constants        

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

        private String InpName { get; set; }

        private List<JobEntity> Lists { get; set; }

        public override OutputParams OutputParams { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="CompanyId"></param>
        public GetJobListingSP(string connectionString, RequestInput<JobGetFilterEntity> ObjRequestInput)
            : base(connectionString)
        {
            StoreProcName = JobProcedureNames.GetJobListing;
            InpID = ObjRequestInput.Input.ID;
            InpName = ObjRequestInput.Input.Name;
            OutputParams = new OutputParams { ParamNameValuePairList = new Dictionary<string, object>() };
        }

        #endregion

        #region Map input
        public override bool MapInput()
        {
            AddInParameter("Id", ParamType.Guid, InpID);
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
                GetApplicationConfig(reader);
            }
        }

        public override async Task MapOutputAsync(SqlDataReader reader)
        {
            if (reader != null)
            {
                await GetApplicationConfigAsync(reader);
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
        public static DataSourceRequestEntities<List<JobEntity>> Execute(RequestInput<JobGetFilterEntity> ObjRequestInput)
        {
            GetJobListingSP sp = new GetJobListingSP(ObjRequestInput.ClientUserInfo.ConnectionString, ObjRequestInput);
            sp.ExecuteSP();
            return DataSourceRequest.GetData(sp.Lists, sp);
        }

        /// <summary>
        /// Execute Async used for calling web api
        /// </summary>
        /// <param name="ObjRequestInput"></param>
        /// <returns>AddressEntity with DataSourceRequestEntities</returns>
        public static async Task<DataSourceRequestEntities<List<JobEntity>>> ExecuteAsync(RequestInput<JobGetFilterEntity> ObjRequestInput)
        {
            GetJobListingSP sp = new GetJobListingSP(ObjRequestInput.ClientUserInfo.ConnectionString, ObjRequestInput);
            await sp.ExecuteSPAsync().ConfigureAwait(false);
            return await DataSourceRequest.GetDataAsync(sp.Lists, sp).ConfigureAwait(false);
        }

        #endregion

        #region  Helper Method for Retrieving Data 

        public async Task<List<JobEntity>> GetApplicationConfigAsync(SqlDataReader reader)
        {
            Lists = new List<JobEntity>();
            if (reader != null)
            {
                while (await reader.ReadAsync())
                {
                    Lists.Add(BindApplicationConfigDetails(reader));
                }
            }
            return Lists;
        }

        public List<JobEntity> GetApplicationConfig(SqlDataReader reader)
        {
            Lists = new List<JobEntity>();
            if (reader != null)
            {
                while (reader.Read())
                {
                    Lists.Add(BindApplicationConfigDetails(reader));
                }
            }
            return Lists;
        }

        public JobEntity BindApplicationConfigDetails(SqlDataReader reader)
        {
            JobEntity ge = new JobEntity
            {
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
