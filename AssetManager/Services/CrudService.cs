using System.Collections.Generic;
using System.Linq;
using AssetManager.Data.Base;
using AssetManager.Models.Base;


namespace AssetManager.Services {

    public class CrudService<M> where M : BaseEntity {

        protected readonly IRepository<M> _repository;

        public CrudService(IRepository<M> repository) {
            _repository = repository;
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
}