import { OnInit, Injector } from '@angular/core';

import { BaseCategoryComponent } from "../../../shared/containers/base-category.component";
import { OrderData } from "../../../shared/models/order-data.model";
import { UserService } from "../../../shared/services/user.service";
import { Field } from "../../../shared/models/field.model";
import { Order } from "../../../shared/models/order.model";
import { ComponentFactoryService } from "../../../modules/component-factory/component-factory.service";
import { Resource } from "../../../shared/models/resource.model";
import { ToastrService } from "ngx-toastr";

export class OrderComponent extends BaseCategoryComponent implements OnInit {
    public static readonly componentName = "OrderComponent";
    public orderData: OrderData;

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
        this.getOrderData();
    }

    attachFieldEvents() {
        super.attachFieldEvents();
        var shippingInfo = this.category.getFieldset("shippingInfo");
        if (shippingInfo) {
            var shippingMethod = shippingInfo.getField("shippingMethod");
            if (shippingMethod) {
                shippingMethod.onSelectClick = this.setShippingMethod.bind(this);
                this.setShippingMethod(shippingMethod);
            }
        }

        var billingInfo = this.category.getFieldset("billingInfo");
        if (billingInfo) {
            var isBuyerCompany = billingInfo.getField("isBuyerCompany");
            if (isBuyerCompany) {
                isBuyerCompany.onClick = this.setCompanyFieldsVisibility.bind(this);
            }
        }

        var paymentInfo = this.category.getFieldset("paymentInfo");
        if (paymentInfo) {
            var paymentMethod = paymentInfo.getField("paymentMethod");
            if (paymentMethod) {
                paymentMethod.onSelectClick = this.setPaymentMethodTypeItems.bind(this);
                this.setPaymentMethodTypeItems(paymentMethod);
            }
        }

        var orderInfo = this.category.getFieldset("orderInfo");
        if (orderInfo) {
            var submitOrder = orderInfo.getField("submitOrder");
            if (submitOrder) {
                submitOrder.onClick = this.submitOrder.bind(this);
            }
        }
    }

    getOrderData() {
        this.httpService.get("/order/getOrderData").subscribe(result => {
            this.orderData = new OrderData(result);

            var paymentInfo = this.category.getFieldset("paymentInfo");
            paymentInfo.getField("paymentMethod").items = this.orderData.paymentMethods;

            var shippingInfo = this.category.getFieldset("shippingInfo");
            shippingInfo.getField("shippingMethod").items = this.orderData.shippingMethods;

            var billingInfo = this.category.getFieldset("billingInfo");
            billingInfo.getField("name").value = this.userService.user.name;
            billingInfo.getField("lastName").value = this.userService.user.lastName;
            billingInfo.getField("email").value = this.userService.user.email;
            billingInfo.getField("phoneNumber").value = this.userService.user.phoneNumber;
            billingInfo.getField("isBuyerCompany").value = this.userService.user.isBuyerCompany;
            billingInfo.getField("companyCode").value = this.userService.user.companyCode;
            billingInfo.getField("companyName").value = this.userService.user.companyName;
            billingInfo.getField("companyVat").value = this.userService.user.companyVat;
            this.setCompanyFieldsVisibility(billingInfo.getField("isBuyerCompany"));

            var billingShippingInfo = this.category.getFieldset("billingShippingInfo");
            billingShippingInfo.getField("address").value = this.userService.user.address;
            billingShippingInfo.getField("city").value = this.userService.user.city;
            billingShippingInfo.getField("postCode").value = this.userService.user.postCode;

            var orderInfo = this.category.getFieldset("orderInfo");
            var totalBasketPrice = orderInfo.getField("totalBasketPrice");
            totalBasketPrice.setCharacteristic("name", this.orderData.totalBasketPrice + "€");

            var totalBasketVat = orderInfo.getField("totalBasketVat");
            totalBasketVat.setCharacteristic("name", this.orderData.totalBasketVat + "€");
        });
    }

    submitOrder(field: Field) {
        var submitOrder = {
            order: {
                address: this.category.getFieldset("billingShippingInfo").getField("address").value,
                city: this.category.getFieldset("billingShippingInfo").getField("city").value,
                companyCode: this.category.getFieldset("billingInfo").getField("companyCode").value,
                companyName: this.category.getFieldset("billingInfo").getField("companyName").value,
                companyVat: this.category.getFieldset("billingInfo").getField("companyVat").value,
                email: this.category.getFieldset("billingInfo").getField("email").value,
                isBuyerCompany: this.category.getFieldset("billingInfo").getField("isBuyerCompany").value,
                lastName: this.category.getFieldset("billingInfo").getField("lastName").value,
                name: this.category.getFieldset("billingInfo").getField("name").value,
                paymentMethod: this.category.getFieldset("paymentInfo").getField("paymentMethod").value,
                paymentMethodType: this.category.getFieldset("paymentInfo").getField("paymentMethodType").value,
                phoneNumber: this.category.getFieldset("billingInfo").getField("phoneNumber").value,
                postCode: this.category.getFieldset("billingShippingInfo").getField("postCode").value,
                shippingMethod: this.category.getFieldset("shippingInfo").getField("shippingMethod").value
            } as Order,
            routeUrl: this.category.navigations.last().url
        };
        submitOrder.order = new Order(submitOrder.order);

        for (var ifieldset in this.category.fieldsets) {
            var fieldset = this.category.getFieldset(ifieldset);
            for (var ifield in fieldset.fields) {
                var field = fieldset.getField(ifield);
                var fieldCharacteristic = field.getCharacteristic("characteristic");
                if (fieldCharacteristic) {
                    submitOrder.order.characteristics[fieldCharacteristic] = field.value;
                }
            }
        }

        this.httpService.post("/order/submitOrder/", submitOrder).subscribe(response => {
            this.toastr.success("Jūsų užsakymas pabaigtas.", "AČIŪ.");
            this.httpService.getResources().subscribe(response => {
                var resource = new Resource(response);
                this.componentFactoryService.create(resource.loginRedirect);
            });
        },
        response => {
            this.category.validateFieldsets(response);
        });
    }

    setCompanyFieldsVisibility(field: Field) {
        var billingInfo = this.category.getFieldset("billingInfo");
        billingInfo.getField("companyName").setCharacteristic("isHidden", !field.value);
        billingInfo.getField("companyCode").setCharacteristic("isHidden", !field.value);
        billingInfo.getField("companyVat").setCharacteristic("isHidden", !field.value);
    }

    setShippingMethod(field: Field) {
        var orderInfo = this.category.getFieldset("orderInfo");
        var shippingPrice = orderInfo.getField("shippingPrice");
        shippingPrice.setCharacteristic("isHidden", false);

        if (!field.value) {
            shippingPrice.setCharacteristic("isHidden", true);
            return;
        }

        shippingPrice.setCharacteristic("name", this.orderData.shippingMethods.find(o => o.value == field.value).price + "€");
    }

    setPaymentMethodTypeItems(field: Field) {
        if (!field.value) return;

        var paymentInfo = this.category.getFieldset("paymentInfo");
        var paymentMethodType = paymentInfo.getField("paymentMethodType");
        paymentMethodType.items = this.orderData.paymentMethods.find(o => o.value == field.value).paymentMethodTypes;
    }
}
