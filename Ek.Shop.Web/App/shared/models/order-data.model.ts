import { Model } from "./abstractions/model.abstraction";
import { PaymentMethod } from "./classifiers/payment-method.model";
import { ShippingMethod } from "./classifiers/shipping-method.model";

export class OrderData extends Model {
    constructor(data) {
        super(data);
    }

    paymentMethods: PaymentMethod[];
    shippingMethods: ShippingMethod[];
    totalBasketPrice: number;
    totalBasketVat: number;
}
