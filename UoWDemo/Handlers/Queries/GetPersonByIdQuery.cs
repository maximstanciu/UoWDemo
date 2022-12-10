using MediatR;

namespace UoWDemo.Handlers.Queries
{
    public class GetPersonByIdQuery //: IRequest<ErrorOr<PersonDto>>
    {
        public int Id { get; }
        public GetPersonByIdQuery(int id)
        {
            Id = id;
        }
    }
}
