import { Injector } from '@angular/core';

import { BaseCategoryComponent } from '../../../shared/containers/base-category.component';

export class SubCategoryComponent extends BaseCategoryComponent {
    public static readonly componentName = "SubCategoryComponent";

    constructor(public injector: Injector) {
        super(injector);
    }
}
