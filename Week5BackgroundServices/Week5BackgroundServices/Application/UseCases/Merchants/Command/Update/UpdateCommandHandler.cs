using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Week5BackgroundServices.Application.Models.Query;
using Week5BackgroundServices.Infrastructure;

namespace Week5BackgroundServices.Application.UseCases.Merchants //.Command.Update
{
    public class UpdateMerchantCommandHandler : IRequestHandler<UpdateMerchantCommand, BaseDto<MerchantInput>>
    {
        private readonly ProjectContext _context;

        public UpdateMerchantCommandHandler(ProjectContext context)
        {
            _context = context;
        }

        public async Task<BaseDto<MerchantInput>> Handle(UpdateMerchantCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _context.merchants.FindAsync(request.id);
                var input = request.data.attributes;

                result.name = input.name;
                result.image = input.image;
                result.address = input.address;
                result.rating = input.rating;
                result.updated_at = (long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalDays;

                await _context.SaveChangesAsync(cancellationToken);

                return new BaseDto<MerchantInput>
                {
                    Message = "Success update merchant data",
                    Status = true,
                    Data = input
                };
            }
            catch (Exception)
            {
                return new BaseDto<MerchantInput>
                {
                    Message = "Failed update merchant data",
                    Status = false,
                    Data = null
                };
            }
        }
    }
}
