using FluentValidation;
using Twitter.Business.Dtos.PostDtos;

namespace Twitter.Business.Dtos.CommentDtos
{
    public class CommentCreateDto
    {
        public string Content { get; set; }
        public int? ParentCommentId { get; set; }
        public int PostId { get; set; }
    }
    public class CommentCreateDtoValidator : AbstractValidator<CommentCreateDto>
    {
        public CommentCreateDtoValidator()
        {
            RuleFor(x => x.Content)
                .NotEmpty()
                .NotNull()
                .MinimumLength(2)
                .MaximumLength(512);
            RuleFor(x => x.PostId)
                .NotEmpty()
                .NotNull();
        }
    }
}
