import { Characteristicable } from "./abstractions/characteristicable.abstraction";

export class CategoryNavigation extends Characteristicable {
    constructor(data) {
        super(data);
    }

    id: number;
    parameters: any;
    parentId: number;
    type: string;
    url: string;

    getBreadcrumbName() {
        return this.getCharacteristic("breadcrumbName") || this.getCharacteristic("name");
    }

    getNavigationName() {
        return this.getCharacteristic("navigationName") || this.getCharacteristic("name");
    }
}
