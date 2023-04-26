global using System;
global using Domain.UoW;
global using Domain.Entities.Brands;
global using Infrastructure.Context;
global using Domain.Entities.Products;
global using Domain.Entities.Categories;
global using Microsoft.EntityFrameworkCore;

global using AutoMapper;
global using Domain.Enums;
global using Application.VM;
global using Domain.ValueObjects.Products;
global using Microsoft.Extensions.Logging;

global using Domain.Models;
global using Domain.ValueObjects.Brands;
global using Domain.ValueObjects.Categories;

global using Infrastructure.Repositories.Brands;
global using Infrastructure.Repositories.Products;
global using Infrastructure.Repositories.Categories;

global using Infrastructure.EntityTypeConfiguration;
global using Microsoft.EntityFrameworkCore.Metadata.Builders;