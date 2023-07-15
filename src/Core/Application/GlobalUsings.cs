global using System;
global using MediatR;
global using Domain.UoW;
global using AutoMapper;
global using Domain.Enums;
global using Domain.Models;
global using Application.VM;
global using FluentValidation;
global using Microsoft.Extensions.Logging;
global using Application.Common.Exceptions;
global using Microsoft.Extensions.DependencyInjection;


global using Domain.Aggregates.BrandAggregate;
global using Domain.Aggregates.CategoryAggregate;
global using Domain.Aggregates.ProductAggregate;