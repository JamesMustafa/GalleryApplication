using System;
namespace GalleryApplication.Data.Common
{
    public abstract class BaseDeletableModel<TKey> : BaseModel<TKey>, IDeletable
    {
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}
