using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.BLL.AuthorManagement.Dtos;

public class AuthorDto
{
    public int Id { get; set; }

    [Required]
    [Display(Name = "Full Name")]
    public string FullName { get; set; } = null!;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;

    public string? Website { get; set; }

    [MaxLength(300)]
    public string? Bio { get; set; }

}

