using System;
using MediatR;
using Week5BackgroundServices.Application.Models.Query;

namespace Week5BackgroundServices.Application.UseCases.Products //.Command.Delete
{
    public class DeleteProductCommand : IRequest<BaseDto<ProductInput>>
    {
        public int id { get; set; }
    }
}
