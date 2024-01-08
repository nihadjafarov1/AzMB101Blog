using FluentValidation;

namespace Twitter.Business.Dtos.AuthDtos
{
    public class RegisterDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }
    }

    public class RegisterDtoValidator : AbstractValidator<RegisterDto>
    {
        public RegisterDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(32);
            RuleFor(x => x.Surname)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(50);
            RuleFor(x => x.Username)
                .NotEmpty()
                .NotNull()
                .MinimumLength(2)
                .MaximumLength(25);
            RuleFor(x => x.Email)
            .NotEmpty()
            .NotNull()
            .Matches(@"^[^@\s] +@[^@\s] +\.(com | net | org | gov | ru)$");
            RuleFor(x => x.Password)
                .NotEmpty()
                .NotNull()
                .Matches(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9]).{4,}$");
            RuleFor(x => x.BirthDate.Year)
                .LessThan(DateTime.Now.Year - 13);
        }
    }
}
