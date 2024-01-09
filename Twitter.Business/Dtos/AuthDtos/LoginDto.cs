using FluentValidation;

namespace Twitter.Business.Dtos.AuthDtos
{
    public class LoginDto
    {
        public string UsernameOrEmail { get; set; }
        public string Password { get; set; }
    }
    public class LoginDtoValidator : AbstractValidator<LoginDto>
    {
        public LoginDtoValidator()
        {
            RuleFor(x => x.UsernameOrEmail)
                .NotNull()
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(64);
            RuleFor(x => x.Password)
                .NotNull()
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(64);
        }
    }
}
