import { CategoryNavigation } from "./category-navigation.model";
import { Characteristicable } from "./abstractions/characteristicable.abstraction";

export class ListCategoryAdminComponentItem extends Characteristicable {
    constructor(data) {
        super(data);

        this.navigations = data.navigations.map(o => {
            return new CategoryNavigation(o);
        });
    }

    navigations: CategoryNavigation[];
}
