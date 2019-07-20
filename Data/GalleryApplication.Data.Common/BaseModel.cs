using System;
namespace GalleryApplication.Data.Common
{
    public abstract class BaseModel<T>
    {
        public T Id { get; set; }
    }
}
