import { OnInit, Injector } from '@angular/core';

import { BaseCategoryComponent } from "../../../shared/containers/base-category.component";
import { Basket } from "../../../shared/models/basket.model";

export class BasketComponent extends BaseCategoryComponent implements OnInit {
    public static readonly componentName = "BasketComponent";
    public basket: Basket;

    constructor(public injector: Injector) {
        super(injector);
    }

    ngOnInit() {
        super.ngOnInit();
        this.attachFieldEvents();
        this.getBasket();
    }

    attachFieldEvents() {
        super.attachFieldEvents();
        //var checkoutField = this.category.getAnyField("checkout");
        //if (checkoutField) {
        //    checkoutField.onClick = this.checkout.bind(this);
        //}
    }

    getBasket() {
        this.httpService.get("/basket/getBasket").subscribe(result => {
            this.basket = new Basket(result);
        });
    }

    deleteBasketItem(basketItemId: number) {
        this.httpService.post("/basket/deleteBasketItem", { basketItemId: basketItemId }).subscribe(result => {
            this.basket.basketItems.remove(this.basket.basketItems.find(o => o.id === basketItemId));
        });
    }

    //checkout() {
    //    this.category.headerErrors = [];

    //    this.httpService.post<Product>("/basket/checkout/", null)
    //        .subscribe(response => {
    //            var product = new Product(response);
    //            this.toastr.success(product.getCharacteristic("name") + " - " + product.getTotalPrice() + "€");
    //        },
    //        response => {
    //            this.category.validateFieldsets(response);
    //        });
    //}
}
