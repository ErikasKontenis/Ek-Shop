import { Component, OnInit, Injector, Input } from '@angular/core';
import { Location, LocationStrategy } from '@angular/common';

import { BaseCategoryComponent } from '../../../shared/containers/base-category.component';
import { HttpService } from '../../../shared/services/http.service';
import { ComponentFactoryService } from '../../../modules/component-factory/component-factory.service';
import { Category } from '../../../shared/models/category.model';
import { Field } from "../../../shared/models/field.model";
import { Order } from "../../../shared/models/order.model";

@Component({
    selector: 'edit-order-admin',
    templateUrl: './edit-order.admin.component.html'
})
export class EditOrderAdminComponent extends BaseCategoryComponent implements OnInit {
    public static readonly componentName = "EditOrderAdminComponent";
    public data: any;

    constructor(public injector: Injector,
        public httpService: HttpService,
        public componentFactoryService: ComponentFactoryService) {
        super(injector);
    }

    ngOnInit() {
        super.ngOnInit();
        this.attachFieldEvents();
        var orderId = this.location.path().split('/').last();
        this.httpService.get("/orderAdmin/getEditOrderData?id=" + orderId).subscribe(result => {
            this.data = result;
            var editingOrder = this.data.order = new Order(this.data.order);
            for (var ifieldset in this.category.fieldsets) {
                var fieldset = this.category.getFieldset(ifieldset);
                for (var ifield in fieldset.fields) {
                    var field = fieldset.getField(ifield);
                    var fieldCharacteristic = field.getCharacteristic("characteristic");
                    if (fieldCharacteristic) {
                        field.value = editingOrder.getCharacteristic(fieldCharacteristic.firstLetterToLowerCase())
                    }
                }
            }

            var additionalInfo = this.category.getFieldset("additionalInfo");
            additionalInfo.getField("orderStatus").value = editingOrder.orderStatus;
            additionalInfo.getField("orderStatus").items = this.data.orderStatuses;
            additionalInfo.getField("paymentMethod").value = editingOrder.paymentMethod;
            additionalInfo.getField("paymentMethod").items = this.data.paymentMethods;
            this.setPaymentMethodTypeItems(additionalInfo.getField("paymentMethod"));
            additionalInfo.getField("paymentMethodType").value = editingOrder.paymentMethodType;
            additionalInfo.getField("shippingMethod").value = editingOrder.shippingMethod;
            additionalInfo.getField("shippingMethod").items = this.data.shippingMethods;

            var billingInfo = this.category.getFieldset("billingInfo");
            billingInfo.getField("name").value = editingOrder.name;
            billingInfo.getField("lastName").value = editingOrder.lastName;
            billingInfo.getField("email").value = editingOrder.email;
            billingInfo.getField("phoneNumber").value = editingOrder.phoneNumber;
            billingInfo.getField("isBuyerCompany").value = editingOrder.isBuyerCompany;
            this.setCompanyFieldsVisibility(billingInfo.getField("isBuyerCompany"));
            billingInfo.getField("companyCode").value = editingOrder.companyCode;
            billingInfo.getField("companyName").value = editingOrder.companyName;
            billingInfo.getField("companyVat").value = editingOrder.companyVat;

            var billingShippingInfo = this.category.getFieldset("billingShippingInfo");
            billingShippingInfo.getField("address").value = editingOrder.address;
            billingShippingInfo.getField("city").value = editingOrder.city;
            billingShippingInfo.getField("postCode").value = editingOrder.postCode;
        });
    }

