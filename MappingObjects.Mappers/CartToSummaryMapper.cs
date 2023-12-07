using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper; // MapperConfiguration
using AutoMapper.Internal; // Internal() extension method
using ALLinONE.Entities; // Cart
using ALLinONE.ViewModels;
using System.Reflection.Metadata.Ecma335;
using AutoMapper.Configuration.Conventions; // Summary

namespace MappingObjects.Mappers;

public static class CartToSummaryMapper
{
    public static MapperConfiguration GetMapperConfiguration()
    {
        MapperConfiguration config = new(cfg =>
        {
            cfg.Internal().MethodMappingEnabled = false;

            // configuring Mapper using projections
            cfg.CreateMap<Cart, Summary>()
            //FullName
            .ForMember(does => does.FullName, opt => opt.MapFrom(src =>
                string.Format("{0} {1}",
                    src.Customer.FirstName,
                    src.Customer.LastName)
            ))
            // Total
            .ForMember(dest => dest.Total, opt => opt.MapFrom(src => src.Items.Sum(item => item.UnitPrice * item.Quantity)));
        });

        return config;
    }   
}
