import { Model } from "./abstractions/model.abstraction";
import { Order } from "./order.model";

export class ProfileData extends Model {
    constructor(data) {
        super(data);

        if (data.orders) {
            this.orders = data.orders.map(o => {
                return new Order(o);
            });
        }
    }

    orders: Order[];
}
