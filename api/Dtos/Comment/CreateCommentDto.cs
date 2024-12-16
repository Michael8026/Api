using System.ComponentModel.DataAnnotations;

namespace api.Dtos
{
    public class CreateCommentDto
    {
        [Required]
        [MinLength(5, ErrorMessage = "Title must be 5 characters")]
        [MaxLength(5, ErrorMessage = "Title cannot be over 280 characters")]
        public string Title { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "Content must be 5 characters")]
        [MaxLength(5, ErrorMessage = "Content cannot be over 280 characters")]
        public string Content { get; set; }

    }
}