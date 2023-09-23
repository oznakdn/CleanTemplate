global using FluentValidation;
global using MediatR;
global using AutoMapper;
global using Clean.Persistence.Contexts;
global using Clean.Persistence.Repositories.Interfaces;
global using Microsoft.Extensions.DependencyInjection;
global using System.Reflection;
global using Clean.Identity.Helpers;
global using Clean.Persistence.Repositories.Mongo.Interfaces;
global using Clean.Application.Features.Commands.CustomerCommands.Add.Dtos;
global using Clean.Application.Features.Commands.CustomerCommands.Add.Validation;
global using Clean.Domain.Entities.NoSQL;
global using Clean.Domain.Entities.SQL;
global using Clean.Identity.Configurations;
global using Clean.Persistence.Configurations;
global using Clean.Application.UnitOfWork.Concretes;
global using Clean.Application.UnitOfWork.Interfaces;
global using Clean.Persistence.Repositories;
global using Clean.Persistence.Repositories.Mongo;
global using Microsoft.Extensions.Options;
global using Gleeman.EffectiveLogger.Logger;




