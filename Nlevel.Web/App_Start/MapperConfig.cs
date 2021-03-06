﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using DAL.Models;
using Nlevel.Web.Models;
using NLevel;

namespace Nlevel.Web
{
    public class MapperConfig
    {
        public static void ConfigDtoToEntities()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Client, ClientDTO>().ReverseMap();
                cfg.CreateMap<Manager, ManagerDTO>().ReverseMap();
                cfg.CreateMap<Product, ProductDTO>().ReverseMap();
                cfg.CreateMap<PurchaseInfo, PurchaseInfoDTO>().ReverseMap();
                cfg.CreateMap<PurchaseInfoDTO, PurchaseInfoViewModel>().ReverseMap();
                cfg.CreateMap<ProductDTO, ProductViewModel>().ReverseMap();
                cfg.CreateMap<ManagerDTO, ManagerViewModel>().ReverseMap();
                cfg.CreateMap<ClientDTO, ClientViewModel>().ReverseMap();
            });
            
        }
    }
}