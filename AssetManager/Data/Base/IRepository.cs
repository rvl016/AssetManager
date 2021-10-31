using System;
using System.Linq;
using System.Collections.Generic;
using AssetManager.Models.Base;

namespace AssetManager.Data.Base {

    public interface IRepository<M> : IDisposable where M : BaseEntity {

        IEnumerable<M> GetAll();

        IQueryable<M> GetQuerySet();

        M GetById(int id);

        void Create(M entity);

        void Update(M entity);

        void Delete(int id);

        void Delete(M entity);

        void Commit();

    }
}