using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.Entity
{
    public class BaseEntity<TPKType> where TPKType : struct
    {
        [Key]
        public TPKType Id { get; set; }

        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
    }
}
