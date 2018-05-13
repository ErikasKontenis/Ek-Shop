import { Component, OnInit, Injector, Input } from '@angular/core';
import { Location, LocationStrategy } from '@angular/common';

import { BaseCategoryComponent } from '../../../shared/containers/base-category.component';
import { HttpService } from '../../../shared/services/http.service';
import { ComponentFactoryService } from '../../../modules/component-factory/component-factory.service';
import { Category } from '../../../shared/models/category.model';
import { Field } from "../../../shared/models/field.model";
import { FileUploadService } from "../../../shared/services/file-upload.service";

@Component({
    selector: 'edit-category-admin',
    templateUrl: './edit-category.admin.component.html'
})
export class EditCategoryAdminComponent extends BaseCategoryComponent implements OnInit {
    public static readonly componentName = "EditCategoryAdminComponent";
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
        var categoryId = this.location.path().split('/').last();
        this.httpService.get("/categoryAdmin/getEditCategoryData?id=" + (Number(categoryId) ? categoryId : 0)).subscribe(result => {
            this.data = result;
            var editingCategory = new Category(this.data.category);
            for (var ifieldset in this.category.fieldsets) {
                var fieldset = this.category.getFieldset(ifieldset);
                for (var ifield in fieldset.fields) {
                    var field = fieldset.getField(ifield);
                    var fieldCharacteristic = field.getCharacteristic("characteristic");
                    if (fieldCharacteristic) {
                        field.value = editingCategory.getCharacteristic(fieldCharacteristic.firstLetterToLowerCase())
                    }
                }
            }

            var categoryInfo = this.category.getFieldset("categoryInfo");
            categoryInfo.getField("categoryTypeCode").value = editingCategory.categoryTypeCode;
            categoryInfo.getField("categoryTypeCode").items = this.data.categoryTypes;
            categoryInfo.getField("parentId").value = editingCategory.parentId;
            categoryInfo.getField("parentId").items = this.data.parentCategories;
            categoryInfo.getField("angularComponentCode").value = editingCategory.angularComponentCode;
            categoryInfo.getField("angularComponentCode").items = this.data.angularComponents;
            categoryInfo.getField("isDisabled").value = editingCategory.getCharacteristic("isDisabled") == "True" ? false : true;

            var categorySeo = this.category.getFieldset("categorySeo");
            categorySeo.getField("title").value = editingCategory.title;
            categorySeo.getField("description").value = editingCategory.description;
            categorySeo.getField("url").value = editingCategory.url;
        });
    }

    attachFieldEvents() {
        if (this.category.getFieldset("footerActions")) {
            if (this.category.getFieldset("footerActions").getField("save")) {
                this.category.getFieldset("footerActions").getField("save").onClick = this.save.bind(this);
            }
            if (this.category.getFieldset("footerActions").getField("cancel")) {
                this.category.getFieldset("footerActions").getField("cancel").onClick = this.cancel.bind(this);
            }
            if (this.category.getFieldset("footerActions").getField("delete")) {
                this.category.getFieldset("footerActions").getField("delete").onClick = this.delete.bind(this);
            }
        }
    }

    save(field: Field) {
        var saveCategory = {
            category: {
                angularComponentCode: this.category.getFieldset("categoryInfo").getField("angularComponentCode").value,
                categoryTypeCode: this.category.getFieldset("categoryInfo").getField("categoryTypeCode").value,
                characteristics: {},
                description: this.category.getFieldset("categorySeo").getField("description").value,
                id: this.data.category.id,
                parentId: this.category.getFieldset("categoryInfo").getField("parentId").value,
                title: this.category.getFieldset("categorySeo").getField("title").value,
                url: this.category.getFieldset("categorySeo").getField("url").value,
                images: this.data.category.images
            } as Category, // TODO: Implement category objects auto merge from fieldsets.fields with same ids
            routeUrl: this.category.navigations.last().url
        };
        saveCategory.category = new Category(saveCategory.category);

        for (var ifieldset in this.category.fieldsets) {
            var fieldset = this.category.getFieldset(ifieldset);
            for (var ifield in fieldset.fields) {
                var field = fieldset.getField(ifield);
                var fieldCharacteristic = field.getCharacteristic("characteristic");
                if (fieldCharacteristic) {
                    saveCategory.category.characteristics[fieldCharacteristic] = field.value;
                }
            }
        }

        var categoryInfo = this.category.getFieldset("categoryInfo");
        saveCategory.category.setCharacteristic("isDisabled", !categoryInfo.getField("isDisabled").value);

        if (saveCategory.category.images) {
            this.fileUploadService.uploadFiles(saveCategory.category.images.map(o => o.file));
        }
        this.httpService.post("/categoryAdmin/saveCategory/", saveCategory).subscribe(response => {
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
        this.httpService.post("/categoryAdmin/deleteCategory/", this.data.category.id).subscribe(response => {
            this.componentFactoryService.create(this.category.navigations[2].url);
        },
        response => {
            
        });
    }
}
