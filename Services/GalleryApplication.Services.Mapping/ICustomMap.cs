using System;
using AutoMapper;

namespace GalleryApplication.Services.Mapping
{
    public interface ICustomMap
    {
        void CreateMappings(IProfileExpression configuration);
    }
}
