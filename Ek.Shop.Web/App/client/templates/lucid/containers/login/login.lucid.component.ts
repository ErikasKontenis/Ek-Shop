import { Component, OnInit, Injector } from '@angular/core';
import { LoginComponent } from '../../../../containers/login/login.component';
import { UserService } from "../../../../../shared/services/user.service";
import { ComponentFactoryService } from "../../../../../modules/component-factory/component-factory.service";

@Component({
    selector: 'login-lucid',
    templateUrl: './login.lucid.component.html'
})

export class LoginLucidComponent extends LoginComponent implements OnInit {
    constructor(public injector: Injector,
        public userService: UserService,
        public componentFactoryService: ComponentFactoryService) {
        super(injector, userService, componentFactoryService);
    }

    ngOnInit() {
        super.ngOnInit();
        if (this.category.getFieldset("login").getField("login")) {
            this.category.getFieldset("login").getField("login").onClick = this.login.bind(this);
        }
    }
}
