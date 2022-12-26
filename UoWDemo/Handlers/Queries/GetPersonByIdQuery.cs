using MediatR;
using UoWDemo.Resources;
using ErrorOr;
using AutoMapper;
using UoWDemo.Entities;
using UoWDemo.Repositories;

namespace UoWDemo.Handlers.Queries
{
    public class GetPersonByIdQuery : IRequest<ErrorOr<PersonResource>>
    {
        public int Id { get; }
        public GetPersonByIdQuery(int id)
        {
            Id = id;
        }
    }

    public class GetPersonByIdQueryHandler : IRequestHandler<GetPersonByIdQuery, ErrorOr<PersonResource>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GetPersonByIdQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<ErrorOr<PersonResource>> Handle(GetPersonByIdQuery request,
            CancellationToken cancellationToken)
        {
            var employee = await _uow.Repository().GetById<Person>(request.Id);
            if (employee is null)
                return Error.NotFound(code: "Person not found", description:"Please enter the existing Person Id" );

            return _mapper.Map<PersonResource>(employee);
        }
    }
}
