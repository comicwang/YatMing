using AutoMapper;
using iTelluro.Explorer.YatMing.Application.DTO;
using iTelluro.Explorer.YatMing.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iTelluro.Explorer.YatMing.Application.DTO
{
    public class YatMingProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<T_Login, TLoginDTO>();
            Mapper.CreateMap<TLoginDTO, T_Login>();


            Mapper.CreateMap<T_Check, TCheckDTO>();
            Mapper.CreateMap<TCheckDTO, T_Check>();


            Mapper.CreateMap<T_BaseInfo, TBaseInfoDTO>();
            Mapper.CreateMap<TBaseInfoDTO, T_BaseInfo>();


            Mapper.CreateMap<T_MerchantType, TMerchantTypeDTO>();
            Mapper.CreateMap<TMerchantTypeDTO, T_MerchantType>();


            Mapper.CreateMap<T_DetailInfo, TDetailInfoDTO>();
            Mapper.CreateMap<TDetailInfoDTO, T_DetailInfo>();


            Mapper.CreateMap<T_DataInfo, TDataInfoDTO>();
            Mapper.CreateMap<TDataInfoDTO, T_DataInfo>();

            Mapper.CreateMap<T_Promotion, TPromotionDTO>();
            Mapper.CreateMap<TPromotionDTO, T_Promotion>();


            Mapper.CreateMap<T_Platform, TPlatformDTO>();
            Mapper.CreateMap<TPlatformDTO, T_Platform>();


            Mapper.CreateMap<T_ShopData, TShopDataDTO>();
            Mapper.CreateMap<TShopDataDTO, T_ShopData>();


            Mapper.CreateMap<T_Price, TPriceDTO>();
            Mapper.CreateMap<TPriceDTO, T_Price>();


            Mapper.CreateMap<T_Package, TPackageDTO>();
            Mapper.CreateMap<TPackageDTO, T_Package>();


            Mapper.CreateMap<T_Hardware, THardwareDTO>();
            Mapper.CreateMap<THardwareDTO, T_Hardware>();


            Mapper.CreateMap<T_Contract, TContractDTO>();
            Mapper.CreateMap<TContractDTO, T_Contract>();


            Mapper.CreateMap<T_Submit, TSubmitDTO>();
            Mapper.CreateMap<TSubmitDTO, T_Submit>();


            Mapper.CreateMap<T_Server, TServerDTO>();
            Mapper.CreateMap<TServerDTO, T_Server>();


            Mapper.CreateMap<T_Train, TTrainDTO>();
            Mapper.CreateMap<TTrainDTO, T_Train>();


            Mapper.CreateMap<T_Employee, TEmployeeDTO>();
            Mapper.CreateMap<TEmployeeDTO, T_Employee>();

            Mapper.CreateMap<T_Recorder, TRecorderDTO>();
            Mapper.CreateMap<TRecorderDTO, T_Recorder>();

        }
    }
}
