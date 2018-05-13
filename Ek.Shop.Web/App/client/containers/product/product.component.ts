import { OnInit, Injector } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

import { BaseComponent } from "../../../shared/containers/base.component";
import { Product } from "../../../shared/models/product.model";
import { Image } from "../../../shared/models/image.model";
import { HttpService } from "../../../shared/services/http.service";

export class ProductComponent extends BaseComponent implements OnInit {
    public static readonly componentName = "ProductComponent";
    private componentFactoryData: any;
    public product: Product;

    constructor(public injector: Injector,
        public httpService: HttpService,
        public toastr: ToastrService) {
        super(injector);
    }

    ngOnInit() {
        this.product = new Product(this.componentFactoryData);
        this.attachFieldEvents();
    }

    attachFieldEvents() {
        var basketAddField = this.product.getAnyField("basketAdd");
        if (basketAddField) {
            basketAddField.onClick = this.addProductToBasket.bind(this);
        }
    }

    addProductToBasket() {
        this.product.headerErrors = [];

        var addProductToBasketCommand = {
            productId: this.product.id,
            quantity: this.product.getAnyField("quantity").value
        };

        this.httpService.post<Product>("/basket/addProductToBasket/", addProductToBasketCommand)
            .subscribe(response => {
                var product = new Product(response);
                this.toastr.success(product.getCharacteristic("name") + " - " + product.getTotalPrice() + "€");
            },
            response => {
                this.product.validateFieldsets(response);
            });
    }

    filterSmallSizeImages(image: Image) {
        return image.imageSizeType == "Small"
    }
}
