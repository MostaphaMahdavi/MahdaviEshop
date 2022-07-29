using System;
namespace MahdaviEshop.Framework.Entities
{
    public abstract class BaseEntity<TKey>
    {
        public TKey Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public long CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public long UpdatedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public long DeletedBy { get; set; }
    }

    public abstract class BaseEntity : BaseEntity<long>
    {

    }

}
