using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Product.Application.Models.Query;
using Product.Infrastructure;

namespace Product.Application.UseCases.Products //.Command.Delete
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, BaseDto<ProductInput>>
    {
        private readonly ProjectContext _context;

        public DeleteProductHandler(ProjectContext context)
        {
            _context = context;
        }

        public async Task<BaseDto<ProductInput>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _context.products.FindAsync(request.id);

                _context.products.Remove(result);
                await _context.SaveChangesAsync();

                return new BaseDto<ProductInput>
                {
                    Message = "Success delete product data",
                    Status = true,
                    Data = new ProductInput
                    {
                        name = result.name,
                        price = result.price
                    }
                };
            }
            catch (Exception)
            {
                return new BaseDto<ProductInput>
                {
                    Message = "Failed delete product data",
                    Status = false,
                    Data = null
                };
            }
        }
    }
}
