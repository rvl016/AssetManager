using System;
using System.Linq;
using System.Collections.Generic;
using AssetManager.Models.Accounting;
using Microsoft.EntityFrameworkCore;
using AssetManager.Models.Base;
using System.ComponentModel.DataAnnotations;


namespace AssetManager.Data.Base {


    public abstract class BaseRepository<M> : 
        IRepository<M>, IValidatable<M>, IDisposable where M : BaseEntity 
    {
        
        private bool _isDisposed;
        
        protected readonly AssetManagerDbContext _dbContext;
        
        protected abstract DbSet<M> Records { get; }

        public BaseRepository(AssetManagerDbContext dbContext) {
            _dbContext = dbContext;
        }

        public IEnumerable<M> GetAll() {
            return Records.ToList();
        }

        public IQueryable<M> GetQuerySet() {
            return Records;
        }

        public M GetById(int id) {
            return Records.Find(id);
        }

        public void Create(M entity) {
            ValidateCreateOrUpdate(entity);
            _Create(entity);
        }

        protected virtual void _Create(M entity) {
            Records.Add(entity);
        }

        public void Delete(int id) {
            var entity = Records.First(e => e.Id == id);
            Delete(entity);
        }

        public void Delete(M entity) {
            ValidateDeletion(entity);
            _Delete(entity);
        }

        protected virtual void _Delete(M entity) {
            Records.Remove(entity);
        }

        public void Update(M entity) {
            ValidateCreateOrUpdate(entity);
            _Update(entity);
        }

        protected virtual void _Update(M entity) {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Commit() {
            _dbContext.SaveChanges();
        }

        public virtual void ValidateDeletion(M entity) {}

        public void Dispose() {
            Dispose(disposing: true);
            System.GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing) {
            if (! _isDisposed) {
                if (disposing)
                    _dbContext.Dispose();
                _isDisposed = true;
            }
        }

        public void ValidateCreateOrUpdate(M entity) {
            var validationResults = GetValidationErrors(entity);
            if (validationResults.Any())
                throw new ValidationException(validationResults.First(), null, entity);
        }

        public static IEnumerable<ValidationResult> GetValidationErrors(M entity) {
            var validationResults = new List<ValidationResult>();
            var context = new ValidationContext(entity);
            Validator.TryValidateObject(entity, context, validationResults, true);
            return validationResults;
        }
    }
}