using System;
namespace GalleryApplication.Data.Common
{
    public interface IDeletable
    {
        bool IsDeleted { get; set; }
        DateTime? DeletedOn { get; set; }
    }
}
