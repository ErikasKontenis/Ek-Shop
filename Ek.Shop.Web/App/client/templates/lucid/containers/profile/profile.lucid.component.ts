import { Component, OnInit, Injector } from '@angular/core';
import { ProfileComponent } from "../../../../containers/profile/profile.component";
import { UserService } from "../../../../../shared/services/user.service";
import { ComponentFactoryService } from "../../../../../modules/component-factory/component-factory.service";

@Component({
    selector: 'profile-lucid',
    templateUrl: './profile.lucid.component.html'
})

export class ProfileLucidComponent extends ProfileComponent implements OnInit {
    constructor(public injector: Injector) {
        super(injector);
    }

    ngOnInit() {
        super.ngOnInit();
    }
}
