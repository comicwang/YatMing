using iTelluro.Explorer.YatMing.Application.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace iTelluro.Explorer.YatMing.Service
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IYatMingService”。
    [ServiceContract]
    public interface IYatMingService
    {
        #region TLogin

        /// <summary>
        /// 新增一条TLogin记录
        /// </summary>
        /// <param name="TLoginDTO">TLogin实体</param>
        /// <returns>是否新增成功</returns>
        [OperationContract]
        bool TLoginAdd(TLoginDTO TLoginDTO);

        /// <summary>
        /// 更新一条TLogin记录
        /// </summary>
        /// <param name="TLoginDTO">TLogin实体</param>
        /// <returns>是否更新成功</returns>
        [OperationContract]
        bool TLoginUpdate(TLoginDTO TLoginDTO);

        /// <summary>
        /// 根据主键删除一条TLogin记录
        /// </summary>
        /// <param name="guid">主键值</param>
        /// <returns>是否删除成功</returns>
        [OperationContract]
        bool TLoginDelete(string guid);

        /// <summary>
        /// 根据主键查询一条TLogin记录
        /// </summary>
        /// <param name="guid">主键值</param>
        /// <returns>查询的结果</returns>
        [OperationContract]
        TLoginDTO TLoginQueryById(string guid);

        /// <summary>
        /// 查询TLogin所有的记录
        /// </summary>
        /// <returns>TLogin的所有记录集合</returns>
        [OperationContract]
        List<TLoginDTO> TLoginQueryAll();

        [OperationContract]
        bool TLoginCheckLogin(string account, string psw, out string message, out TLoginDTO result);

        [OperationContract]
        bool TLoginCheckAccountExits(string account);

        [OperationContract]
        bool TLoginCheckUpdate(string currentVersion);

        [OperationContract]
        bool TLoginUpdateSys(out string[] uploadFileLst, out string[] deleteFileLst, out byte[][] fileContent);
        #endregion


        #region TCheck

        /// <summary>
        /// 新增一条TCheck记录
        /// </summary>
        /// <param name="TCheckDTO">TCheck实体</param>
        /// <returns>是否新增成功</returns>
        [OperationContract]
        bool TCheckAdd(TCheckDTO TCheckDTO);

        /// <summary>
        /// 更新一条TCheck记录
        /// </summary>
        /// <param name="TCheckDTO">TCheck实体</param>
        /// <returns>是否更新成功</returns>
        [OperationContract]
        bool TCheckUpdate(TCheckDTO TCheckDTO);

        /// <summary>
        /// 根据主键删除一条TCheck记录
        /// </summary>
        /// <param name="guid">主键值</param>
        /// <returns>是否删除成功</returns>
        [OperationContract]
        bool TCheckDelete(string guid);

        /// <summary>
        /// 根据主键查询一条TCheck记录
        /// </summary>
        /// <param name="guid">主键值</param>
        /// <returns>查询的结果</returns>
        [OperationContract]
        TCheckDTO TCheckQueryById(string guid);

        /// <summary>
        /// 查询TCheck所有的记录
        /// </summary>
        /// <returns>TCheck的所有记录集合</returns>
        [OperationContract]
        List<TCheckDTO> TCheckQueryAll();

        #endregion


        #region TBaseInfo

        /// <summary>
        /// 新增一条TBaseInfo记录
        /// </summary>
        /// <param name="TBaseInfoDTO">TBaseInfo实体</param>
        /// <returns>是否新增成功</returns>
        [OperationContract]
        bool TBaseInfoAdd(TBaseInfoDTO TBaseInfoDTO);

        /// <summary>
        /// 更新一条TBaseInfo记录
        /// </summary>
        /// <param name="TBaseInfoDTO">TBaseInfo实体</param>
        /// <returns>是否更新成功</returns>
        [OperationContract]
        bool TBaseInfoUpdate(TBaseInfoDTO TBaseInfoDTO);

        /// <summary>
        /// 根据主键删除一条TBaseInfo记录
        /// </summary>
        /// <param name="guid">主键值</param>
        /// <returns>是否删除成功</returns>
        [OperationContract]
        bool TBaseInfoDelete(string guid);

        /// <summary>
        /// 根据主键查询一条TBaseInfo记录
        /// </summary>
        /// <param name="guid">主键值</param>
        /// <returns>查询的结果</returns>
        [OperationContract]
        TBaseInfoDTO TBaseInfoQueryById(string guid);

        /// <summary>
        /// 查询TBaseInfo所有的记录
        /// </summary>
        /// <returns>TBaseInfo的所有记录集合</returns>
        [OperationContract]
        List<TBaseInfoDTO> TBaseInfoQueryAll();

        [OperationContract]
        List<TBaseInfoDTO> TBaseInfoQueryByKeyword(string key);

        #endregion


        #region TMerchantType

        /// <summary>
        /// 新增一条TMerchantType记录
        /// </summary>
        /// <param name="TMerchantTypeDTO">TMerchantType实体</param>
        /// <returns>是否新增成功</returns>
        [OperationContract]
        bool TMerchantTypeAdd(TMerchantTypeDTO TMerchantTypeDTO);

        /// <summary>
        /// 更新一条TMerchantType记录
        /// </summary>
        /// <param name="TMerchantTypeDTO">TMerchantType实体</param>
        /// <returns>是否更新成功</returns>
        [OperationContract]
        bool TMerchantTypeUpdate(TMerchantTypeDTO TMerchantTypeDTO);

        /// <summary>
        /// 根据主键删除一条TMerchantType记录
        /// </summary>
        /// <param name="guid">主键值</param>
        /// <returns>是否删除成功</returns>
        [OperationContract]
        bool TMerchantTypeDelete(string guid);

        /// <summary>
        /// 根据主键查询一条TMerchantType记录
        /// </summary>
        /// <param name="guid">主键值</param>
        /// <returns>查询的结果</returns>
        [OperationContract]
        TMerchantTypeDTO TMerchantTypeQueryById(string guid);

        /// <summary>
        /// 查询TMerchantType所有的记录
        /// </summary>
        /// <returns>TMerchantType的所有记录集合</returns>
        [OperationContract]
        List<TMerchantTypeDTO> TMerchantTypeQueryAll();

        [OperationContract]
        List<TMerchantTypeDTO> TMerchantTypeGetByPid(string pid);

        #endregion


        #region TDetailInfo

        /// <summary>
        /// 新增一条TDetailInfo记录
        /// </summary>
        /// <param name="TDetailInfoDTO">TDetailInfo实体</param>
        /// <returns>是否新增成功</returns>
        [OperationContract]
        bool TDetailInfoAdd(TDetailInfoDTO TDetailInfoDTO);

        /// <summary>
        /// 更新一条TDetailInfo记录
        /// </summary>
        /// <param name="TDetailInfoDTO">TDetailInfo实体</param>
        /// <returns>是否更新成功</returns>
        [OperationContract]
        bool TDetailInfoUpdate(TDetailInfoDTO TDetailInfoDTO);

        /// <summary>
        /// 根据主键删除一条TDetailInfo记录
        /// </summary>
        /// <param name="guid">主键值</param>
        /// <returns>是否删除成功</returns>
        [OperationContract]
        bool TDetailInfoDelete(string guid);

        /// <summary>
        /// 根据主键查询一条TDetailInfo记录
        /// </summary>
        /// <param name="guid">主键值</param>
        /// <returns>查询的结果</returns>
        [OperationContract]
        TDetailInfoDTO TDetailInfoQueryById(string guid);

        /// <summary>
        /// 查询TDetailInfo所有的记录
        /// </summary>
        /// <returns>TDetailInfo的所有记录集合</returns>
        [OperationContract]
        List<TDetailInfoDTO> TDetailInfoQueryAll();

        [OperationContract]
        TDetailInfoDTO TDetailInfoGetByForignKey(string id);

        #endregion


        #region TDataInfo

        /// <summary>
        /// 新增一条TDataInfo记录
        /// </summary>
        /// <param name="TDataInfoDTO">TDataInfo实体</param>
        /// <returns>是否新增成功</returns>
        [OperationContract]
        bool TDataInfoAdd(TDataInfoDTO TDataInfoDTO);

        /// <summary>
        /// 更新一条TDataInfo记录
        /// </summary>
        /// <param name="TDataInfoDTO">TDataInfo实体</param>
        /// <returns>是否更新成功</returns>
        [OperationContract]
        bool TDataInfoUpdate(TDataInfoDTO TDataInfoDTO);

        /// <summary>
        /// 根据主键删除一条TDataInfo记录
        /// </summary>
        /// <param name="guid">主键值</param>
        /// <returns>是否删除成功</returns>
        [OperationContract]
        bool TDataInfoDelete(string guid);

        /// <summary>
        /// 根据主键查询一条TDataInfo记录
        /// </summary>
        /// <param name="guid">主键值</param>
        /// <returns>查询的结果</returns>
        [OperationContract]
        TDataInfoDTO TDataInfoQueryById(string guid);

        /// <summary>
        /// 查询TDataInfo所有的记录
        /// </summary>
        /// <returns>TDataInfo的所有记录集合</returns>
        [OperationContract]
        List<TDataInfoDTO> TDataInfoQueryAll();

        [OperationContract]
        bool TDataInfoUploadFile(byte[] buffer, string metaId, int index);

        [OperationContract]
        bool TDataInfoDownloadFile(out byte[] outstream, long length, string metaId);

        [OperationContract]
        List<TDataInfoDTO> TDataInGetByForginKey(string key);

        [OperationContract]
        List<TDataInfoDTO> TDataInGetByParentKey(string key);

        [OperationContract]
        List<TDataInfoDTO> TDataInQuery(bool limit, DateTime start, DateTime end, string keyword, string baseId);

         [OperationContract]
        void TDataInDoConvert(string metaId);
        #endregion



        #region TPromotion

        /// <summary>
        /// 新增一条TPromotion记录
        /// </summary>
        /// <param name="TPromotionDTO">TPromotion实体</param>
        /// <returns>是否新增成功</returns>
        [OperationContract]
        bool TPromotionAdd(TPromotionDTO TPromotionDTO);

        /// <summary>
        /// 更新一条TPromotion记录
        /// </summary>
        /// <param name="TPromotionDTO">TPromotion实体</param>
        /// <returns>是否更新成功</returns>
        [OperationContract]
        bool TPromotionUpdate(TPromotionDTO TPromotionDTO);

        /// <summary>
        /// 根据主键删除一条TPromotion记录
        /// </summary>
        /// <param name="guid">主键值</param>
        /// <returns>是否删除成功</returns>
        [OperationContract]
        bool TPromotionDelete(string guid);

        /// <summary>
        /// 根据主键查询一条TPromotion记录
        /// </summary>
        /// <param name="guid">主键值</param>
        /// <returns>查询的结果</returns>
        [OperationContract]
        TPromotionDTO TPromotionQueryById(string guid);

        /// <summary>
        /// 查询TPromotion所有的记录
        /// </summary>
        /// <returns>TPromotion的所有记录集合</returns>
        [OperationContract]
        List<TPromotionDTO> TPromotionQueryAll();

        #endregion


        #region TPlatform

        /// <summary>
        /// 新增一条TPlatform记录
        /// </summary>
        /// <param name="TPlatformDTO">TPlatform实体</param>
        /// <returns>是否新增成功</returns>
        [OperationContract]
        bool TPlatformAdd(TPlatformDTO TPlatformDTO);

        /// <summary>
        /// 更新一条TPlatform记录
        /// </summary>
        /// <param name="TPlatformDTO">TPlatform实体</param>
        /// <returns>是否更新成功</returns>
        [OperationContract]
        bool TPlatformUpdate(TPlatformDTO TPlatformDTO);

        /// <summary>
        /// 根据主键删除一条TPlatform记录
        /// </summary>
        /// <param name="guid">主键值</param>
        /// <returns>是否删除成功</returns>
        [OperationContract]
        bool TPlatformDelete(string guid);

        /// <summary>
        /// 根据主键查询一条TPlatform记录
        /// </summary>
        /// <param name="guid">主键值</param>
        /// <returns>查询的结果</returns>
        [OperationContract]
        TPlatformDTO TPlatformQueryById(string guid);

        /// <summary>
        /// 查询TPlatform所有的记录
        /// </summary>
        /// <returns>TPlatform的所有记录集合</returns>
        [OperationContract]
        List<TPlatformDTO> TPlatformQueryAll();

        [OperationContract]
        List<TPlatformDTO> TPlatformGetByForignKey(string key);

        #endregion

        #region TRecorder

        /// <summary>
        /// 新增一条TRecorder记录
        /// </summary>
        /// <param name="TRecorderDTO">TRecorder实体</param>
        /// <returns>是否新增成功</returns>
        [OperationContract]
        bool TRecorderAdd(TRecorderDTO TRecorderDTO);

        /// <summary>
        /// 更新一条TRecorder记录
        /// </summary>
        /// <param name="TRecorderDTO">TRecorder实体</param>
        /// <returns>是否更新成功</returns>
        [OperationContract]
        bool TRecorderUpdate(TRecorderDTO TRecorderDTO);

        /// <summary>
        /// 根据主键删除一条TRecorder记录
        /// </summary>
        /// <param name="guid">主键值</param>
        /// <returns>是否删除成功</returns>
        [OperationContract]
        bool TRecorderDelete(string guid);

        /// <summary>
        /// 根据主键查询一条TRecorder记录
        /// </summary>
        /// <param name="guid">主键值</param>
        /// <returns>查询的结果</returns>
        [OperationContract]
        TRecorderDTO TRecorderQueryById(string guid);

        /// <summary>
        /// 查询TRecorder所有的记录
        /// </summary>
        /// <returns>TRecorder的所有记录集合</returns>
        [OperationContract]
        List<TRecorderDTO> TRecorderQueryAll();

        [OperationContract]
        List<TRecorderDTO> TRecorderGetByForignKey(string key);

        #endregion

        #region TShopData

        /// <summary>
        /// 新增一条TShopData记录
        /// </summary>
        /// <param name="TShopDataDTO">TShopData实体</param>
        /// <returns>是否新增成功</returns>
        [OperationContract]
        bool TShopDataAdd(TShopDataDTO TShopDataDTO);

        /// <summary>
        /// 更新一条TShopData记录
        /// </summary>
        /// <param name="TShopDataDTO">TShopData实体</param>
        /// <returns>是否更新成功</returns>
        [OperationContract]
        bool TShopDataUpdate(TShopDataDTO TShopDataDTO);

        /// <summary>
        /// 根据主键删除一条TShopData记录
        /// </summary>
        /// <param name="guid">主键值</param>
        /// <returns>是否删除成功</returns>
        [OperationContract]
        bool TShopDataDelete(string guid);

        /// <summary>
        /// 根据主键查询一条TShopData记录
        /// </summary>
        /// <param name="guid">主键值</param>
        /// <returns>查询的结果</returns>
        [OperationContract]
        TShopDataDTO TShopDataQueryById(string guid);

        /// <summary>
        /// 查询TShopData所有的记录
        /// </summary>
        /// <returns>TShopData的所有记录集合</returns>
        [OperationContract]
        List<TShopDataDTO> TShopDataQueryAll();

        #endregion


        #region TPrice

        /// <summary>
        /// 新增一条TPrice记录
        /// </summary>
        /// <param name="TPriceDTO">TPrice实体</param>
        /// <returns>是否新增成功</returns>
        [OperationContract]
        bool TPriceAdd(TPriceDTO TPriceDTO);

        /// <summary>
        /// 更新一条TPrice记录
        /// </summary>
        /// <param name="TPriceDTO">TPrice实体</param>
        /// <returns>是否更新成功</returns>
        [OperationContract]
        bool TPriceUpdate(TPriceDTO TPriceDTO);

        /// <summary>
        /// 根据主键删除一条TPrice记录
        /// </summary>
        /// <param name="guid">主键值</param>
        /// <returns>是否删除成功</returns>
        [OperationContract]
        bool TPriceDelete(string guid);

        /// <summary>
        /// 根据主键查询一条TPrice记录
        /// </summary>
        /// <param name="guid">主键值</param>
        /// <returns>查询的结果</returns>
        [OperationContract]
        TPriceDTO TPriceQueryById(string guid);

        /// <summary>
        /// 查询TPrice所有的记录
        /// </summary>
        /// <returns>TPrice的所有记录集合</returns>
        [OperationContract]
        List<TPriceDTO> TPriceQueryAll();

        #endregion


        #region TPackage

        /// <summary>
        /// 新增一条TPackage记录
        /// </summary>
        /// <param name="TPackageDTO">TPackage实体</param>
        /// <returns>是否新增成功</returns>
        [OperationContract]
        bool TPackageAdd(TPackageDTO TPackageDTO);

        /// <summary>
        /// 更新一条TPackage记录
        /// </summary>
        /// <param name="TPackageDTO">TPackage实体</param>
        /// <returns>是否更新成功</returns>
        [OperationContract]
        bool TPackageUpdate(TPackageDTO TPackageDTO);

        /// <summary>
        /// 根据主键删除一条TPackage记录
        /// </summary>
        /// <param name="guid">主键值</param>
        /// <returns>是否删除成功</returns>
        [OperationContract]
        bool TPackageDelete(string guid);

        /// <summary>
        /// 根据主键查询一条TPackage记录
        /// </summary>
        /// <param name="guid">主键值</param>
        /// <returns>查询的结果</returns>
        [OperationContract]
        TPackageDTO TPackageQueryById(string guid);

        /// <summary>
        /// 查询TPackage所有的记录
        /// </summary>
        /// <returns>TPackage的所有记录集合</returns>
        [OperationContract]
        List<TPackageDTO> TPackageQueryAll();

        #endregion


        #region THardware

        /// <summary>
        /// 新增一条THardware记录
        /// </summary>
        /// <param name="THardwareDTO">THardware实体</param>
        /// <returns>是否新增成功</returns>
        [OperationContract]
        bool THardwareAdd(THardwareDTO THardwareDTO);

        /// <summary>
        /// 更新一条THardware记录
        /// </summary>
        /// <param name="THardwareDTO">THardware实体</param>
        /// <returns>是否更新成功</returns>
        [OperationContract]
        bool THardwareUpdate(THardwareDTO THardwareDTO);

        /// <summary>
        /// 根据主键删除一条THardware记录
        /// </summary>
        /// <param name="guid">主键值</param>
        /// <returns>是否删除成功</returns>
        [OperationContract]
        bool THardwareDelete(string guid);

        /// <summary>
        /// 根据主键查询一条THardware记录
        /// </summary>
        /// <param name="guid">主键值</param>
        /// <returns>查询的结果</returns>
        [OperationContract]
        THardwareDTO THardwareQueryById(string guid);

        /// <summary>
        /// 查询THardware所有的记录
        /// </summary>
        /// <returns>THardware的所有记录集合</returns>
        [OperationContract]
        List<THardwareDTO> THardwareQueryAll();

        #endregion


        #region TContract

        /// <summary>
        /// 新增一条TContract记录
        /// </summary>
        /// <param name="TContractDTO">TContract实体</param>
        /// <returns>是否新增成功</returns>
        [OperationContract]
        bool TContractAdd(TContractDTO TContractDTO);

        /// <summary>
        /// 更新一条TContract记录
        /// </summary>
        /// <param name="TContractDTO">TContract实体</param>
        /// <returns>是否更新成功</returns>
        [OperationContract]
        bool TContractUpdate(TContractDTO TContractDTO);

        /// <summary>
        /// 根据主键删除一条TContract记录
        /// </summary>
        /// <param name="guid">主键值</param>
        /// <returns>是否删除成功</returns>
        [OperationContract]
        bool TContractDelete(string guid);

        /// <summary>
        /// 根据主键查询一条TContract记录
        /// </summary>
        /// <param name="guid">主键值</param>
        /// <returns>查询的结果</returns>
        [OperationContract]
        TContractDTO TContractQueryById(string guid);

        /// <summary>
        /// 查询TContract所有的记录
        /// </summary>
        /// <returns>TContract的所有记录集合</returns>
        [OperationContract]
        List<TContractDTO> TContractQueryAll();

        #endregion


        #region TSubmit

        /// <summary>
        /// 新增一条TSubmit记录
        /// </summary>
        /// <param name="TSubmitDTO">TSubmit实体</param>
        /// <returns>是否新增成功</returns>
        [OperationContract]
        bool TSubmitAdd(TSubmitDTO TSubmitDTO);

        /// <summary>
        /// 更新一条TSubmit记录
        /// </summary>
        /// <param name="TSubmitDTO">TSubmit实体</param>
        /// <returns>是否更新成功</returns>
        [OperationContract]
        bool TSubmitUpdate(TSubmitDTO TSubmitDTO);

        /// <summary>
        /// 根据主键删除一条TSubmit记录
        /// </summary>
        /// <param name="guid">主键值</param>
        /// <returns>是否删除成功</returns>
        [OperationContract]
        bool TSubmitDelete(string guid);

        /// <summary>
        /// 根据主键查询一条TSubmit记录
        /// </summary>
        /// <param name="guid">主键值</param>
        /// <returns>查询的结果</returns>
        [OperationContract]
        TSubmitDTO TSubmitQueryById(string guid);

        /// <summary>
        /// 查询TSubmit所有的记录
        /// </summary>
        /// <returns>TSubmit的所有记录集合</returns>
        [OperationContract]
        List<TSubmitDTO> TSubmitQueryAll();

        #endregion


        #region TServer

        /// <summary>
        /// 新增一条TServer记录
        /// </summary>
        /// <param name="TServerDTO">TServer实体</param>
        /// <returns>是否新增成功</returns>
        [OperationContract]
        bool TServerAdd(TServerDTO TServerDTO);

        /// <summary>
        /// 更新一条TServer记录
        /// </summary>
        /// <param name="TServerDTO">TServer实体</param>
        /// <returns>是否更新成功</returns>
        [OperationContract]
        bool TServerUpdate(TServerDTO TServerDTO);

        /// <summary>
        /// 根据主键删除一条TServer记录
        /// </summary>
        /// <param name="guid">主键值</param>
        /// <returns>是否删除成功</returns>
        [OperationContract]
        bool TServerDelete(string guid);

        /// <summary>
        /// 根据主键查询一条TServer记录
        /// </summary>
        /// <param name="guid">主键值</param>
        /// <returns>查询的结果</returns>
        [OperationContract]
        TServerDTO TServerQueryById(string guid);

        /// <summary>
        /// 查询TServer所有的记录
        /// </summary>
        /// <returns>TServer的所有记录集合</returns>
        [OperationContract]
        List<TServerDTO> TServerQueryAll();

        #endregion


        #region TTrain

        /// <summary>
        /// 新增一条TTrain记录
        /// </summary>
        /// <param name="TTrainDTO">TTrain实体</param>
        /// <returns>是否新增成功</returns>
        [OperationContract]
        bool TTrainAdd(TTrainDTO TTrainDTO);

        /// <summary>
        /// 更新一条TTrain记录
        /// </summary>
        /// <param name="TTrainDTO">TTrain实体</param>
        /// <returns>是否更新成功</returns>
        [OperationContract]
        bool TTrainUpdate(TTrainDTO TTrainDTO);

        /// <summary>
        /// 根据主键删除一条TTrain记录
        /// </summary>
        /// <param name="guid">主键值</param>
        /// <returns>是否删除成功</returns>
        [OperationContract]
        bool TTrainDelete(string guid);

        /// <summary>
        /// 根据主键查询一条TTrain记录
        /// </summary>
        /// <param name="guid">主键值</param>
        /// <returns>查询的结果</returns>
        [OperationContract]
        TTrainDTO TTrainQueryById(string guid);

        /// <summary>
        /// 查询TTrain所有的记录
        /// </summary>
        /// <returns>TTrain的所有记录集合</returns>
        [OperationContract]
        List<TTrainDTO> TTrainQueryAll();

        #endregion


        #region TEmployee

        /// <summary>
        /// 新增一条TEmployee记录
        /// </summary>
        /// <param name="TEmployeeDTO">TEmployee实体</param>
        /// <returns>是否新增成功</returns>
        [OperationContract]
        bool TEmployeeAdd(TEmployeeDTO TEmployeeDTO);

        /// <summary>
        /// 更新一条TEmployee记录
        /// </summary>
        /// <param name="TEmployeeDTO">TEmployee实体</param>
        /// <returns>是否更新成功</returns>
        [OperationContract]
        bool TEmployeeUpdate(TEmployeeDTO TEmployeeDTO);

        /// <summary>
        /// 根据主键删除一条TEmployee记录
        /// </summary>
        /// <param name="guid">主键值</param>
        /// <returns>是否删除成功</returns>
        [OperationContract]
        bool TEmployeeDelete(string guid);

        /// <summary>
        /// 根据主键查询一条TEmployee记录
        /// </summary>
        /// <param name="guid">主键值</param>
        /// <returns>查询的结果</returns>
        [OperationContract]
        TEmployeeDTO TEmployeeQueryById(string guid);

        /// <summary>
        /// 查询TEmployee所有的记录
        /// </summary>
        /// <returns>TEmployee的所有记录集合</returns>
        [OperationContract]
        List<TEmployeeDTO> TEmployeeQueryAll();

        #endregion
    }
}
