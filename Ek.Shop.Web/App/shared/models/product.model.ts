import { CategoryNavigation } from "./category-navigation.model";
import { Image } from "./image.model";
import { ComponentContainer } from "./abstractions/component-container.abstraction";

export class Product extends ComponentContainer {
    constructor(data) {
        super(data);

        if (this.navigations) {
            this.navigations = data.navigations.map(o => {
                return new CategoryNavigation(o);
            });
        }

        if (this.images) {
            this.images = data.images.map(o => {
                return new Image(o);
            });
        }
    }

    categoryId: number;
    id: number;
    images: Image[];
    navigations: CategoryNavigation[];
    price: number;
    discount: number;

    getTotalPrice() {
        return this.price - this.discount;
    }
}
