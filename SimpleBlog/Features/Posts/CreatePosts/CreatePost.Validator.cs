using FluentValidation;

namespace SimpleBlog.Features.Posts.CreatePosts;

public class Validator : AbstractValidator<Input>
{
	public Validator()
	{
		RuleFor(p => p.Title)
			.NotEmpty();
	}
}
