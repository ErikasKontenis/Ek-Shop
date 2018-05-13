import { Classifier } from "../abstractions/classifier.abstraction";
import { PaymentMethodType } from "./payment-method-type.model";

export class PaymentMethod extends Classifier {
    constructor(data) {
        super(data);

        if (data.paymentMethodTypes) {
            this.paymentMethodTypes = data.paymentMethodTypes.map(o => {
                return new PaymentMethodType(o);
            });
        }
    }

    paymentMethodTypes: PaymentMethodType[];
}
