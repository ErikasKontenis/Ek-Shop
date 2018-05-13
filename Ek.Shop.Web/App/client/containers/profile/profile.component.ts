import { OnInit, Injector } from '@angular/core';

import { BaseCategoryComponent } from "../../../shared/containers/base-category.component";
import { Profile } from "../../../shared/models/profile.model";
import { UserService } from "../../../shared/services/user.service";
import { Field } from "../../../shared/models/field.model";
import { Order } from "../../../shared/models/order.model";
import { ComponentFactoryService } from "../../../modules/component-factory/component-factory.service";
import { Resource } from "../../../shared/models/resource.model";
import { User } from "../../../shared/models/user.model";
import { ToastrService } from "ngx-toastr";

export class ProfileComponent extends BaseCategoryComponent implements OnInit {
    public static readonly componentName = "ProfileComponent";
    public profile: Profile;

    readonly componentFactoryService: ComponentFactoryService;
    readonly userService: UserService;
    readonly toastr: ToastrService;
    constructor(public injector: Injector) {
        super(injector);
        this.componentFactoryService = injector.get(ComponentFactoryService);
        this.userService = injector.get(UserService);
        this.toastr = injector.get(ToastrService);
    }

    ngOnInit() {
        super.ngOnInit();
        this.getProfile();
    }

    attachFieldEvents() {
        super.attachFieldEvents();
        var userInfo = this.category.getFieldset("userInfo");
        if (userInfo) {
            var isBuyerCompany = userInfo.getField("isBuyerCompany");
            if (isBuyerCompany) {
                isBuyerCompany.onClick = this.setCompanyFieldsVisibility.bind(this);
            }
        }

        var userFooterActions = this.category.getFieldset("userFooterActions");
        if (userFooterActions) {
            var save = userFooterActions.getField("save");
            if (save) {
                save.onClick = this.saveUser.bind(this);
            }
        }
    }

    getProfile() {
        this.httpService.get("/authentication/getProfile").subscribe(result => {
            this.profile = new Profile(result);

            var userInfo = this.category.getFieldset("userInfo");
            userInfo.getField("name").value = this.userService.user.name;
            userInfo.getField("lastName").value = this.userService.user.lastName;
            userInfo.getField("email").value = this.userService.user.email;
            userInfo.getField("phoneNumber").value = this.userService.user.phoneNumber;
            userInfo.getField("isBuyerCompany").value = this.userService.user.isBuyerCompany;
            userInfo.getField("companyCode").value = this.userService.user.companyCode;
            userInfo.getField("companyName").value = this.userService.user.companyName;
            userInfo.getField("companyVat").value = this.userService.user.companyVat;
            this.setCompanyFieldsVisibility(userInfo.getField("isBuyerCompany"));

            var userShippingInfo = this.category.getFieldset("userShippingInfo");
            userShippingInfo.getField("address").value = this.userService.user.address;
            userShippingInfo.getField("city").value = this.userService.user.city;
            userShippingInfo.getField("postCode").value = this.userService.user.postCode;
        });
    }

    saveUser(field: Field) {
        var saveUserCommand = {
            user: {
                address: this.category.getFieldset("userShippingInfo").getField("address").value,
                city: this.category.getFieldset("userShippingInfo").getField("city").value,
                companyCode: this.category.getFieldset("userInfo").getField("companyCode").value,
                companyName: this.category.getFieldset("userInfo").getField("companyName").value,
                companyVat: this.category.getFieldset("userInfo").getField("companyVat").value,
                email: this.category.getFieldset("userInfo").getField("email").value,
                isBuyerCompany: this.category.getFieldset("userInfo").getField("isBuyerCompany").value,
                lastName: this.category.getFieldset("userInfo").getField("lastName").value,
                name: this.category.getFieldset("userInfo").getField("name").value,
                phoneNumber: this.category.getFieldset("userInfo").getField("phoneNumber").value,
                postCode: this.category.getFieldset("userShippingInfo").getField("postCode").value,
            } as User,
            routeUrl: this.category.navigations.last().url
        };
        saveUserCommand.user = new User(saveUserCommand.user);

        this.httpService.post("/authentication/saveUser/", saveUserCommand).subscribe(response => {
            this.toastr.success("Jūsų vartotojo duomenys išsaugoti.");
        },
        response => {
            this.category.validateFieldsets(response);
        });
    }

    setCompanyFieldsVisibility(field: Field) {
        var userInfo = this.category.getFieldset("userInfo");
        userInfo.getField("companyName").setCharacteristic("isHidden", !field.value);
        userInfo.getField("companyCode").setCharacteristic("isHidden", !field.value);
        userInfo.getField("companyVat").setCharacteristic("isHidden", !field.value);
    }
}
