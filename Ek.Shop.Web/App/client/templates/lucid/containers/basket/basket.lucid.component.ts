import { Component, Injector } from '@angular/core';

import { BasketComponent } from '../../../../containers/basket/basket.component';

@Component({
    selector: 'basket-lucid',
    templateUrl: './basket.lucid.component.html'
})

export class BasketLucidComponent extends BasketComponent {
    constructor(public injector: Injector) {
        super(injector);
    }
}
