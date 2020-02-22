using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Configuration;

namespace StackOverflowProject.ServiceLayer
{
    public static class MapperExtensions
    {
        public static void IgnoreUnmappedProperties(TypeMap map,IMappingExpression expr)
        {
            foreach(string propName in map.GetUnmappedPropertyNames())
            {
                if (map.SourceType.GetProperty(propName) != null)
                {
                    //expr.ForSourceMember(propName, opt => opt.Ignore());
                }
                if (map.DestinationType.GetProperty(propName) != null)
                {
                    //expr.ForSourceMember(propName, opt => opt.Ignore());
                }
            }
        }

        public static void IgnoreUnmapped(this IProfileExpression profile)
        {
            profile.ForAllMaps(IgnoreUnmappedProperties);
        }
    }
}
