using System;
using System.Threading;
using System.Threading.Tasks;
using Hangfire;
using MediatR;
using Week5BackgroundServices.Application.Models.Query;
using Week5BackgroundServices.Infrastructure;

namespace Week5BackgroundServices.Application.UseCases.CustomerCards //.Command.Create
{
    public class CreateCustomerCardCommandHandler : IRequestHandler<BaseRequest<CustomerCardInput>, BaseDto<CustomerCardInput>>
    {
        private readonly ProjectContext _context;

        public CreateCustomerCardCommandHandler(ProjectContext context)
        {
            _context = context;
        }

        public async Task<BaseDto<CustomerCardInput>> Handle(BaseRequest<CustomerCardInput> request, CancellationToken cancellationToken)
        {
            var input = request.data.attributes;
            var customerCard = new Domain.Entities.CustomerCard
            {
                customer_id = input.customer_id,
                name_on_card = input.name_on_card,
                exp_month = input.exp_month,
                exp_year = input.exp_year,
                postal_code = input.postal_code,
                credit_card_number = input.credit_card_number
            };

            _context.customercards.Add(customerCard);
            await _context.SaveChangesAsync(cancellationToken);

            return new BaseDto<CustomerCardInput>
            {
                Message = "Success add customer card payment data",
                Status = true,
                Data = input
            };
        }
    }
}
