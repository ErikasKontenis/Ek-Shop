using Ek.Shop.Application.Abstractions;
using System.Collections.Generic;

namespace Ek.Shop.Application.Classifiers
{
    public class PaymentMethodDto : ClassifierDto
    {
        public List<PaymentMethodTypeDto> PaymentMethodTypes { get; set; } = new List<PaymentMethodTypeDto>();
    }
}
