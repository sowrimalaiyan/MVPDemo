using MVP.BusinessEntities;
using DataAccessSql;
using System.Data.SqlClient;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;

namespace MVP.EntityRepositories
{
    class DeleteJobSP : StoreProcHavingOutputParam
    {
        #region Constants        

        #endregion

        #region Members    

        private Guid InpID { get; set; }

        private string InpName { get; set; }

        private string InpDescription { get; set; }

        private Guid InpCreatedBy { get; set; }

        private Guid InpUpdatedBy { get; set; }

        private bool Result { get; set; }

        public override OutputParams OutputParams { get; set; }


        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="CompanyId"></param>
        public DeleteJobSP(string connectionString, RequestInput<JobEntity> ObjRequestInput)
            : base(connectionString)
        {
            StoreProcName = JobProcedureNames.DeleteJob;
            InpID = ObjRequestInput.Input.Id;
            InpUpdatedBy = ObjRequestInput.Input.UpdatedBy;
            OutputParams = new OutputParams { ParamNameValuePairList = new Dictionary<string, object>() };
        }

        #endregion

        #region Map input
        public override bool MapInput()
        {
            AddInParameter("Id", ParamType.Guid, InpID);
            AddInParameter("UpdatedBy", ParamType.Guid, InpUpdatedBy);
            GetPrimaryIDOutputParam();
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
            }
        }

        public override async Task MapOutputAsync(SqlDataReader reader)
        {
            if (reader != null)
            {
                await Task.FromResult(0);
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
        public static DataSourceRequestEntities<bool> Execute(RequestInput<JobEntity> ObjRequestInput)
        {
            DeleteJobSP sp = new DeleteJobSP(ObjRequestInput.ClientUserInfo.ConnectionString, ObjRequestInput);
            sp.ExecuteSP();
            sp.Result = sp.OutputParams.PrimaryID == Guid.Empty ? false : true;
            return DataSourceRequest.GetData(sp.Result, sp);
        }

        /// <summary>
        /// Execute Async used for calling web api
        /// </summary>
        /// <param name="ObjRequestInput"></param>
        /// <returns>AddressEntity with DataSourceRequestEntities</returns>
        public static async Task<DataSourceRequestEntities<bool>> ExecuteAsync(RequestInput<JobEntity> ObjRequestInput)
        {
            DeleteJobSP sp = new DeleteJobSP(ObjRequestInput.ClientUserInfo.ConnectionString, ObjRequestInput);
            await sp.ExecuteSPAsync().ConfigureAwait(false);
            sp.Result = sp.OutputParams.PrimaryID == Guid.Empty ? false : true;
            return await DataSourceRequest.GetDataAsync(sp.Result, sp).ConfigureAwait(false);
        }

        #endregion
    }
}
