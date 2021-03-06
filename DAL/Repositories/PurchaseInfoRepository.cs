﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.Interfaces;
using NLevel;
using PurchaseInfoDTO = DAL.Models.PurchaseInfoDTO;
using AutoMapper;

namespace DAL.Repositories
{
    public class PurchaseInfoRepository : IRepository<PurchaseInfoDTO>
    {
        private StoreContext _container;

        public PurchaseInfoRepository()
        {
            _container = new StoreContext();
        }

         private static PurchaseInfoDTO ToObject(PurchaseInfo info)
        {
            if (info == null)
            {
                throw new ArgumentNullException("client cannot be null");
            }
            return Mapper.Map<PurchaseInfoDTO>(info);
        }

        private static PurchaseInfo ToEntity(PurchaseInfoDTO info)
        {
            if (info == null)
            {
                throw new ArgumentNullException("client cannot be null");
            }
            return Mapper.Map<PurchaseInfo>(info);
        }
        public PurchaseInfoDTO GetEntity(PurchaseInfoDTO purchaseInfo)
        {
            var entity = _container.PurchasesInfo.FirstOrDefault(x => x.Id == purchaseInfo.Id);
            return ToObject(entity);
        }

        public void Add(PurchaseInfoDTO dalEntity)
        {
            var info = ToEntity(dalEntity);
            _container.PurchasesInfo.Add(info);
            SaveChanges();
        }

        public void Remove(int id)
        {
            var info = _container.PurchasesInfo.Find(id);
            if (info != null) _container.PurchasesInfo.Remove(info);
            SaveChanges();
        }

        public PurchaseInfoDTO GetEntityById(int id)
        {
            return ToObject(_container.PurchasesInfo.Find(id));
        }

        public void SaveChanges()
        {
            _container.SaveChanges();
        }

        public void Update(PurchaseInfoDTO missingName)
        {

            _container.Entry(ToEntity(missingName)).State = EntityState.Modified;
        }

        public IEnumerable<PurchaseInfoDTO> GetAll()
        {
            foreach (var purchaseInfo in _container.PurchasesInfo)
            {
                yield return ToObject(purchaseInfo);
            }
        }

        public IEnumerable<PurchaseInfoDTO> Pagination(int begin, int amount)
        {
            var info1 = _container.PurchasesInfo.OrderBy(x => x.ProductId).Skip((begin - 1) * amount).Take(amount);
            foreach (var itenInfo in info1)
            {
                yield return ToObject(itenInfo);
            }
        }

        public PurchaseInfoDTO GetEntityByName(string name)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _container?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
