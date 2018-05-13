import { Classifier } from "../abstractions/classifier.abstraction";

export class ShippingMethod extends Classifier {
    constructor(data) {
        super(data);
    }

    price: number;
}
