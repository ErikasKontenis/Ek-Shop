import { Component, OnInit, Injector } from '@angular/core';
import { LogoutComponent } from '../../../../containers/logout/logout.component';
import { UserService } from "../../../../../shared/services/user.service";
import { ComponentFactoryService } from "../../../../../modules/component-factory/component-factory.service";

@Component({
    selector: 'logout-lucid',
    templateUrl: './logout.lucid.component.html'
})

export class LogoutLucidComponent extends LogoutComponent implements OnInit {
    constructor(public injector: Injector,
        public userService: UserService,
        public componentFactoryService: ComponentFactoryService) {
        super(injector, userService, componentFactoryService);
    }

    ngOnInit() {
        super.ngOnInit();
        super.logout();
    }
}
