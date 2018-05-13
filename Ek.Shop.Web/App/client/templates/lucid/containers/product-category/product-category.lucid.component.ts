import { Component, OnInit, Injector } from '@angular/core';

import { ProductCategoryComponent } from '../../../../containers/product-category/product-category.component';

@Component({
    selector: 'product-category-lucid',
    templateUrl: './product-category.lucid.component.html'
})

export class ProductCategoryLucidComponent extends ProductCategoryComponent implements OnInit {
    constructor(public injector: Injector) {
        super(injector);
    }

    ngOnInit() {
        super.ngOnInit();
        this.attachFieldEvents();
    }

    attachFieldEvents() {
        super.attachFieldEvents();
    }

}
