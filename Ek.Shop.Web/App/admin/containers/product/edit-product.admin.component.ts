import { Component, OnInit, Injector, Input } from '@angular/core';
import { Location, LocationStrategy } from '@angular/common';

import { BaseCategoryComponent } from '../../../shared/containers/base-category.component';
import { HttpService } from '../../../shared/services/http.service';
import { ComponentFactoryService } from '../../../modules/component-factory/component-factory.service';
import { Category } from '../../../shared/models/category.model';
import { Field } from "../../../shared/models/field.model";
import { FileUploadService } from "../../../shared/services/file-upload.service";
import { Product } from "../../../shared/models/product.model";

@Component({
    selector: 'edit-product-admin',
    templateUrl: './edit-product.admin.component.html'
})
export class EditProductAdminComponent extends BaseCategoryComponent implements OnInit {
    public static readonly componentName = "EditProductAdminComponent";
    public data: any;

    constructor(public injector: Injector,
        public httpService: HttpService,
        public componentFactoryService: ComponentFactoryService,
        public fileUploadService: FileUploadService) {
        super(injector);
    }

    ngOnInit() {
        super.ngOnInit();
        this.attachFieldEvents();
        var productId = this.location.path().split('/').last();
        this.httpService.get(`/productAdmin/getEditProductData?id=${(Number(productId) ? productId : 0)}&languageId=1`).subscribe(result => {
            this.data = result;
            var editingProduct = new Product(this.data.product);
            for (var ifieldset in this.category.fieldsets) {
                var fieldset = this.category.getFieldset(ifieldset);
                for (var ifield in fieldset.fields) {
                    var field = fieldset.getField(ifield);
                    var fieldCharacteristic = field.getCharacteristic("characteristic");
                    if (fieldCharacteristic) {
                        field.value = editingProduct.getCharacteristic(fieldCharacteristic.firstLetterToLowerCase())
                    }
                }
            }

            var productInfo = this.category.getFieldset("productInfo");
            productInfo.getField("categoryId").value = editingProduct.categoryId;
            productInfo.getField("categoryId").items = this.data.categories;
            productInfo.getField("angularComponentCode").value = editingProduct.angularComponentCode;
            productInfo.getField("angularComponentCode").items = this.data.angularComponents;
            productInfo.getField("isDisabled").value = editingProduct.getCharacteristic("isDisabled") == "True" ? false : true;
            productInfo.getField("price").value = editingProduct.price;
            productInfo.getField("discount").value = editingProduct.discount;

            var productSeo = this.category.getFieldset("productSeo");
            productSeo.getField("title").value = editingProduct.title;
            productSeo.getField("description").value = editingProduct.description;
            productSeo.getField("url").value = editingProduct.url;
        });
    }

    attachFieldEvents() {
        super.attachFieldEvents();
        var footerActionsFieldset = this.category.getFieldset("footerActions");
        if (footerActionsFieldset) {
            var saveField = footerActionsFieldset.getField("save");
            if (saveField) {
                saveField.onClick = this.save.bind(this);
            }
            var cancelField = footerActionsFieldset.getField("cancel");
            if (cancelField) {
                cancelField.onClick = this.cancel.bind(this);
            }
            var deleteField = footerActionsFieldset.getField("delete");
            if (deleteField) {
                deleteField.onClick = this.delete.bind(this);
            }
        }

        var productInfoFieldset = this.category.getFieldset("productInfo");
        if (productInfoFieldset) {
            var priceField = productInfoFieldset.getField("price");
            if (priceField) {
                priceField.onBlur = () => {
                    var fieldValueToNumber = +priceField.value;
                    if (fieldValueToNumber) {
                        priceField.value = fieldValueToNumber;
                    }
                }
            }
            var discountField = productInfoFieldset.getField("discount");
            if (discountField) {
                discountField.onBlur = () => {
                    var fieldValueToNumber = +discountField.value;
                    if (fieldValueToNumber) {
                        discountField.value = fieldValueToNumber;
                    }
                }
            }
        }
    }

    save(field: Field) {
        var saveProduct = {
            product: {
                angularComponentCode: this.category.getFieldset("productInfo").getField("angularComponentCode").value,
                categoryId: this.category.getFieldset("productInfo").getField("categoryId").value,
                characteristics: {},
                description: this.category.getFieldset("productSeo").getField("description").value,
                discount: this.category.getFieldset("productInfo").getField("discount").value,
                id: this.data.product.id,
                price: this.category.getFieldset("productInfo").getField("price").value,
                title: this.category.getFieldset("productSeo").getField("title").value,
                url: this.category.getFieldset("productSeo").getField("url").value,
                images: this.data.product.images
            } as Product,
            routeUrl: this.category.navigations.last().url
        };
        saveProduct.product = new Product(saveProduct.product);

        for (var ifieldset in this.category.fieldsets) {
            var fieldset = this.category.getFieldset(ifieldset);
            for (var ifield in fieldset.fields) {
                var field = fieldset.getField(ifield);
                var fieldCharacteristic = field.getCharacteristic("characteristic");
                if (fieldCharacteristic) {
                    saveProduct.product.characteristics[fieldCharacteristic] = field.value;
                }
            }
        }

        var productInfo = this.category.getFieldset("productInfo");
        saveProduct.product.setCharacteristic("isDisabled", !productInfo.getField("isDisabled").value);

        if (saveProduct.product.images) {
            this.fileUploadService.uploadFiles(saveProduct.product.images.map(o => o.file));
        }
        this.httpService.post("/productAdmin/saveProduct/", saveProduct).subscribe(response => {
            this.componentFactoryService.create(this.category.navigations[2].url);
        },
        response => {
            this.category.validateFieldsets(response);
        });
    }

    cancel() {
        this.componentFactoryService.create(this.category.navigations[2].url);
    }

    delete() {
        this.httpService.post("/productAdmin/deleteProduct/", this.data.product.id).subscribe(response => {
            this.componentFactoryService.create(this.category.navigations[2].url);
        },
        response => {

        });
    }
}