    attachFieldEvents() {
        if (this.category.getFieldset("orderFooterActions")) {
            if (this.category.getFieldset("orderFooterActions").getField("save")) {
                this.category.getFieldset("orderFooterActions").getField("save").onClick = this.save.bind(this);
            }
            if (this.category.getFieldset("orderFooterActions").getField("cancel")) {
                this.category.getFieldset("orderFooterActions").getField("cancel").onClick = this.cancel.bind(this);
            }
        }
        var additionalInfo = this.category.getFieldset("additionalInfo");
        if (additionalInfo) {
            var paymentMethod = additionalInfo.getField("paymentMethod");
            if (paymentMethod) {
                paymentMethod.onSelectClick = this.setPaymentMethodTypeItems.bind(this);
            }
        }
        var billingInfo = this.category.getFieldset("billingInfo");
        if (billingInfo) {
            var isBuyerCompany = billingInfo.getField("isBuyerCompany");
            if (isBuyerCompany) {
                isBuyerCompany.onClick = this.setCompanyFieldsVisibility.bind(this);
            }
        }
    }

    save(field: Field) {
        var saveOrder = {
            order: {
                address: this.category.getFieldset("billingShippingInfo").getField("address").value,
                city: this.category.getFieldset("billingShippingInfo").getField("city").value,
                companyCode: this.category.getFieldset("billingInfo").getField("companyCode").value,
                companyName: this.category.getFieldset("billingInfo").getField("companyName").value,
                companyVat: this.category.getFieldset("billingInfo").getField("companyVat").value,
                email: this.category.getFieldset("billingInfo").getField("email").value,
                id: this.data.order.id,
                isBuyerCompany: this.category.getFieldset("billingInfo").getField("isBuyerCompany").value,
                lastName: this.category.getFieldset("billingInfo").getField("lastName").value,
                name: this.category.getFieldset("billingInfo").getField("name").value,
                orderStatus: this.category.getFieldset("additionalInfo").getField("orderStatus").value,
                paymentMethod: this.category.getFieldset("additionalInfo").getField("paymentMethod").value,
                paymentMethodType: this.category.getFieldset("additionalInfo").getField("paymentMethodType").value,
                phoneNumber: this.category.getFieldset("billingInfo").getField("phoneNumber").value,
                postCode: this.category.getFieldset("billingShippingInfo").getField("postCode").value,
                shippingMethod: this.category.getFieldset("additionalInfo").getField("shippingMethod").value
            } as Order,
            routeUrl: this.category.navigations.last().url
        };
        saveOrder.order = new Order(saveOrder.order);

        for (var ifieldset in this.category.fieldsets) {
            var fieldset = this.category.getFieldset(ifieldset);
            for (var ifield in fieldset.fields) {
                var field = fieldset.getField(ifield);
                var fieldCharacteristic = field.getCharacteristic("characteristic");
                if (fieldCharacteristic) {
                    saveOrder.order.characteristics[fieldCharacteristic] = field.value;
                }
            }
        }

        this.httpService.post("/orderAdmin/saveOrder/", saveOrder).subscribe(response => {
            this.componentFactoryService.create(this.category.navigations[2].url);
        },
        response => {
            this.category.validateFieldsets(response);
        });
    }

    cancel() {
        this.componentFactoryService.create(this.category.navigations[2].url);
    }

    setCompanyFieldsVisibility(field: Field) {
        var billingInfo = this.category.getFieldset("billingInfo");
        billingInfo.getField("companyName").setCharacteristic("isHidden", !field.value);
        billingInfo.getField("companyCode").setCharacteristic("isHidden", !field.value);
        billingInfo.getField("companyVat").setCharacteristic("isHidden", !field.value);
    }

    setPaymentMethodTypeItems(field: Field) {
        if (!field.value) return;

        var additionalInfo = this.category.getFieldset("additionalInfo");
        var paymentMethodType = additionalInfo.getField("paymentMethodType");
        paymentMethodType.items = this.data.paymentMethods.find(o => o.value == field.value).paymentMethodTypes;
        if (paymentMethodType.items.length) {
            paymentMethodType.setCharacteristic("isHidden", false);
        }
        else {
            paymentMethodType.setCharacteristic("isHidden", true);
        }
    }
}
