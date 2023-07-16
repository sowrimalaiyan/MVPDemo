using MVP.BusinessEntities;
using DataAccessSql;
using System.Data.SqlClient;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;

namespace MVP.EntityRepositories
{
    class GetEmployeeDetailsSP : StoreProcHavingOutputParam
    {
        #region Constants        

        private const string Id = "Id";

        private const string Name = "Name";

        private const string PhoneNo = "PhoneNo";

        private const string HireDate = "HireDate";

        private const string IsAdmin = "IsAdmin";

        private const string IsActive = "IsActive";

        private const string CreatedBy = "CreatedBy";

        private const string CreatedAt = "CreatedAt";

        private const string UpdatedBy = "UpdatedBy";

        private const string UpdatedAt = "UpdatedAt";

        #endregion

        #region Members    

        private Guid? InpID { get; set; }

        private String InpName { get; set; }

        private EmployeeEntity Details { get; set; }

        public override OutputParams OutputParams { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="connectionString"></param>
        public GetEmployeeDetailsSP(string connectionString, RequestInput<EmployeeGetFilterEntity> ObjRequestInput)
            : base(connectionString)
        {
            StoreProcName = EmployeeProcedureNames.GetEmployeeDetails;
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
                GetEmployee(reader);
            }
        }

        public override async Task MapOutputAsync(SqlDataReader reader)
        {
            if (reader != null)
            {
                await GetEmployeeAsync(reader);
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
        public static DataSourceRequestEntities<EmployeeEntity> Execute(RequestInput<EmployeeGetFilterEntity> ObjRequestInput)
        {
            GetEmployeeDetailsSP sp = new GetEmployeeDetailsSP(ObjRequestInput.ClientUserInfo.ConnectionString, ObjRequestInput);
            sp.ExecuteSP();
            return DataSourceRequest.GetData(sp.Details, sp);
        }

        /// <summary>
        /// Execute Async used for calling web api
        /// </summary>
        /// <param name="ObjRequestInput"></param>
        /// <returns>AddressEntity with DataSourceRequestEntities</returns>
        public static async Task<DataSourceRequestEntities<EmployeeEntity>> ExecuteAsync(RequestInput<EmployeeGetFilterEntity> ObjRequestInput)
        {
            GetEmployeeDetailsSP sp = new GetEmployeeDetailsSP(ObjRequestInput.ClientUserInfo.ConnectionString, ObjRequestInput);
            await sp.ExecuteSPAsync().ConfigureAwait(false);
            return await DataSourceRequest.GetDataAsync(sp.Details, sp).ConfigureAwait(false);
        }

        #endregion

        #region  Helper Method for Retrieving Data 

        public async Task<EmployeeEntity> GetEmployeeAsync(SqlDataReader reader)
        {
            Details = new EmployeeEntity();
            if (reader != null)
            {
                while (await reader.ReadAsync())
                {
                    Details = BindEmployeeDetails(reader);
                }
            }
            return Details;
        }

        public EmployeeEntity GetEmployee(SqlDataReader reader)
        {
            Details = new EmployeeEntity();
            if (reader != null)
            {
                while (reader.Read())
                {
                    Details = BindEmployeeDetails(reader);
                }
            }
            return Details;
        }

        public EmployeeEntity BindEmployeeDetails(SqlDataReader reader)
        {
            EmployeeEntity ge = new EmployeeEntity
            {
                Id = HandleOutputParamValue<Guid>.Get(reader, Id),
                Name = HandleOutputParamValue<string>.Get(reader, Name),
                PhoneNo = HandleOutputParamValue<int>.Get(reader, PhoneNo),
                HireDate = HandleOutputParamValue<DateTime>.Get(reader, HireDate),
                IsAdmin = HandleOutputParamValue<bool>.Get(reader, IsAdmin),
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
