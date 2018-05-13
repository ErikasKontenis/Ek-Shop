import { Component, Injector } from '@angular/core';

import { OrderComponent } from '../../../../containers/order/order.component';

@Component({
    selector: 'order-lucid',
    templateUrl: './order.lucid.component.html'
})

export class OrderLucidComponent extends OrderComponent {
    constructor(public injector: Injector) {
        super(injector);
    }
}
