using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Week5BackgroundServices.Application.Models.Query;
using Week5BackgroundServices.Infrastructure;

namespace Week5BackgroundServices.Application.UseCases.Products //.Command.Update
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, BaseDto<ProductInput>>
    {
        private readonly ProjectContext _context;

        public UpdateProductCommandHandler(ProjectContext context)
        {
            _context = context;
        }

        public async Task<BaseDto<ProductInput>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _context.products.FindAsync(request.id);
                var input = request.data.attributes;

                result.name = input.name;
                result.price = input.price;
                result.updated_at = (long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalDays;

                await _context.SaveChangesAsync(cancellationToken);

                return new BaseDto<ProductInput>
                {
                    Message = "Success update product data",
                    Status = true,
                    Data = input
                };
            }
            catch (Exception)
            {
                return new BaseDto<ProductInput>
                {
                    Message = "Failed update product data",
                    Status = false,
                    Data = null
                };
            }
        }
    }
}
