using System;
using Product.Application.Models.Query;

namespace Product.Application.UseCases.Products //.Command.Update
{
    public class UpdateProductCommand : BaseRequest<ProductInput>
    {
        public int id { get; set; }
    }
}
