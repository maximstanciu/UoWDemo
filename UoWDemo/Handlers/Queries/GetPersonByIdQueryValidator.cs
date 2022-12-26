using FluentValidation;

namespace UoWDemo.Handlers.Queries
{
    public class GetPersonByIdQueryValidator : AbstractValidator<GetPersonByIdQuery>
    {
        public GetPersonByIdQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
