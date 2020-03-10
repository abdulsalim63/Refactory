using System;
using MediatR;
using Merchant.Application.Models.Query;

namespace Merchant.Application.UseCases.Merchants //.Command.Delete
{
    public class DeleteMerchantCommand : IRequest<BaseDto<MerchantInput>>
    {
        public int id { get; set; }
    }
}
