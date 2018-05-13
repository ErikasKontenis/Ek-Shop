import { Injector } from '@angular/core';

import { BaseCategoryComponent } from '../../../shared/containers/base-category.component';
import { Field } from "../../../shared/models/field.model";
import { UserService } from "../../../shared/services/user.service";
import { Resource } from "../../../shared/models/resource.model";
import { ComponentFactoryService } from "../../../modules/component-factory/component-factory.service";

export class LoginComponent extends BaseCategoryComponent {
    public static readonly componentName = "LoginComponent";

    constructor(public injector: Injector,
        public userService: UserService,
        public componentFactoryService: ComponentFactoryService) {
        super(injector);
    }

    login(field: Field) {
        this.category.headerErrors = [];

        var loginData = {
            email: this.category.getFieldset("login").getField("email").value,
            password: this.category.getFieldset("login").getField("password").value,
            routeUrl: this.location.path()
        };

        this.httpService.post("/authentication/login/", loginData)
            .subscribe(response => {
                this.httpService.getResources().subscribe(response => {
                    var resource = new Resource(response);
                    this.componentFactoryService.create(resource.loginRedirect);
                });
                this.userService.updateAuth();
            },
            response => {
                this.category.validateFieldsets(response);
            });
    }
}
