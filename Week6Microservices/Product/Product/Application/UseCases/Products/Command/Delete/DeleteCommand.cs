using System;
using MediatR;
using Product.Application.Models.Query;

namespace Product.Application.UseCases.Products //.Command.Delete
{
    public class DeleteProductCommand : IRequest<BaseDto<ProductInput>>
    {
        public int id { get; set; }
    }
}
