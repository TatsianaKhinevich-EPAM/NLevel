﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using NLevel;
using Manager = DAL.Models.Manager;

namespace DAL.Repositories
{
    public class ManagerRepository : IRepository<Manager, NLevel.Manager>
    {
        private StoreContext _container;
        public ManagerRepository()
        {
            _container = new StoreContext();
        }

        private static Manager ToObject(NLevel.Manager manager)
        {
            return new Manager
            {
                Surname = manager.Surname
            };
        }

        private static NLevel.Manager ToEntity(Manager manager)
        {
            return new NLevel.Manager
            {
                Surname = manager.Surname
            };
        }

        public NLevel.Manager GetEntity(Manager manager)
        {
            var entity = _container.Managers.FirstOrDefault(x => x.Surname == manager.Surname);
            return entity;
        }

        public void Add(Manager dalEntity)
        {
            var manager = ToEntity(dalEntity);
            _container.Managers.Add(manager);
            SaveChanges();
        }

        public void Remove(Manager dalEntity)
        {
            var manager = ToEntity(dalEntity);
            _container.Managers.Remove(manager);
            SaveChanges();
        }

        public NLevel.Manager GetEntityById(int id)
        {
            var manager = _container.Managers.FirstOrDefault(mngr => mngr.Id == id);
            return manager;
        }

        public IEnumerable<Manager> GetEntities
        {
            get
            {
                var entities = new List<Manager>();
                foreach (var manager in _container.Managers.Select(x => x))
                {
                    entities.Add(ToObject(manager));
                }

                return entities;
            }
        }

        public void SaveChanges()
        {
            _container.SaveChanges();
        }

        public void Update(Manager missingName)
        {
            _container.Entry(missingName).State = EntityState.Modified;
        }

        public void Dispose()
        {
            _container?.Dispose();
            GC.SuppressFinalize(this);
        }

        ~ManagerRepository()
        {
            Dispose();
        }
    }
}