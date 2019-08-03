using System;
namespace GalleryApplication.Data.Common
{
    public abstract class BaseModel<T> : ICreatable
    {
        public T Id { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
