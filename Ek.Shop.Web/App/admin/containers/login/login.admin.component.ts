import { Component, OnInit, Injector } from '@angular/core';
import { UserService } from "../../../shared/services/user.service";
import { BaseCategoryComponent } from "../../../shared/containers/base-category.component";
import { Field } from "../../../shared/models/field.model";
import { ComponentFactoryService } from "../../../modules/component-factory/component-factory.service";
import { Resource } from "../../../shared/models/resource.model";

@Component({
    selector: 'login-admin',
    templateUrl: './login.admin.component.html'
})

export class LoginAdminComponent extends BaseCategoryComponent implements OnInit {
    public static readonly componentName = "LoginComponent";

    constructor(public injector: Injector,
        public userService: UserService,
        private componentFactoryService: ComponentFactoryService) {
        super(injector);
    }

    dateNow: Date = new Date();

    ngOnInit() {
        super.ngOnInit();
        if (this.category.getFieldset("login").getField("login")) {
            this.category.getFieldset("login").getField("login").onClick = this.login.bind(this);
        }
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
