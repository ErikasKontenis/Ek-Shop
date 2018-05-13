import { Model } from "./abstractions/model.abstraction";
import { BasketItem } from "./basket-item.model";

export class Basket extends Model {
    constructor(data) {
        super(data);

        if (data.basketItems) {
            this.basketItems = data.basketItems.map(o => {
                return new BasketItem(o);
            });
        }
    }

    basketItems: BasketItem[];

    getTotalPrice() {
        var totalPrice = 0;
        this.basketItems.forEach((item) => {
            totalPrice += item.getTotalPrice();
        });

        return totalPrice;
    }
}
