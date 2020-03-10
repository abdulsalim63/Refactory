using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Merchant.Application.Models.Query;
using Merchant.Infrastructure;

namespace Merchant.Application.UseCases.Merchants //.Command.Create
{
    public class CreateMerchantCommandHandler : IRequestHandler<BaseRequest<MerchantInput>, BaseDto<MerchantInput>>
    {
        private readonly ProjectContext _context;

        public CreateMerchantCommandHandler(ProjectContext context)
        {
            _context = context;
        }

        public async Task<BaseDto<MerchantInput>> Handle(BaseRequest<MerchantInput> request, CancellationToken cancellationToken)
        {
            var input = request.data.attributes;
            var merchant = new Domain.Entities.MerchantModel
            {
                name = input.name,
                image = input.image,
                address = input.address,
                rating = input.rating
            };

            _context.merchants.Add(merchant);
            await _context.SaveChangesAsync(cancellationToken);

            return new BaseDto<MerchantInput>
            {
                Message = "Success add merchant data",
                Status = true,
                Data = input
            };
        }
    }
}
