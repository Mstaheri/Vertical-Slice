using FluentValidation;

namespace SimpleBlog.Features.Posts.CreatePosts;

public class Validator : AbstractValidator<Input>
{
	public Validator()
	{
		RuleFor(input => input.Title)
			.Length(3, 10)
			.WithMessage("")
			.NotEmpty()
			.WithMessage("");
	}
}
