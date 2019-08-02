using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoMapper;
using AutoMapper.Configuration;

namespace GalleryApplication.Services.Mapping
{
    public static class AutoMapperNewConfig
    {
        public static void Initialize()
        {
            var types = Assembly.GetExecutingAssembly().GetExportedTypes();

            var config = new MapperConfigurationExpression();
            config.CreateProfile(
                "ReflectionProfile",
                cfg =>
                {
                    cfg.AllowNullDestinationValues = false;
                    RegisterFromMaps(types, config);
                    RegisterToMaps(types, config);
                    RegisterCustomMaps(types, config);
                });

            Mapper.Initialize(config);
        }
        private static void RegisterFromMaps(IEnumerable<Type> types, IMapperConfigurationExpression expression)
        {
            var fromMaps = (from t in types
                            from i in t.GetTypeInfo().GetInterfaces()
                            where i.GetTypeInfo().IsGenericType &&
                                  i.GetGenericTypeDefinition() == typeof(IMapFrom<>) &&
                                  !t.GetTypeInfo().IsAbstract &&
                                  !t.GetTypeInfo().IsInterface
                            select new
                            {
                                Source = i.GetTypeInfo().GetGenericArguments()[0],
                                Destination = t,
                            }).ToArray();

            foreach (var map in fromMaps)
            {
                expression.CreateMap(map.Source, map.Destination);
            }

        }

        private static void RegisterToMaps(IEnumerable<Type> types, IMapperConfigurationExpression expression)
        {
            var toMaps = (from t in types
                         from i in t.GetTypeInfo().GetInterfaces()
                         where i.GetTypeInfo().IsGenericType &&
                               i.GetTypeInfo().GetGenericTypeDefinition() == typeof(IMapTo<>) &&
                               !t.GetTypeInfo().IsAbstract &&
                               !t.GetTypeInfo().IsInterface
                         select new 
                         {
                             Source = t,
                             Destination = i.GetTypeInfo().GetGenericArguments()[0],
                         }).ToArray();

            foreach (var map in toMaps)
            {
                expression.CreateMap(map.Source, map.Destination);
            }
        }

        private static void RegisterCustomMaps(IEnumerable<Type> types, IMapperConfigurationExpression expression)
        {
            var customMaps = (from t in types
                             from i in t.GetTypeInfo().GetInterfaces()
                             where typeof(ICustomMap).GetTypeInfo().IsAssignableFrom(t) &&
                                   !t.GetTypeInfo().IsAbstract &&
                                   !t.GetTypeInfo().IsInterface
                             select (ICustomMap)Activator.CreateInstance(t)).ToArray();

            foreach (var map in customMaps)
            {
                map.CreateMappings(expression);
            }
        }
    }
}
