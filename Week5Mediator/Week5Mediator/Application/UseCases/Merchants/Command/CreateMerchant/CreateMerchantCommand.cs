using System;
using MediatR;
using Week5Mediator.Application.UseCases.Merchants.Models;

namespace Week5Mediator.Application.UseCases.Merchants.Command.CreateMerchant
{
    public class CreateMerchantCommand : IRequest<CreateMerchantCommandDto>
    {
        public MerchantAttributes data { get; set; }
    }

    public class MerchantAttributes
    {
        public MerchantData attributes { get; set; }
    }
}
