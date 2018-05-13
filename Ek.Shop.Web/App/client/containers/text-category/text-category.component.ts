import { Injector } from '@angular/core';

import { BaseCategoryComponent } from '../../../shared/containers/base-category.component';

export class TextCategoryComponent extends BaseCategoryComponent {
    public static readonly componentName = "TextCategoryComponent";

    constructor(public injector: Injector) {
        super(injector);
    }
}
