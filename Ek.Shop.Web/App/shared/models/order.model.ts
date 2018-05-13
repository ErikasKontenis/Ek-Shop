import { Characteristicable } from "./abstractions/characteristicable.abstraction";
import { Basket } from "./basket.model";

export class Order extends Characteristicable {
    constructor(data) {
        super(data);

        if (data.basket) {
            this.basket = new Basket(data.basket);
        }
        if (!data.isBuyerCompany) {
            this.isBuyerCompany = false;
        }
    }

    address: string;
    basket: Basket;
    city: string;
    companyCode: string;
    companyName: string;
    companyVat: string;
    createdOn: Date;
    email: string;
    id: number;
    isBuyerCompany: boolean;
    lastName: string;
    name: string;
    orderStatus: string;
    paymentMethod: string;
    paymentMethodType: string;
    phoneNumber: number;
    postCode: number;
    shippingMethod: string;
    totalPrice: number;
}
