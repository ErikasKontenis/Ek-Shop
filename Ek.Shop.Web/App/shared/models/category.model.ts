import { CategoryItem } from "./category-item.model";
import { CategoryNavigation } from "./category-navigation.model";
import { Model } from "./abstractions/model.abstraction";
import { ComponentContainer } from "./abstractions/component-container.abstraction";
import { Image } from "./image.model";
import { PagedList } from "./table-page.model";
import { Product } from "./product.model";

export class Category extends ComponentContainer {
    constructor(data) {
        super(data);

        if (data.subCategories) {
            this.subCategories = new PagedList<Category>(data.subCategories);
            this.subCategories.items = data.subCategories.items.map(o => {
                return new Category(o);
            });
        }

        if (data.products) {
            this.products = new PagedList<Product>(data.products);
            this.products.items = data.products.items.map(o => {
                return new Product(o);
            });
        }

        if (data.navigations) {
            this.navigations = data.navigations.map(o => {
                return new CategoryNavigation(o);
            });
        }

        if (data.images) {
            this.images = data.images.map(o => {
                return new Image(o);
            });
        }
    }

    categoryTypeCode: string;
    id: number;
    images: Image[];
    navigations: CategoryNavigation[];
    parameters: any;
    parentId: number;
    products: PagedList<Product>;
    subCategories: PagedList<Category>;
}
