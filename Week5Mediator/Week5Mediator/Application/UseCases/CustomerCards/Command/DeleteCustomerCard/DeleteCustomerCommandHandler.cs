using System;
using Week5Mediator.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using MediatR;
using System.Threading.Tasks;
using System.Threading;

namespace Week5Mediator.Application.UseCases.CustomerCards.Command.DeleteCustomerCard
{
    public class DeleteCustomerCardCommandHandler : IRequestHandler<DeleteCustomerCardCommand, DeleteCustomerCardCommandDto>
    {
        private readonly IBlogContext _context;

        public DeleteCustomerCardCommandHandler(IBlogContext context)
        {
            _context = context;
        }

        public async Task<DeleteCustomerCardCommandDto> Handle(DeleteCustomerCardCommand request, CancellationToken cancellationToken)
        {
            var result = await _context.customerCards.FirstOrDefaultAsync(x => x.id == request.id);

            _context.customerCards.Remove(result);
            await _context.SaveChangesAsync(cancellationToken);

            return new DeleteCustomerCardCommandDto
            {
                Message = "Success delete customer card data",
                Success = true,
                Data = result
            };
        }
    }
}
