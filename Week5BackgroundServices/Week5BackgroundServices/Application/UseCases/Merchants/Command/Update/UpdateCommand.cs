using System;
using Week5BackgroundServices.Application.Models.Query;

namespace Week5BackgroundServices.Application.UseCases.Merchants //.Command.Update
{
    public class UpdateMerchantCommand : BaseRequest<MerchantInput>
    {
        public int id { get; set; }
    }
}
