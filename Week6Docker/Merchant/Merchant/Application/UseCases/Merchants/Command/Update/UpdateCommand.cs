using System;
using Merchant.Application.Models.Query;

namespace Merchant.Application.UseCases.Merchants //.Command.Update
{
    public class UpdateMerchantCommand : BaseRequest<MerchantInput>
    {
        public int id { get; set; }
    }
}
