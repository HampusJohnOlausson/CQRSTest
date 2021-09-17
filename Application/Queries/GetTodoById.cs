using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Infrastructure.Persistence;
using MediatR;

namespace Application.Queries
{
    public static class GetTodoById
    {
        //Query
        public record Query(int Id) : IRequest<Response>;

        //Handler
        public class Handler : IRequestHandler<Query, Response>
        {
            private readonly Repository repository;

            public Handler(Repository repository)
            {
                this.repository = repository;
            }
            public async Task<Response> Handle(Query request, CancellationToken cancellationToken)
            {
                var todo = repository.Todos.FirstOrDefault(x => x.Id == request.Id);
                return todo == null ? null : new Response(todo.Id, todo.Name, todo.Completed); 
                
            }
        }

        //Response
        public record Response(int Id, string Name, bool Completed);
    }
}
