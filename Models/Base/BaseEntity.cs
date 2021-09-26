

using System;

namespace AssetManager.Models.Base 
{

    public abstract class BaseEntity {
    
        public int Id { get; protected set; }

        public DateTime DateCreated { get; protected set; }
        
        public DateTime? DateUpdated { get; protected set; }
    }

}