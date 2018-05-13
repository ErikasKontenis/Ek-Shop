import { Injector } from '@angular/core';

import { BaseCategoryComponent } from '../../../shared/containers/base-category.component';
import { Field } from "../../../shared/models/field.model";

export class RegistrationComponent extends BaseCategoryComponent {
    public static readonly componentName = "RegistrationComponent";

    constructor(public injector: Injector) {
        super(injector);
    }

    register(field: Field) {
        this.category.headerErrors = [];

        var registrationData = {
            email: this.category.getFieldset("registration").getField("email").value,
            name: this.category.getFieldset("registration").getField("name").value,
            lastName: this.category.getFieldset("registration").getField("lastName").value,
            password: this.category.getFieldset("registration").getField("password").value,
            passwordConfirmation: this.category.getFieldset("registration").getField("passwordConfirmation").value,
            phoneNumber: this.category.getFieldset("registration").getField("phoneNumber").value,
            routeUrl: this.location.path()
        };
        console.log(registrationData);
        this.httpService.post("/authentication/register/", registrationData)
            .subscribe(response => {
                console.log(response);
            },
            response => {
                this.category.validateFieldsets(response);
            });
    }
}
