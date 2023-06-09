﻿global using System;
global using MediatR;
global using Domain.UoW;
global using AutoMapper;
global using Domain.Enums;
global using Domain.Models;
global using Application.VM;
global using FluentValidation;
global using Domain.Entities.Brands;
global using Domain.Entities.Products;
global using Domain.Entities.Categories;
global using Domain.ValueObjects.Brands;
global using Domain.ValueObjects.Products;
global using Microsoft.Extensions.Logging;
global using Application.Common.Exceptions;
global using Domain.ValueObjects.Categories;
global using Application.Brands.Commands.Create;
global using Application.Products.Commands.Create;
global using Application.Products.Commands.Update;
global using Microsoft.Extensions.DependencyInjection;

