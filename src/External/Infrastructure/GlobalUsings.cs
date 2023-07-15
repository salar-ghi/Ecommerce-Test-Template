global using System;
global using Domain.UoW;
global using AutoMapper;
global using Domain.Enums;
global using Domain.Models;
global using Application.VM;

global using Infrastructure.UoW;

global using Infrastructure.Context;
global using Infrastructure.Repositories.Brands;
global using Infrastructure.Repositories.Products;
global using Infrastructure.Repositories.Categories;
global using Infrastructure.EntityTypeConfiguration;

global using Domain.Repositories.Interfaces.General;


global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Metadata.Builders;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Configuration;
global using Domain.Repositories.Interfaces.Categories;
global using Domain.Aggregates.CategoryAggregate;

global using Domain.Aggregates.ProductAggregate;
global using Domain.Repositories.Interfaces.Products;

global using Domain.Repositories.Interfaces.Brands;
global using Domain.Aggregates.BrandAggregate;
global using Infrastructure.Repositories.General;