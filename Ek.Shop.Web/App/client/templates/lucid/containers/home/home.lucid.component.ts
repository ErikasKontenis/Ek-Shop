import { Component, Injector } from '@angular/core';

import { HomeComponent } from '../../../../containers/home/home.component';

@Component({
    selector: 'home-lucid',
    templateUrl: './home.lucid.component.html'
})

export class HomeLucidComponent extends HomeComponent {
    constructor(public injector: Injector) {
        super(injector);
    }
}
