
using AssetManager.Models.Base;

namespace AssetManager.Data.Base {

    public interface IValidatable<M> where M : BaseEntity {

        void ValidateDeletion(M entity);

        void ValidateCreateOrUpdate(M entity);

    }
}