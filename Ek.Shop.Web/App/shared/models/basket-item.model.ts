import { Model } from "./abstractions/model.abstraction";
import { Product } from "./product.model";

export class BasketItem extends Model {
    constructor(data) {
        super(data);

        if (data.product) {
            this.product = new Product(data.product);
        }
    }

    id: number;
    price: number;
    product: Product;
    quantity: number;

    getTotalPrice() {
        return this.price * this.quantity;
    }
}
