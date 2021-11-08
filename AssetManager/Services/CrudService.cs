using System;
using System.Collections.Generic;
using System.Linq;
using AssetManager.Data.Base;
using AssetManager.Models.Base;


namespace AssetManager.Services {

    public class CrudService<M> : ICrudService<M> where M : BaseEntity {

        protected readonly IRepository<M> _repository;

        public bool DoCommitOnDispose { get; set; } = true;

        public CrudService(IRepository<M> repository) {
            _repository = repository;
        }

        public void Dispose() {
            // TODO: Find an alternative to Dispose
            if (DoCommitOnDispose)
                _repository.Commit();
        }

        public IEnumerable<M> GetAll() {
            return _repository.GetAll();
        }

        public IQueryable<M> GetQuerySet() {
            return _repository.GetQuerySet();
        }

        public M GetById(int id) {
            return _repository.GetById(id);
        }

        public void CreateOrUpdate(M entity) {
            if (entity.Id == 0)
                Create(entity);
            else
                Update(entity);
        }

        public void Create(M entity) {
            _repository.Create(entity);            
        }

        public void Update(M entity) {
            _repository.Update(entity);        
        }

        public void Delete(M entity) {
            _repository.Delete(entity);
        }

    }


    public interface ICrudService<M> : IDisposable {
    
        IEnumerable<M> GetAll();

        IQueryable<M> GetQuerySet();

        M GetById(int id);

        void CreateOrUpdate(M entity);

        void Create(M entity);

        void Update(M entity);

        void Delete(M entity);

    }
}