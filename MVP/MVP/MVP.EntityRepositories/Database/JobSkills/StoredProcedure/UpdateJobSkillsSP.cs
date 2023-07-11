using MVP.BusinessEntities;
using DataAccessSql;
using System.Data.SqlClient;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using System.Data;

namespace MVP.EntityRepositories
{
    class UpdateJobSkillsSP : StoreProcHavingOutputParam
    {
        #region Constants        

        #endregion

        #region Members    

        private Guid InpID { get; set; }

        private string InpName { get; set; }

        private string InpDescription { get; set; }


        private Guid InpUpdatedBy { get; set; }

        private DataTable InpSkills { get; set; }

        private bool Result { get; set; }

        public override OutputParams OutputParams { get; set; }


        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="CompanyId"></param>
        public UpdateJobSkillsSP(string connectionString, RequestInput<JobSkillsDtEntity> ObjRequestInput)
            : base(connectionString)
        {
            StoreProcName = JobSkillsProcedureNames.UpdateJobSkills;
            InpID = ObjRequestInput.Input.Id;
            InpName = ObjRequestInput.Input.Name;
            InpDescription = ObjRequestInput.Input.Description;
            InpUpdatedBy = ObjRequestInput.Input.UpdatedBy;
            InpSkills = ObjRequestInput.Input.SkillsDt;
            OutputParams = new OutputParams { ParamNameValuePairList = new Dictionary<string, object>() };
        }

        #endregion

        #region Map input
        public override bool MapInput()
        {
            AddInParameter("Id", ParamType.Guid, InpID);
            AddInParameter("Name", ParamType.String, InpName);
            AddInParameter("Description", ParamType.String, InpDescription);
            AddInParameter("UpdatedBy", ParamType.Guid, InpUpdatedBy);
            AddInParameter("Skills", ParamType.Structured, InpSkills);
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
        public static DataSourceRequestEntities<bool> Execute(RequestInput<JobSkillsDtEntity> ObjRequestInput)
        {
            UpdateJobSkillsSP sp = new UpdateJobSkillsSP(ObjRequestInput.ClientUserInfo.ConnectionString, ObjRequestInput);
            sp.ExecuteSP();
            sp.Result = sp.OutputParams.PrimaryID == Guid.Empty ? false : true;
            return DataSourceRequest.GetData(sp.Result, sp);
        }

        /// <summary>
        /// Execute Async used for calling web api
        /// </summary>
        /// <param name="ObjRequestInput"></param>
        /// <returns>AddressEntity with DataSourceRequestEntities</returns>
        public static async Task<DataSourceRequestEntities<bool>> ExecuteAsync(RequestInput<JobSkillsDtEntity> ObjRequestInput)
        {
            UpdateJobSkillsSP sp = new UpdateJobSkillsSP(ObjRequestInput.ClientUserInfo.ConnectionString, ObjRequestInput);
            await sp.ExecuteSPAsync().ConfigureAwait(false);
            sp.Result = sp.OutputParams.PrimaryID == Guid.Empty ? false : true;
            return await DataSourceRequest.GetDataAsync(sp.Result, sp).ConfigureAwait(false);
        }

        #endregion
    }
}
