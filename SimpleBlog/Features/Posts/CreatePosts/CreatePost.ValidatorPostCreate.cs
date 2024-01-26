using FluentValidation;

namespace SimpleBlog.Features.Posts.CreatePosts;

public class ValidatorPostCreate : AbstractValidator<InputPostCreate>
{
	public ValidatorPostCreate()
	{
		RuleFor(p => p.Title)
			.NotEmpty();
	}
}
