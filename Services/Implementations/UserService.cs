using EcommerceApi.Data;
using EcommerceApi.DTOs.User;
using EcommerceApi.Models.Entities;
using EcommerceApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApi.Services.Implementations;

public class UserService : IUserService
{
    private readonly AppDbContext _context;

    public UserService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<UserResponseDto>> GetAllUsersAsync()
    {
        return await _context.Users
            .Select(user => new UserResponseDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                City = user.City,
                IsActive = user.IsActive,
                CreatedAt = user.CreatedAt
            })
            .ToListAsync();
    }

    public async Task<UserResponseDto?> GetUserByIdAsync(Guid id)
    {
        var user = await _context.Users.FindAsync(id);

        if (user == null)
        {
            return null;
        }

        return new UserResponseDto
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber,
            City = user.City,
            IsActive = user.IsActive,
            CreatedAt = user.CreatedAt
        };
    }

    public async Task<UserResponseDto> CreateUserAsync(CreateUserRequestDto dto)
    {
        var user = new User
        {
            Name = dto.Name,
            Email = dto.Email,
            Password = dto.Password,
            PhoneNumber = dto.PhoneNumber,
            City = dto.City
        };

        _context.Users.Add(user);

        await _context.SaveChangesAsync();

        return new UserResponseDto
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber,
            City = user.City,
            IsActive = user.IsActive,
            CreatedAt = user.CreatedAt
        };
    }

    public async Task<UserResponseDtoForUpdate?> UpdateUserAsync(Guid id, UpdateUserRequestDto dto)
    {
        var user = await _context.Users.FindAsync(id);

        if (user == null)
        {
            return null;
        }

        user.Name = dto.Name;
        user.City = dto.City;
        user.PhoneNumber = dto.PhoneNumber;
        user.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return new UserResponseDtoForUpdate
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber,
            City = user.City,
            IsActive = user.IsActive,
            CreatedAt = user.CreatedAt,
            UpdatedAt = user.UpdatedAt,
            UpdatedAtIST = user.CreatedAtIST
        };
    }

    public async Task<bool> DeleteUserAsync(Guid id)
    {
        var user = await _context.Users.FindAsync(id);

        if (user == null)
        {
            return false;
        }

        _context.Users.Remove(user);

        await _context.SaveChangesAsync();

        return true;
    }
}