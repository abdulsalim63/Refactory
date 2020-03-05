using System;
using Week5Mediator.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using MediatR;
using System.Threading.Tasks;
using System.Threading;

namespace Week5Mediator.Application.UseCases.CustomerCards.Command.DeleteCustomerCard
{
    public class CreateCustomerCardCommandHandler : IRequestHandler<CreateCustomerCardCommand, CreateCustomerCardCommandDto>
    {
        private readonly IBlogContext _context;

        public CreateCustomerCardCommandHandler(IBlogContext context)
        {
            _context = context;
        }

        public async Task<CreateCustomerCardCommandDto> Handle(CreateCustomerCardCommand request, CancellationToken cancellationToken)
        {
            var input = request.data.attributes;
            var customerCard = new Domain.Models.CustomerCard
            {
                customer_id = input.customer_id,
                name_on_card = input.name_on_card,
                exp_month = input.exp_month,
                exp_year = input.exp_year,
                postal_code = input.postal_code,
                credit_card_number = input.credit_card_number
            };

            //_context.customers.Add(customer);
            //await _context.SaveChangesAsync(cancellationToken);

            return new CreateCustomerCardCommandDto
            {
                Message = "Success add customer data",
                Success = true,
                Data = customerCard
            };
        }
    }
}
