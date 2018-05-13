import { Image } from "./image.model";
import { Characteristicable } from "./abstractions/characteristicable.abstraction";

export class CategoryItem extends Characteristicable {
    constructor(data) {
        super(data);

        this.images = data.images.map(o => {
            return new Image(o);
        });
    }

    detailsCount: number;
    discount: number;
    id: number;
    images: Image[];
    price: number;
    url: string;

    getTotalPrice() {
        return this.price - this.discount;
    }
}
