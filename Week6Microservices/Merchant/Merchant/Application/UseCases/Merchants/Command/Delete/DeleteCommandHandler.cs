using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Merchant.Application.Models.Query;
using Merchant.Infrastructure;

namespace Merchant.Application.UseCases.Merchants //.Command.Delete
{
    public class DeleteMerchantHandler : IRequestHandler<DeleteMerchantCommand, BaseDto<MerchantInput>>
    {
        private readonly ProjectContext _context;

        public DeleteMerchantHandler(ProjectContext context)
        {
            _context = context;
        }

        public async Task<BaseDto<MerchantInput>> Handle(DeleteMerchantCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _context.merchants.FindAsync(request.id);

                _context.merchants.Remove(result);
                await _context.SaveChangesAsync();

                return new BaseDto<MerchantInput>
                {
                    Message = "Success delete merchant data",
                    Status = true,
                    Data = new MerchantInput
                    {
                        name = result.name,
                        image = result.image,
                        address = result.address,
                        rating = result.rating
                    }
                };
            }
            catch (Exception)
            {
                return new BaseDto<MerchantInput>
                {
                    Message = "Failed delete merchant data",
                    Status = false,
                    Data = null
                };
            }
        }
    }
}
