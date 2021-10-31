using System;


namespace AssetManager.Models.Base {

    public abstract class BaseEntity : IEquatable<BaseEntity> {
    
        public int Id { get; protected set; }

        public DateTime DateCreated { get; protected set; }
        
        public DateTime? DateUpdated { get; protected set; }


        public bool Equals(BaseEntity other) {
            if (other is null)
                return false;
            if (Id <= 0)
                return Object.ReferenceEquals(this, other);
            return this.Id == other.Id;
        }

        public override int GetHashCode() {
            if (Id <= 0)
                return base.GetHashCode();
            return this.Id.GetHashCode();
        }
    }

}