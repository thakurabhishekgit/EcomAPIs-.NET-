using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace EcommerceApi.Models.Entities;

public class User
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    [MinLength(3)]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    [MaxLength(200)]
    public string Email { get; set; } = string.Empty;

    [Required]
    [MinLength(6)]
    [MaxLength(200)]
    public string Password { get; set; } = string.Empty;

    [Required]
public string PhoneNumber { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string City { get; set; } = string.Empty;

    public bool IsActive { get; set; } = true;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

   
    public List<Product> Products { get; set; } = new();

    
    public string CreatedAtIST 
        {
            get
            {
                var istTime = TimeZoneInfo.ConvertTimeFromUtc(CreatedAt, 
                    TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));

                return istTime.ToString("dd MMM yyyy hh:mm tt", CultureInfo.InvariantCulture);
            }
        }

        public string UpdatedAtIST
        {
            get
            {
                var istTime = TimeZoneInfo.ConvertTimeFromUtc(UpdatedAt, 
                    TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));

                return istTime.ToString("dd MMM yyyy hh:mm tt", CultureInfo.InvariantCulture);
            }
        }

}