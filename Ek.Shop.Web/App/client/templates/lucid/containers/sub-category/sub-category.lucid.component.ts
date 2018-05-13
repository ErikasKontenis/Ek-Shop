import { Component, Injector } from '@angular/core';

import { SubCategoryComponent } from '../../../../containers/sub-category/sub-category.component';

@Component({
    selector: 'sub-category-lucid',
    templateUrl: './sub-category.lucid.component.html'
})

export class SubCategoryLucidComponent extends SubCategoryComponent {
    constructor(public injector: Injector) {
        super(injector);
    }
}
