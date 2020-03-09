using System;
using MediatR;
using Week5BackgroundServices.Application.Models.Query;

namespace Week5BackgroundServices.Application.UseCases.Merchants //.Command.Delete
{
    public class DeleteMerchantCommand : IRequest<BaseDto<MerchantInput>>
    {
        public int id { get; set; }
    }
}
