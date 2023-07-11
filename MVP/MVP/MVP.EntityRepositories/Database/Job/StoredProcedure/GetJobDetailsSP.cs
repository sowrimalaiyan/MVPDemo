using MVP.BusinessEntities;
using DataAccessSql;
using System.Data.SqlClient;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;

namespace MVP.EntityRepositories
{
    class GetJobDetailsSP : StoreProcHavingOutputParam
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

        private JobEntity Details { get; set; }

        public override OutputParams OutputParams { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="connectionString"></param>
        public GetJobDetailsSP(string connectionString, RequestInput<JobGetFilterEntity> ObjRequestInput)
            : base(connectionString)
        {
            StoreProcName = JobProcedureNames.GetJobDetails;
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
                GetJob(reader);
            }
        }

        public override async Task MapOutputAsync(SqlDataReader reader)
        {
            if (reader != null)
            {
                await GetJobAsync(reader);
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
        public static DataSourceRequestEntities<JobEntity> Execute(RequestInput<JobGetFilterEntity> ObjRequestInput)
        {
            GetJobDetailsSP sp = new GetJobDetailsSP(ObjRequestInput.ClientUserInfo.ConnectionString, ObjRequestInput);
            sp.ExecuteSP();
            return DataSourceRequest.GetData(sp.Details, sp);
        }

        /// <summary>
        /// Execute Async used for calling web api
        /// </summary>
        /// <param name="ObjRequestInput"></param>
        /// <returns>AddressEntity with DataSourceRequestEntities</returns>
        public static async Task<DataSourceRequestEntities<JobEntity>> ExecuteAsync(RequestInput<JobGetFilterEntity> ObjRequestInput)
        {
            GetJobDetailsSP sp = new GetJobDetailsSP(ObjRequestInput.ClientUserInfo.ConnectionString, ObjRequestInput);
            await sp.ExecuteSPAsync().ConfigureAwait(false);
            return await DataSourceRequest.GetDataAsync(sp.Details, sp).ConfigureAwait(false);
        }

        #endregion

        #region  Helper Method for Retrieving Data 

        public async Task<JobEntity> GetJobAsync(SqlDataReader reader)
        {
            Details = new JobEntity();
            if (reader != null)
            {
                while (await reader.ReadAsync())
                {
                    Details = BindJobDetails(reader);
                }
            }
            return Details;
        }

        public JobEntity GetJob(SqlDataReader reader)
        {
            Details = new JobEntity();
            if (reader != null)
            {
                while (reader.Read())
                {
                    Details = BindJobDetails(reader);
                }
            }
            return Details;
        }

        public JobEntity BindJobDetails(SqlDataReader reader)
        {
            JobEntity ge = new JobEntity
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
