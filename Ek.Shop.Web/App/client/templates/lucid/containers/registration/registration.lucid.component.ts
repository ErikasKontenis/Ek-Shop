import { Component, OnInit, Injector } from '@angular/core';

import { RegistrationComponent } from '../../../../containers/registration/registration.component';

@Component({
    selector: 'registration-lucid',
    templateUrl: './registration.lucid.component.html'
})

export class RegistrationLucidComponent extends RegistrationComponent implements OnInit {
    constructor(public injector: Injector) {
        super(injector);
    }

    ngOnInit() {
        super.ngOnInit();
        if (this.category.getFieldset("registration").getField("register")) {
            this.category.getFieldset("registration").getField("register").onClick = this.register.bind(this);
        }
    }
}
