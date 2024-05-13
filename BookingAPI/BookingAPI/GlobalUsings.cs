global using AutoMapper;
global using System.Text;
global using System.Text.RegularExpressions;
global using System.IdentityModel.Tokens.Jwt;
global using System.Security.Claims;

global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Metadata.Builders;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.AspNetCore.Authorization;
global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.AspNetCore.Identity;
global using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
global using Microsoft.IdentityModel.Tokens;

global using BookingAPI.Exceptions;
global using BookingAPI.Data;
global using BookingAPI.Data.Entities;
global using BookingAPI.Data.EntityConfigurations;
global using BookingAPI.Repositories;
global using BookingAPI.Repositories.Interfaces;
global using BookingAPI.Services;
global using BookingAPI.Services.Interfaces;
global using BookingAPI.Models.DTO;
global using BookingAPI.Models.Enums;
global using BookingAPI.Models.Requests;
global using BookingAPI.Models.Responses;
