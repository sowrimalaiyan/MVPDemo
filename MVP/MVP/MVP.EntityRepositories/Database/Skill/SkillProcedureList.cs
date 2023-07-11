using DataAccessSql;
using MVP.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MVP.EntityRepositories
{
    class SkillProcedureList
    {
        public static async Task<DataSourceRequestEntities<bool>> InsertSkillAsync(RequestInput<SkillEntity> ObjRequestInput)
        {
            try
            {
                Task<DataSourceRequestEntities<bool>> Obj = InsertSkillSP.ExecuteAsync(ObjRequestInput);
                return await Obj.ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                return await DataSourceRequest.GetErrorDataAsync<bool>(false, ex.Message).ConfigureAwait(false);
            }
        }

        public static DataSourceRequestEntities<bool> InsertSkill(RequestInput<SkillEntity> ObjRequestInput)
        {
            try
            {
                DataSourceRequestEntities<bool> Obj = InsertSkillSP.Execute(ObjRequestInput);
                return Obj;
            }
            catch (Exception ex)
            {
                return DataSourceRequest.GetErrorData<bool>(false, ex.Message);
            }
        }

        public static async Task<DataSourceRequestEntities<bool>> UpdateSkillAsync(RequestInput<SkillEntity> ObjRequestInput)
        {
            try
            {
                Task<DataSourceRequestEntities<bool>> Obj = UpdateSkillSP.ExecuteAsync(ObjRequestInput);
                return await Obj.ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                return await DataSourceRequest.GetErrorDataAsync<bool>(false, ex.Message).ConfigureAwait(false);
            }
        }

        public static DataSourceRequestEntities<bool> UpdateSkill(RequestInput<SkillEntity> ObjRequestInput)
        {
            try
            {
                DataSourceRequestEntities<bool> Obj = UpdateSkillSP.Execute(ObjRequestInput);
                return Obj;
            }
            catch (Exception ex)
            {
                return DataSourceRequest.GetErrorData<bool>(false, ex.Message);
            }
        }

        public static async Task<DataSourceRequestEntities<bool>> DeleteSkillAsync(RequestInput<SkillEntity> ObjRequestInput)
        {
            try
            {
                Task<DataSourceRequestEntities<bool>> Obj = DeleteSkillSP.ExecuteAsync(ObjRequestInput);
                return await Obj.ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                return await DataSourceRequest.GetErrorDataAsync<bool>(false, ex.Message).ConfigureAwait(false);
            }
        }

        public static DataSourceRequestEntities<bool> DeleteSkill(RequestInput<SkillEntity> ObjRequestInput)
        {
            try
            {
                DataSourceRequestEntities<bool> Obj = DeleteSkillSP.Execute(ObjRequestInput);
                return Obj;
            }
            catch (Exception ex)
            {
                return DataSourceRequest.GetErrorData<bool>(false, ex.Message);
            }
        }

        public static async Task<DataSourceRequestEntities<List<SkillEntity>>> GetSkillListingAsync(RequestInput<SkillGetFilterEntity> ObjRequestInput)
        {
            try
            {
                Task<DataSourceRequestEntities<List<SkillEntity>>> Obj = GetSkillListingSP.ExecuteAsync(ObjRequestInput);
                return await Obj.ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                return await DataSourceRequest.GetErrorDataAsync<List<SkillEntity>>(new List<SkillEntity>(), ex.Message).ConfigureAwait(false);
            }
        }

        public static DataSourceRequestEntities<List<SkillEntity>> GetSkillListing(RequestInput<SkillGetFilterEntity> ObjRequestInput)
        {
            try
            {
                DataSourceRequestEntities<List<SkillEntity>> Obj = GetSkillListingSP.Execute(ObjRequestInput);
                return Obj;
            }
            catch (Exception ex)
            {
                return DataSourceRequest.GetErrorData<List<SkillEntity>>(new  List<SkillEntity>(), ex.Message);
            }
        }

        public static async Task<DataSourceRequestEntities<SkillEntity>> GetSkillDetailsAsync(RequestInput<SkillGetFilterEntity> ObjRequestInput)
        {
            try
            {
                Task<DataSourceRequestEntities<SkillEntity>> Obj = GetSkillDetailsSP.ExecuteAsync(ObjRequestInput);
                return await Obj.ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                return await DataSourceRequest.GetErrorDataAsync<SkillEntity>(new SkillEntity(), ex.Message).ConfigureAwait(false);
            }
        }

        public static DataSourceRequestEntities<SkillEntity> GetSkillDetails(RequestInput<SkillGetFilterEntity> ObjRequestInput)
        {
            try
            {
                DataSourceRequestEntities<SkillEntity> Obj = GetSkillDetailsSP.Execute(ObjRequestInput);
                return Obj;
            }
            catch (Exception ex)
            {
                return DataSourceRequest.GetErrorData<SkillEntity>(new SkillEntity(), ex.Message);
            }
        }
    }
}
