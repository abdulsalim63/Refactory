using System;
using Week5BackgroundServices.Application.Models.Query;

namespace Week5BackgroundServices.Application.UseCases.Products //.Command.Update
{
    public class UpdateProductCommand : BaseRequest<ProductInput>
    {
        public int id { get; set; }
    }
}
