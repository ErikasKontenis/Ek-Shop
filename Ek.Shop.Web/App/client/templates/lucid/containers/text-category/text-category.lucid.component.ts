import { Component, Injector } from '@angular/core';

import { TextCategoryComponent } from '../../../../containers/text-category/text-category.component';

@Component({
    selector: 'text-category-lucid',
    templateUrl: './text-category.lucid.component.html'
})

export class TextCategoryLucidComponent extends TextCategoryComponent {
    constructor(public injector: Injector) {
        super(injector);
    }
}
