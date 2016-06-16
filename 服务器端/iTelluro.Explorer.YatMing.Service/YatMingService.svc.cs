using iTelluro.Explorer.YatMing.Application.DTO;
using iTelluro.Explorer.YatMing.IApplication;
using iTelluro.Explorer.YatMing.Service.InstanceProviders;
using log4net;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace iTelluro.Explorer.YatMing.Service
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“YatMingService”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 YatMingService.svc 或 YatMingService.svc.cs，然后开始调试。
    [UnityInstanceProviderServiceBehavior]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class YatMingService : IYatMingService
    {
        #region TLogin

        /// <summary>
        /// 属性注入TLoginApp
        /// </summary>
        [Dependency]
        public ITLoginApp _TLoginApp { get; set; }

        /// <summary>
        /// 新增一条TLogin记录
        /// </summary>
        /// <param name="TLoginDTO">TLogin实体</param>
        /// <returns>是否新增成功</returns>
        public bool TLoginAdd(TLoginDTO TLoginDTO)
        {
            try
            {
                return _TLoginApp.Add(TLoginDTO);
            }
            catch (Exception ex)
            {
                ILog log = LogManager.GetLogger("YatMingSerice-" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name);
                log.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 根据主键删除一条TLogin记录
        /// </summary>
        /// <param name="guid">主键值</param>
        /// <returns>是否删除成功</returns>
        public bool TLoginDelete(string guid)
        {
            try
            {
                return _TLoginApp.Remove(guid);
            }
            catch (Exception ex)
            {
                ILog log = LogManager.GetLogger("YatMingSerice-" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name);
                log.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 更新一条TLogin记录
        /// </summary>
        /// <param name="TLoginDTO">TLogin实体</param>
        /// <returns>是否更新成功</returns>
        public bool TLoginUpdate(TLoginDTO TLoginDTO)
        {
            try
            {
                return _TLoginApp.Update(TLoginDTO);
            }
            catch (Exception ex)
            {
                ILog log = LogManager.GetLogger("YatMingSerice-" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name);
                log.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 根据主键查询一条TLogin记录
        /// </summary>
        /// <param name="guid">主键值</param>
        /// <returns>查询的实体结果</returns>
        public TLoginDTO TLoginQueryById(string guid)
        {
            try
            {
                return _TLoginApp.Get(guid);
            }
            catch (Exception ex)
            {
                ILog log = LogManager.GetLogger("YatMingSerice-" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name);
                log.Error(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// 查询所有的TLogin记录
        /// </summary>
        /// <returns>所有的TLogin结果集</returns>
        public List<TLoginDTO> TLoginQueryAll()
        {
            try
            {
                return _TLoginApp.GetAll();
            }
            catch (Exception ex)
            {
                ILog log = LogManager.GetLogger("YatMingSerice-" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name);
                log.Error(ex.Message);
                return null;
            }
        }

        public bool TLoginCheckLogin(string account, string psw, out string message, out TLoginDTO result)
        {
            try
            {
                return _TLoginApp.CheckLogin(account, psw, out message,out result);
            }
            catch (Exception ex)
            {
                ILog log = LogManager.GetLogger("YatMingSerice-" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name);
                log.Error(ex.Message);
                message = "服务器异常：" + ex.Message;
                result = null;
                return false;
            }
        }

        public bool TLoginCheckAccountExits(string account)
        {
            try
            {
                return _TLoginApp.CheckAccountExits(account);
            }
            catch (Exception ex)
            {
                ILog log = LogManager.GetLogger("YatMingSerice-" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name);
                log.Error(ex.Message);
                return false;
            }
        }

        public bool TLoginCheckUpdate(string currentVersion)
        {
             try
            {
                return _TLoginApp.CheckUpdate(currentVersion);
            }
            catch (Exception ex)
            {
                ILog log = LogManager.GetLogger("YatMingSerice-" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name);
                log.Error(ex.Message);
                return false;
            }
        }

        public bool TLoginUpdateSys(out string[] uploadFileLst, out string[] deleteFileLst, out byte[][] fileContent)
        {
            try
            {
                return _TLoginApp.Update(out uploadFileLst,out deleteFileLst ,out fileContent);
            }
            catch (Exception ex)
            {
                ILog log = LogManager.GetLogger("YatMingSerice-" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name);
                log.Error(ex.Message);
                fileContent = null;
                deleteFileLst = null;
                uploadFileLst=null;
                return false;
            }
        }

        #endregion


        #region TCheck

        /// <summary>
        /// 属性注入TCheckApp
        /// </summary>
        [Dependency]
        public ITCheckApp _TCheckApp { get; set; }

        /// <summary>
        /// 新增一条TCheck记录
        /// </summary>
        /// <param name="TCheckDTO">TCheck实体</param>
        /// <returns>是否新增成功</returns>
        public bool TCheckAdd(TCheckDTO TCheckDTO)
        {
            try
            {
                return _TCheckApp.Add(TCheckDTO);
            }
            catch (Exception ex)
            {
                ILog log = LogManager.GetLogger("YatMingSerice-" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name);
                log.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 根据主键删除一条TCheck记录
        /// </summary>
        /// <param name="guid">主键值</param>
        /// <returns>是否删除成功</returns>
        public bool TCheckDelete(string guid)
        {
            try
            {
                return _TCheckApp.Remove(guid);
            }
            catch (Exception ex)
            {
                ILog log = LogManager.GetLogger("YatMingSerice-" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name);
                log.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 更新一条TCheck记录
        /// </summary>
        /// <param name="TCheckDTO">TCheck实体</param>
        /// <returns>是否更新成功</returns>
        public bool TCheckUpdate(TCheckDTO TCheckDTO)
        {
            try
            {
                return _TCheckApp.Update(TCheckDTO);
            }
            catch (Exception ex)
            {
                ILog log = LogManager.GetLogger("YatMingSerice-" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name);
                log.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 根据主键查询一条TCheck记录
        /// </summary>
        /// <param name="guid">主键值</param>
        /// <returns>查询的实体结果</returns>
        public TCheckDTO TCheckQueryById(string guid)
        {
            try
            {
                return _TCheckApp.Get(guid);
            }
            catch (Exception ex)
            {
                ILog log = LogManager.GetLogger("YatMingSerice-" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name);
                log.Error(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// 查询所有的TCheck记录
        /// </summary>
        /// <returns>所有的TCheck结果集</returns>
        public List<TCheckDTO> TCheckQueryAll()
        {
            try
            {
                return _TCheckApp.GetAll();
            }
            catch (Exception ex)
            {
                ILog log = LogManager.GetLogger("YatMingSerice-" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name);
                log.Error(ex.Message);
                return null;
            }
        }

        #endregion


        #region TBaseInfo

        /// <summary>
        /// 属性注入TBaseInfoApp
        /// </summary>
        [Dependency]
        public ITBaseInfoApp _TBaseInfoApp { get; set; }

        /// <summary>
        /// 新增一条TBaseInfo记录
        /// </summary>
        /// <param name="TBaseInfoDTO">TBaseInfo实体</param>
        /// <returns>是否新增成功</returns>
        public bool TBaseInfoAdd(TBaseInfoDTO TBaseInfoDTO)
        {
            try
            {
                return _TBaseInfoApp.Add(TBaseInfoDTO);
            }
            catch (Exception ex)
            {
                ILog log = LogManager.GetLogger("YatMingSerice-" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name);
                log.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 根据主键删除一条TBaseInfo记录
        /// </summary>
        /// <param name="guid">主键值</param>
        /// <returns>是否删除成功</returns>
        public bool TBaseInfoDelete(string guid)
        {
            try
            {
                return _TBaseInfoApp.Remove(guid);
            }
            catch (Exception ex)
            {
                ILog log = LogManager.GetLogger("YatMingSerice-" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name);
                log.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 更新一条TBaseInfo记录
        /// </summary>
        /// <param name="TBaseInfoDTO">TBaseInfo实体</param>
        /// <returns>是否更新成功</returns>
        public bool TBaseInfoUpdate(TBaseInfoDTO TBaseInfoDTO)
        {
            try
            {
                return _TBaseInfoApp.Update(TBaseInfoDTO);
            }
            catch (Exception ex)
            {
                ILog log = LogManager.GetLogger("YatMingSerice-" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name);
                log.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 根据主键查询一条TBaseInfo记录
        /// </summary>
        /// <param name="guid">主键值</param>
        /// <returns>查询的实体结果</returns>
        public TBaseInfoDTO TBaseInfoQueryById(string guid)
        {
            try
            {
                return _TBaseInfoApp.Get(guid);
            }
            catch (Exception ex)
            {
                ILog log = LogManager.GetLogger("YatMingSerice-" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name);
                log.Error(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// 查询所有的TBaseInfo记录
        /// </summary>
        /// <returns>所有的TBaseInfo结果集</returns>
        public List<TBaseInfoDTO> TBaseInfoQueryAll()
        {
            try
            {
                return _TBaseInfoApp.GetAll();
            }
            catch (Exception ex)
            {
                ILog log = LogManager.GetLogger("YatMingSerice-" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name);
                log.Error(ex.Message);
                return null;
            }
        }

        public List<TBaseInfoDTO> TBaseInfoQueryByKeyword(string key)
        {
            try
            {
                return _TBaseInfoApp.QueryByKeyword(key);
            }
            catch (Exception ex)
            {
                ILog log = LogManager.GetLogger("YatMingSerice-" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name);
                log.Error(ex.Message);
                return null;
            }
        }

        #endregion


        #region TMerchantType

        /// <summary>
        /// 属性注入TMerchantTypeApp
        /// </summary>
        [Dependency]
        public ITMerchantTypeApp _TMerchantTypeApp { get; set; }

        /// <summary>
        /// 新增一条TMerchantType记录
        /// </summary>
        /// <param name="TMerchantTypeDTO">TMerchantType实体</param>
        /// <returns>是否新增成功</returns>
        public bool TMerchantTypeAdd(TMerchantTypeDTO TMerchantTypeDTO)
        {
            try
            {
                return _TMerchantTypeApp.Add(TMerchantTypeDTO);
            }
            catch (Exception ex)
            {
                ILog log = LogManager.GetLogger("YatMingSerice-" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name);
                log.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 根据主键删除一条TMerchantType记录
        /// </summary>
        /// <param name="guid">主键值</param>
        /// <returns>是否删除成功</returns>
        public bool TMerchantTypeDelete(string guid)
        {
            try
            {
                return _TMerchantTypeApp.Remove(guid);
            }
            catch (Exception ex)
            {
                ILog log = LogManager.GetLogger("YatMingSerice-" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name);
                log.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 更新一条TMerchantType记录
        /// </summary>
        /// <param name="TMerchantTypeDTO">TMerchantType实体</param>
        /// <returns>是否更新成功</returns>
        public bool TMerchantTypeUpdate(TMerchantTypeDTO TMerchantTypeDTO)
        {
            try
            {
                return _TMerchantTypeApp.Update(TMerchantTypeDTO);
            }
            catch (Exception ex)
            {
                ILog log = LogManager.GetLogger("YatMingSerice-" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name);
                log.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 根据主键查询一条TMerchantType记录
        /// </summary>
        /// <param name="guid">主键值</param>
        /// <returns>查询的实体结果</returns>
        public TMerchantTypeDTO TMerchantTypeQueryById(string guid)
        {
            try
            {
                return _TMerchantTypeApp.Get(guid);
            }
            catch (Exception ex)
            {
                ILog log = LogManager.GetLogger("YatMingSerice-" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name);
                log.Error(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// 查询所有的TMerchantType记录
        /// </summary>
        /// <returns>所有的TMerchantType结果集</returns>
        public List<TMerchantTypeDTO> TMerchantTypeQueryAll()
        {
            try
            {
                return _TMerchantTypeApp.GetAll();
            }
            catch (Exception ex)
            {
                ILog log = LogManager.GetLogger("YatMingSerice-" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name);
                log.Error(ex.Message);
                return null;
            }
        }

        public List<TMerchantTypeDTO> TMerchantTypeGetByPid(string pid)
        {
            try
            {
                return _TMerchantTypeApp.GetByPid(pid);
            }
            catch (Exception ex)
            {
                ILog log = LogManager.GetLogger("YatMingSerice-" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name);
                log.Error(ex.Message);
                return null;
            }
        }

        #endregion


        #region TDetailInfo

        /// <summary>
        /// 属性注入TDetailInfoApp
        /// </summary>
        [Dependency]
        public ITDetailInfoApp _TDetailInfoApp { get; set; }

        /// <summary>
        /// 新增一条TDetailInfo记录
        /// </summary>
        /// <param name="TDetailInfoDTO">TDetailInfo实体</param>
        /// <returns>是否新增成功</returns>
        public bool TDetailInfoAdd(TDetailInfoDTO TDetailInfoDTO)
        {
            try
            {
                return _TDetailInfoApp.Add(TDetailInfoDTO);
            }
            catch (Exception ex)
            {
                ILog log = LogManager.GetLogger("YatMingSerice-" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name);
                log.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 根据主键删除一条TDetailInfo记录
        /// </summary>
        /// <param name="guid">主键值</param>
        /// <returns>是否删除成功</returns>
        public bool TDetailInfoDelete(string guid)
        {
            try
            {
                return _TDetailInfoApp.Remove(guid);
            }
            catch (Exception ex)
            {
                ILog log = LogManager.GetLogger("YatMingSerice-" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name);
                log.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 更新一条TDetailInfo记录
        /// </summary>
        /// <param name="TDetailInfoDTO">TDetailInfo实体</param>
        /// <returns>是否更新成功</returns>
        public bool TDetailInfoUpdate(TDetailInfoDTO TDetailInfoDTO)
        {
            try
            {
                return _TDetailInfoApp.Update(TDetailInfoDTO);
            }
            catch (Exception ex)
            {
                ILog log = LogManager.GetLogger("YatMingSerice-" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name);
                log.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 根据主键查询一条TDetailInfo记录
        /// </summary>
        /// <param name="guid">主键值</param>
        /// <returns>查询的实体结果</returns>
        public TDetailInfoDTO TDetailInfoQueryById(string guid)
        {
            try
            {
                return _TDetailInfoApp.Get(guid);
            }
            catch (Exception ex)
            {
                ILog log = LogManager.GetLogger("YatMingSerice-" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name);
                log.Error(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// 查询所有的TDetailInfo记录
        /// </summary>
        /// <returns>所有的TDetailInfo结果集</returns>
        public List<TDetailInfoDTO> TDetailInfoQueryAll()
        {
            try
            {
                return _TDetailInfoApp.GetAll();
            }
            catch (Exception ex)
            {
                ILog log = LogManager.GetLogger("YatMingSerice-" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name);
                log.Error(ex.Message);
                return null;
            }
        }

        public TDetailInfoDTO TDetailInfoGetByForignKey(string id)
        {
            try
            {
                return _TDetailInfoApp.GetByForignKey(id);
            }
            catch (Exception ex)
            {
                ILog log = LogManager.GetLogger("YatMingSerice-" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name);
                log.Error(ex.Message);
                return null;
            }
        }

        #endregion


        #region TDataInfo

        /// <summary>
        /// 属性注入TDataInfoApp
        /// </summary>
        [Dependency]
        public ITDataInfoApp _TDataInfoApp { get; set; }

        /// <summary>
        /// 新增一条TDataInfo记录
        /// </summary>
        /// <param name="TDataInfoDTO">TDataInfo实体</param>
        /// <returns>是否新增成功</returns>
        public bool TDataInfoAdd(TDataInfoDTO TDataInfoDTO)
        {
            try
            {
                return _TDataInfoApp.Add(TDataInfoDTO);
            }
            catch (Exception ex)
            {
                ILog log = LogManager.GetLogger("YatMingSerice-" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name);
                log.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 根据主键删除一条TDataInfo记录
        /// </summary>
        /// <param name="guid">主键值</param>
        /// <returns>是否删除成功</returns>
        public bool TDataInfoDelete(string guid)
        {
            try
            {
                return _TDataInfoApp.Remove(guid);
            }
            catch (Exception ex)
            {
                ILog log = LogManager.GetLogger("YatMingSerice-" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name);
                log.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 更新一条TDataInfo记录
        /// </summary>
        /// <param name="TDataInfoDTO">TDataInfo实体</param>
        /// <returns>是否更新成功</returns>
        public bool TDataInfoUpdate(TDataInfoDTO TDataInfoDTO)
        {
            try
            {
                return _TDataInfoApp.Update(TDataInfoDTO);
            }
            catch (Exception ex)
            {
                ILog log = LogManager.GetLogger("YatMingSerice-" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name);
                log.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 根据主键查询一条TDataInfo记录
        /// </summary>
        /// <param name="guid">主键值</param>
        /// <returns>查询的实体结果</returns>
        public TDataInfoDTO TDataInfoQueryById(string guid)
        {
            try
            {
                return _TDataInfoApp.Get(guid);
            }
            catch (Exception ex)
            {
                ILog log = LogManager.GetLogger("YatMingSerice-" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name);
                log.Error(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// 查询所有的TDataInfo记录
        /// </summary>
        /// <returns>所有的TDataInfo结果集</returns>
        public List<TDataInfoDTO> TDataInfoQueryAll()
        {
            try
            {
                return _TDataInfoApp.GetAll();
            }
            catch (Exception ex)
            {
                ILog log = LogManager.GetLogger("YatMingSerice-" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name);
                log.Error(ex.Message);
                return null;
            }
        }

        public bool TDataInfoUploadFile(byte[] buffer, string metaId, int index)
        {
            try
            {
                return _TDataInfoApp.UploadFile(buffer, metaId, index);
            }
            catch (Exception ex)
            {
                ILog log = LogManager.GetLogger("YatMingSerice-" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name);
                log.Error(ex.Message);
                return false;
            }
        }

        public bool TDataInfoDownloadFile(out byte[] outstream, long length, string metaId)
        {
            try
            {
                return _TDataInfoApp.DownloadFile(out outstream, length, metaId);
            }
            catch (Exception ex)
            {
                ILog log = LogManager.GetLogger("YatMingSerice-" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name);
                log.Error(ex.Message);
                outstream = null;
                return false;
            }
        }

        public List<TDataInfoDTO> TDataInGetByForginKey(string key)
        {
            try
            {
                return _TDataInfoApp.GetByForginKey(key);
            }
            catch (Exception ex)
            {
                ILog log = LogManager.GetLogger("YatMingSerice-" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name);
                log.Error(ex.Message);
                return null;
            }
        }

        public List<TDataInfoDTO> TDataInGetByParentKey(string key)
        {
            try
            {
                return _TDataInfoApp.GetByParentKey(key);
            }
            catch (Exception ex)
            {
                ILog log = LogManager.GetLogger("YatMingSerice-" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name);
                log.Error(ex.Message);
                return null;
            }
        }

        public List<TDataInfoDTO> TDataInQuery(bool limit, DateTime start, DateTime end, string keyword, string baseId)
        {
            try
            {
                return _TDataInfoApp.Query(limit, start, end, keyword, baseId);
            }
            catch (Exception ex)
            {
                ILog log = LogManager.GetLogger("YatMingSerice-" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name);
                log.Error(ex.Message);
                return null;
            }
        }

        public void TDataInDoConvert(string metaId)
        {
            try
            {
                 _TDataInfoApp.DoConvert(metaId);
            }
            catch (Exception ex)
            {
                ILog log = LogManager.GetLogger("YatMingSerice-" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name);
                log.Error(ex.Message);            
            }
        }

        #endregion


        #region TPromotion

        /// <summary>
        /// 属性注入TPromotionApp
        /// </summary>
        [Dependency]
        public ITPromotionApp _TPromotionApp { get; set; }

        /// <summary>
        /// 新增一条TPromotion记录
        /// </summary>
        /// <param name="TPromotionDTO">TPromotion实体</param>
        /// <returns>是否新增成功</returns>
        public bool TPromotionAdd(TPromotionDTO TPromotionDTO)
        {
            try
            {
                return _TPromotionApp.Add(TPromotionDTO);
            }
            catch (Exception ex)
            {
                ILog log = LogManager.GetLogger("YatMingSerice-" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name);
                log.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 根据主键删除一条TPromotion记录
        /// </summary>
        /// <param name="guid">主键值</param>
        /// <returns>是否删除成功</returns>
        public bool TPromotionDelete(string guid)
        {
            try
            {
                return _TPromotionApp.Remove(guid);
            }
            catch (Exception ex)
            {
                ILog log = LogManager.GetLogger("YatMingSerice-" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name);
                log.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 更新一条TPromotion记录
        /// </summary>
        /// <param name="TPromotionDTO">TPromotion实体</param>
        /// <returns>是否更新成功</returns>
        public bool TPromotionUpdate(TPromotionDTO TPromotionDTO)
        {
            try
            {
                return _TPromotionApp.Update(TPromotionDTO);
            }
            catch (Exception ex)
            {
                ILog log = LogManager.GetLogger("YatMingSerice-" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name);
                log.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 根据主键查询一条TPromotion记录
        /// </summary>
        /// <param name="guid">主键值</param>
        /// <returns>查询的实体结果</returns>
        public TPromotionDTO TPromotionQueryById(string guid)
        {
            try
            {
                return _TPromotionApp.Get(guid);
            }
            catch (Exception ex)
            {
                ILog log = LogManager.GetLogger("YatMingSerice-" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name);
                log.Error(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// 查询所有的TPromotion记录
        /// </summary>
        /// <returns>所有的TPromotion结果集</returns>
        public List<TPromotionDTO> TPromotionQueryAll()
        {
            try
            {
                return _TPromotionApp.GetAll();
            }
            catch (Exception ex)
            {
                ILog log = LogManager.GetLogger("YatMingSerice-" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name);
                log.Error(ex.Message);
                return null;
            }
        }

        #endregion


        #region TPlatform

        /// <summary>
        /// 属性注入TPlatformApp
        /// </summary>
        [Dependency]
        public ITPlatformApp _TPlatformApp { get; set; }

        /// <summary>
        /// 新增一条TPlatform记录
        /// </summary>
        /// <param name="TPlatformDTO">TPlatform实体</param>
        /// <returns>是否新增成功</returns>
        public bool TPlatformAdd(TPlatformDTO TPlatformDTO)
        {
            try
            {
                return _TPlatformApp.Add(TPlatformDTO);
            }
            catch (Exception ex)
            {
                ILog log = LogManager.GetLogger("YatMingSerice-" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name);
                log.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 根据主键删除一条TPlatform记录
        /// </summary>
        /// <param name="guid">主键值</param>
        /// <returns>是否删除成功</returns>
        public bool TPlatformDelete(string guid)
        {
            try
            {
                return _TPlatformApp.Remove(guid);
            }
            catch (Exception ex)
            {
                ILog log = LogManager.GetLogger("YatMingSerice-" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name);
                log.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 更新一条TPlatform记录
        /// </summary>
        /// <param name="TPlatformDTO">TPlatform实体</param>
        /// <returns>是否更新成功</returns>
        public bool TPlatformUpdate(TPlatformDTO TPlatformDTO)
        {
            try
            {
                return _TPlatformApp.Update(TPlatformDTO);
            }
            catch (Exception ex)
            {
                ILog log = LogManager.GetLogger("YatMingSerice-" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name);
                log.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 根据主键查询一条TPlatform记录
        /// </summary>
        /// <param name="guid">主键值</param>
        /// <returns>查询的实体结果</returns>
        public TPlatformDTO TPlatformQueryById(string guid)
        {
            try
            {
                return _TPlatformApp.Get(guid);
            }
            catch (Exception ex)
            {
                ILog log = LogManager.GetLogger("YatMingSerice-" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name);
                log.Error(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// 查询所有的TPlatform记录
        /// </summary>
        /// <returns>所有的TPlatform结果集</returns>
        public List<TPlatformDTO> TPlatformQueryAll()
        {
            try
            {
                return _TPlatformApp.GetAll();
            }
            catch (Exception ex)
            {
                ILog log = LogManager.GetLogger("YatMingSerice-" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name);
                log.Error(ex.Message);
                return null;
            }
        }

        public List<TPlatformDTO> TPlatformGetByForignKey(string key)
        {
            try
            {
                return _TPlatformApp.GetByForignKey(key);
            }
            catch (Exception ex)
            {
                ILog log = LogManager.GetLogger("YatMingSerice-" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name);
                log.Error(ex.Message);
                return null;
            }
        }

        #endregion


        #region TShopData

        /// <summary>
        /// 属性注入TShopDataApp
        /// </summary>
        [Dependency]
        public ITShopDataApp _TShopDataApp { get; set; }

        /// <summary>
        /// 新增一条TShopData记录
        /// </summary>
        /// <param name="TShopDataDTO">TShopData实体</param>
        /// <returns>是否新增成功</returns>
        public bool TShopDataAdd(TShopDataDTO TShopDataDTO)
        {
            try
            {
                return _TShopDataApp.Add(TShopDataDTO);
            }
            catch (Exception ex)
            {
                ILog log = LogManager.GetLogger("YatMingSerice-" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name);
                log.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 根据主键删除一条TShopData记录
        /// </summary>
        /// <param name="guid">主键值</param>
        /// <returns>是否删除成功</returns>
        public bool TShopDataDelete(string guid)
        {
            try
            {
                return _TShopDataApp.Remove(guid);
            }
            catch (Exception ex)
            {
                ILog log = LogManager.GetLogger("YatMingSerice-" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name);
                log.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 更新一条TShopData记录
        /// </summary>
        /// <param name="TShopDataDTO">TShopData实体</param>
        /// <returns>是否更新成功</returns>
        public bool TShopDataUpdate(TShopDataDTO TShopDataDTO)
        {
            try
            {
                return _TShopDataApp.Update(TShopDataDTO);
            }
            catch (Exception ex)
            {
                ILog log = LogManager.GetLogger("YatMingSerice-" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name);
                log.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 根据主键查询一条TShopData记录
        /// </summary>
        /// <param name="guid">主键值</param>
        /// <returns>查询的实体结果</returns>
        public TShopDataDTO TShopDataQueryById(string guid)
        {
            try
            {
                return _TShopDataApp.Get(guid);
            }
            catch (Exception ex)
            {
                ILog log = LogManager.GetLogger("YatMingSerice-" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name);
                log.Error(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// 查询所有的TShopData记录
        /// </summary>
        /// <returns>所有的TShopData结果集</returns>
        public List<TShopDataDTO> TShopDataQueryAll()
        {
            try
            {
                return _TShopDataApp.GetAll();
            }
            catch (Exception ex)
            {
                ILog log = LogManager.GetLogger("YatMingSerice-" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name);
                log.Error(ex.Message);
                return null;
            }
        }

        #endregion


        #region TPrice

        /// <summary>
        /// 属性注入TPriceApp
        /// </summary>
        [Dependency]
        public ITPriceApp _TPriceApp { get; set; }

        /// <summary>
        /// 新增一条TPrice记录
        /// </summary>
        /// <param name="TPriceDTO">TPrice实体</param>
        /// <returns>是否新增成功</returns>
        public bool TPriceAdd(TPriceDTO TPriceDTO)
        {
            try
            {
                return _TPriceApp.Add(TPriceDTO);
            }
            catch (Exception ex)
            {
                ILog log = LogManager.GetLogger("YatMingSerice-" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name);
                log.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 根据主键删除一条TPrice记录
        /// </summary>
        /// <param name="guid">主键值</param>
        /// <returns>是否删除成功</returns>
        public bool TPriceDelete(string guid)
        {
            try
            {
                return _TPriceApp.Remove(guid);
            }
            catch (Exception ex)
            {
                ILog log = LogManager.GetLogger("YatMingSerice-" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name);
                log.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 更新一条TPrice记录
        /// </summary>
        /// <param name="TPriceDTO">TPrice实体</param>
        /// <returns>是否更新成功</returns>
        public bool TPriceUpdate(TPriceDTO TPriceDTO)
        {
            try
            {
                return _TPriceApp.Update(TPriceDTO);
            }
            catch (Exception ex)
            {
                ILog log = LogManager.GetLogger("YatMingSerice-" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name);
                log.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 根据主键查询一条TPrice记录
        /// </summary>
        /// <param name="guid">主键值</param>
        /// <returns>查询的实体结果</returns>
        public TPriceDTO TPriceQueryById(string guid)
        {
            try
            {
                return _TPriceApp.Get(guid);
            }
            catch (Exception ex)
            {
                ILog log = LogManager.GetLogger("YatMingSerice-" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name);
                log.Error(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// 查询所有的TPrice记录
        /// </summary>
        /// <returns>所有的TPrice结果集</returns>
        public List<TPriceDTO> TPriceQueryAll()
        {
            try
            {
                return _TPriceApp.GetAll();
            }
            catch (Exception ex)
            {
                ILog log = LogManager.GetLogger("YatMingSerice-" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name);
                log.Error(ex.Message);
                return null;
            }
        }

        #endregion


        #region TPackage

        /// <summary>
        /// 属性注入TPackageApp
        /// </summary>
        [Dependency]
        public ITPackageApp _TPackageApp { get; set; }

        /// <summary>
        /// 新增一条TPackage记录
        /// </summary>
        /// <param name="TPackageDTO">TPackage实体</param>
        /// <returns>是否新增成功</returns>
        public bool TPackageAdd(TPackageDTO TPackageDTO)
        {
            try
            {
                return _TPackageApp.Add(TPackageDTO);
            }
            catch (Exception ex)
            {
                ILog log = LogManager.GetLogger("YatMingSerice-" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name);
                log.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 根据主键删除一条TPackage记录
        /// </summary>
        /// <param name="guid">主键值</param>
        /// <returns>是否删除成功</returns>
        public bool TPackageDelete(string guid)
        {
            try
            {
                return _TPackageApp.Remove(guid);
            }
            catch (Exception ex)
            {
                ILog log = LogManager.GetLogger("YatMingSerice-" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name);
                log.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 更新一条TPackage记录
        /// </summary>
        /// <param name="TPackageDTO">TPackage实体</param>
        /// <returns>是否更新成功</returns>
        public bool TPackageUpdate(TPackageDTO TPackageDTO)
        {
            try
            {
                return _TPackageApp.Update(TPackageDTO);
            }
            catch (Exception ex)
            {
                ILog log = LogManager.GetLogger("YatMingSerice-" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name);
                log.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 根据主键查询一条TPackage记录
        /// </summary>
        /// <param name="guid">主键值</param>
        /// <returns>查询的实体结果</returns>
        public TPackageDTO TPackageQueryById(string guid)
        {
            try
            {
                return _TPackageApp.Get(guid);
            }
            catch (Exception ex)
            {
                ILog log = LogManager.GetLogger("YatMingSerice-" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name);
                log.Error(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// 查询所有的TPackage记录
        /// </summary>
        /// <returns>所有的TPackage结果集</returns>
        public List<TPackageDTO> TPackageQueryAll()
        {
            try
            {
                return _TPackageApp.GetAll();
            }
            catch (Exception ex)
            {
                ILog log = LogManager.GetLogger("YatMingSerice-" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name);
                log.Error(ex.Message);
                return null;
            }
        }

        #endregion


        #region THardware

        /// <summary>
        /// 属性注入THardwareApp
        /// </summary>
        [Dependency]
        public ITHardwareApp _THardwareApp { get; set; }

        /// <summary>
        /// 新增一条THardware记录
        /// </summary>
        /// <param name="THardwareDTO">THardware实体</param>
        /// <returns>是否新增成功</returns>
        public bool THardwareAdd(THardwareDTO THardwareDTO)
        {
            try
            {
                return _THardwareApp.Add(THardwareDTO);
            }
            catch (Exception ex)
            {
                ILog log = LogManager.GetLogger("YatMingSerice-" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name);
                log.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 根据主键删除一条THardware记录
        /// </summary>
        /// <param name="guid">主键值</param>
        /// <returns>是否删除成功</returns>
        public bool THardwareDelete(string guid)
        {
            try
            {
                return _THardwareApp.Remove(guid);
            }
            catch (Exception ex)
            {
                ILog log = LogManager.GetLogger("YatMingSerice-" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name);
                log.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 更新一条THardware记录
        /// </summary>
        /// <param name="THardwareDTO">THardware实体</param>
        /// <returns>是否更新成功</returns>
        public bool THardwareUpdate(THardwareDTO THardwareDTO)
        {
            try
            {
                return _THardwareApp.Update(THardwareDTO);
            }
            catch (Exception ex)
            {
                ILog log = LogManager.GetLogger("YatMingSerice-" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name);
                log.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 根据主键查询一条THardware记录
        /// </summary>
        /// <param name="guid">主键值</param>
        /// <returns>查询的实体结果</returns>
        public THardwareDTO THardwareQueryById(string guid)
        {
            try
            {
                return _THardwareApp.Get(guid);
            }
            catch (Exception ex)
            {
                ILog log = LogManager.GetLogger("YatMingSerice-" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name);
                log.Error(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// 查询所有的THardware记录
        /// </summary>
        /// <returns>所有的THardware结果集</returns>
        public List<THardwareDTO> THardwareQueryAll()
        {
            try
            {
                return _THardwareApp.GetAll();
            }
            catch (Exception ex)
            {
                ILog log = LogManager.GetLogger("YatMingSerice-" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name);
                log.Error(ex.Message);
                return null;
            }
        }

        #endregion


        #region TContract

        /// <summary>
        /// 属性注入TContractApp
        /// </summary>
        [Dependency]
        public ITContractApp _TContractApp { get; set; }

        /// <summary>
        /// 新增一条TContract记录
        /// </summary>
        /// <param name="TContractDTO">TContract实体</param>
        /// <returns>是否新增成功</returns>
        public bool TContractAdd(TContractDTO TContractDTO)
        {
            try
            {
                return _TContractApp.Add(TContractDTO);
            }
            catch (Exception ex)
            {
                ILog log = LogManager.GetLogger("YatMingSerice-" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name);
                log.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 根据主键删除一条TContract记录
        /// </summary>
        /// <param name="guid">主键值</param>
        /// <returns>是否删除成功</returns>
        public bool TContractDelete(string guid)
        {
            try
            {
                return _TContractApp.Remove(guid);
            }
            catch (Exception ex)
            {
                ILog log = LogManager.GetLogger("YatMingSerice-" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name);
                log.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 更新一条TContract记录
        /// </summary>
        /// <param name="TContractDTO">TContract实体</param>
        /// <returns>是否更新成功</returns>
        public bool TContractUpdate(TContractDTO TContractDTO)
        {
            try
            {
                return _TContractApp.Update(TContractDTO);
            }
            catch (Exception ex)
            {
                ILog log = LogManager.GetLogger("YatMingSerice-" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name);
                log.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 根据主键查询一条TContract记录
        /// </summary>
        /// <param name="guid">主键值</param>
        /// <returns>查询的实体结果</returns>
        public TContractDTO TContractQueryById(string guid)
        {
            try
            {
                return _TContractApp.Get(guid);
            }
            catch (Exception ex)
            {
                ILog log = LogManager.GetLogger("YatMingSerice-" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name);
                log.Error(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// 查询所有的TContract记录
        /// </summary>
        /// <returns>所有的TContract结果集</returns>
        public List<TContractDTO> TContractQueryAll()
        {
            try
            {
                return _TContractApp.GetAll();
            }
            catch (Exception ex)
            {
                ILog log = LogManager.GetLogger("YatMingSerice-" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name);
                log.Error(ex.Message);
                return null;
            }
        }

        #endregion


        #region TSubmit

        /// <summary>
        /// 属性注入TSubmitApp
        /// </summary>
        [Dependency]
        public ITSubmitApp _TSubmitApp { get; set; }

        /// <summary>
        /// 新增一条TSubmit记录
        /// </summary>
        /// <param name="TSubmitDTO">TSubmit实体</param>
        /// <returns>是否新增成功</returns>
        public bool TSubmitAdd(TSubmitDTO TSubmitDTO)
        {
            try
            {
                return _TSubmitApp.Add(TSubmitDTO);
            }
            catch (Exception ex)
            {
                ILog log = LogManager.GetLogger("YatMingSerice-" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name);
                log.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 根据主键删除一条TSubmit记录
        /// </summary>
        /// <param name="guid">主键值</param>
        /// <returns>是否删除成功</returns>
        public bool TSubmitDelete(string guid)
        {
            try
            {
                return _TSubmitApp.Remove(guid);
            }
            catch (Exception ex)
            {
                ILog log = LogManager.GetLogger("YatMingSerice-" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name);
                log.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 更新一条TSubmit记录
        /// </summary>
        /// <param name="TSubmitDTO">TSubmit实体</param>
        /// <returns>是否更新成功</returns>
        public bool TSubmitUpdate(TSubmitDTO TSubmitDTO)
        {
            try
            {
                return _TSubmitApp.Update(TSubmitDTO);
            }
            catch (Exception ex)
            {
                ILog log = LogManager.GetLogger("YatMingSerice-" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name);
                log.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 根据主键查询一条TSubmit记录
        /// </summary>
        /// <param name="guid">主键值</param>
        /// <returns>查询的实体结果</returns>
        public TSubmitDTO TSubmitQueryById(string guid)
        {
            try
            {
                return _TSubmitApp.Get(guid);
            }
            catch (Exception ex)
            {
                ILog log = LogManager.GetLogger("YatMingSerice-" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name);
                log.Error(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// 查询所有的TSubmit记录
        /// </summary>
        /// <returns>所有的TSubmit结果集</returns>
        public List<TSubmitDTO> TSubmitQueryAll()
        {
            try
            {
                return _TSubmitApp.GetAll();
            }
            catch (Exception ex)
            {
                ILog log = LogManager.GetLogger("YatMingSerice-" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name);
                log.Error(ex.Message);
                return null;
            }
        }

        #endregion


        #region TServer

        /// <summary>
        /// 属性注入TServerApp
        /// </summary>
        [Dependency]
        public ITServerApp _TServerApp { get; set; }

        /// <summary>
        /// 新增一条TServer记录
        /// </summary>
        /// <param name="TServerDTO">TServer实体</param>
        /// <returns>是否新增成功</returns>
        public bool TServerAdd(TServerDTO TServerDTO)
        {
            try
            {
                return _TServerApp.Add(TServerDTO);
            }
            catch (Exception ex)
            {
                ILog log = LogManager.GetLogger("YatMingSerice-" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name);
                log.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 根据主键删除一条TServer记录
        /// </summary>
        /// <param name="guid">主键值</param>
        /// <returns>是否删除成功</returns>
        public bool TServerDelete(string guid)
        {
            try
            {
                return _TServerApp.Remove(guid);
            }
            catch (Exception ex)
            {
                ILog log = LogManager.GetLogger("YatMingSerice-" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name);
                log.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 更新一条TServer记录
        /// </summary>
        /// <param name="TServerDTO">TServer实体</param>
        /// <returns>是否更新成功</returns>
        public bool TServerUpdate(TServerDTO TServerDTO)
        {
            try
            {
                return _TServerApp.Update(TServerDTO);
            }
            catch (Exception ex)
            {
                ILog log = LogManager.GetLogger("YatMingSerice-" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name);
                log.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 根据主键查询一条TServer记录
        /// </summary>
        /// <param name="guid">主键值</param>
        /// <returns>查询的实体结果</returns>
        public TServerDTO TServerQueryById(string guid)
        {
            try
            {
                return _TServerApp.Get(guid);
            }
            catch (Exception ex)
            {
                ILog log = LogManager.GetLogger("YatMingSerice-" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name);
                log.Error(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// 查询所有的TServer记录
        /// </summary>
        /// <returns>所有的TServer结果集</returns>
        public List<TServerDTO> TServerQueryAll()
        {
            try
            {
                return _TServerApp.GetAll();
            }
            catch (Exception ex)
            {
                ILog log = LogManager.GetLogger("YatMingSerice-" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name);
                log.Error(ex.Message);
                return null;
            }
        }

        #endregion


        #region TTrain

        /// <summary>
        /// 属性注入TTrainApp
        /// </summary>
        [Dependency]
        public ITTrainApp _TTrainApp { get; set; }

        /// <summary>
        /// 新增一条TTrain记录
        /// </summary>
        /// <param name="TTrainDTO">TTrain实体</param>
        /// <returns>是否新增成功</returns>
        public bool TTrainAdd(TTrainDTO TTrainDTO)
        {
            try
            {
                return _TTrainApp.Add(TTrainDTO);
            }
            catch (Exception ex)
            {
                ILog log = LogManager.GetLogger("YatMingSerice-" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name);
                log.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 根据主键删除一条TTrain记录
        /// </summary>
        /// <param name="guid">主键值</param>
        /// <returns>是否删除成功</returns>
        public bool TTrainDelete(string guid)
        {
            try
            {
                return _TTrainApp.Remove(guid);
            }
            catch (Exception ex)
            {
                ILog log = LogManager.GetLogger("YatMingSerice-" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name);
                log.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 更新一条TTrain记录
        /// </summary>
        /// <param name="TTrainDTO">TTrain实体</param>
        /// <returns>是否更新成功</returns>
        public bool TTrainUpdate(TTrainDTO TTrainDTO)
        {
            try
            {
                return _TTrainApp.Update(TTrainDTO);
            }
            catch (Exception ex)
            {
                ILog log = LogManager.GetLogger("YatMingSerice-" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name);
                log.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 根据主键查询一条TTrain记录
        /// </summary>
        /// <param name="guid">主键值</param>
        /// <returns>查询的实体结果</returns>
        public TTrainDTO TTrainQueryById(string guid)
        {
            try
            {
                return _TTrainApp.Get(guid);
            }
            catch (Exception ex)
            {
                ILog log = LogManager.GetLogger("YatMingSerice-" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name);
                log.Error(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// 查询所有的TTrain记录
        /// </summary>
        /// <returns>所有的TTrain结果集</returns>
        public List<TTrainDTO> TTrainQueryAll()
        {
            try
            {
                return _TTrainApp.GetAll();
            }
            catch (Exception ex)
            {
                ILog log = LogManager.GetLogger("YatMingSerice-" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name);
                log.Error(ex.Message);
                return null;
            }
        }

        #endregion


        #region TEmployee

        /// <summary>
        /// 属性注入TEmployeeApp
        /// </summary>
        [Dependency]
        public ITEmployeeApp _TEmployeeApp { get; set; }

        /// <summary>
        /// 新增一条TEmployee记录
        /// </summary>
        /// <param name="TEmployeeDTO">TEmployee实体</param>
        /// <returns>是否新增成功</returns>
        public bool TEmployeeAdd(TEmployeeDTO TEmployeeDTO)
        {
            try
            {
                return _TEmployeeApp.Add(TEmployeeDTO);
            }
            catch (Exception ex)
            {
                ILog log = LogManager.GetLogger("YatMingSerice-" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name);
                log.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 根据主键删除一条TEmployee记录
        /// </summary>
        /// <param name="guid">主键值</param>
        /// <returns>是否删除成功</returns>
        public bool TEmployeeDelete(string guid)
        {
            try
            {
                return _TEmployeeApp.Remove(guid);
            }
            catch (Exception ex)
            {
                ILog log = LogManager.GetLogger("YatMingSerice-" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name);
                log.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 更新一条TEmployee记录
        /// </summary>
        /// <param name="TEmployeeDTO">TEmployee实体</param>
        /// <returns>是否更新成功</returns>
        public bool TEmployeeUpdate(TEmployeeDTO TEmployeeDTO)
        {
            try
            {
                return _TEmployeeApp.Update(TEmployeeDTO);
            }
            catch (Exception ex)
            {
                ILog log = LogManager.GetLogger("YatMingSerice-" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name);
                log.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 根据主键查询一条TEmployee记录
        /// </summary>
        /// <param name="guid">主键值</param>
        /// <returns>查询的实体结果</returns>
        public TEmployeeDTO TEmployeeQueryById(string guid)
        {
            try
            {
                return _TEmployeeApp.Get(guid);
            }
            catch (Exception ex)
            {
                ILog log = LogManager.GetLogger("YatMingSerice-" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name);
                log.Error(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// 查询所有的TEmployee记录
        /// </summary>
        /// <returns>所有的TEmployee结果集</returns>
        public List<TEmployeeDTO> TEmployeeQueryAll()
        {
            try
            {
                return _TEmployeeApp.GetAll();
            }
            catch (Exception ex)
            {
                ILog log = LogManager.GetLogger("YatMingSerice-" + this.GetType().Name + "-" + MethodBase.GetCurrentMethod().Name);
                log.Error(ex.Message);
                return null;
            }
        }

        #endregion



    }
}
