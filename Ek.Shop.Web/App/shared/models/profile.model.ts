import { Model } from "./abstractions/model.abstraction";
import { PagedList } from "./table-page.model";
import { Order } from "./order.model";

export class Profile extends Model {
    constructor(data) {
        super(data);

        if (data.orders) {
            this.orders = new PagedList<Order>(data.orders);
            this.orders.items = data.orders.items.map(o => {
                return new Order(o);
            });
        }
    }

    orders: PagedList<Order>;
}
