global using System;
global using System.Net;
global using System.Reflection;
global using System.Threading.Tasks;
global using System.Collections.Generic;
global using System.Linq;
global using System.Text.Json;
global using System.Text.Json.Serialization;
global using System.Threading;
global using Microsoft.AspNetCore.Hosting;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Hosting;
global using Microsoft.Extensions.Logging;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.AspNetCore.Http;
global using Microsoft.AspNetCore.Mvc.Filters;

global using Presentation.Rest.Common.version;
global using MediatR;

global using Presentation.Rest.Models.Result;
global using Application.Categories.Commands.Create;
global using FluentResults;