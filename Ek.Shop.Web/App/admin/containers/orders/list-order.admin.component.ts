import { Component, OnInit, ReflectiveInjector, Injector } from '@angular/core';
import { Location, LocationStrategy } from '@angular/common';

import { BasePagedCategoryComponent } from "../../../shared/containers/base-paged-category.component";
import { HttpService } from '../../../shared/services/http.service';
import { ListCategoryAdminComponentItem } from "../../../shared/models/list-category-admin-component-item.model";
import { PagedList } from "../../../shared/models/table-page.model";
import { Category } from "../../../shared/models/category.model";
import { Field } from "../../../shared/models/field.model";
import { Order } from "../../../shared/models/order.model";

@Component({
    selector: 'list-order-admin',
    templateUrl: './list-order.admin.component.html'
})
export class ListOrderAdminComponent extends BasePagedCategoryComponent implements OnInit {
    public static readonly componentName = "ListOrderAdminComponent";
    public pagedList: PagedList<Order>;

    constructor(public injector: Injector,
        public httpService: HttpService) {
        super(injector);
    }

    ngOnInit() {
        super.ngOnInit();
        var orderIdField = this.category.getAnyField("orderId");
        if (orderIdField) {
            var orderIdQueryValue = this.location.getUrlQueryByName(orderIdField.getCharacteristic("urlQuery"));
            if (orderIdQueryValue) {
                orderIdField.value = orderIdQueryValue;
            }
        }
        var billingNameField = this.category.getAnyField("billingName");
        if (billingNameField) {
            var billingNameQueryValue = this.location.getUrlQueryByName(billingNameField.getCharacteristic("urlQuery"));
            if (billingNameQueryValue) {
                billingNameField.value = billingNameQueryValue;
            }
        }
        var billingLastNameField = this.category.getAnyField("billingLastName");
        if (billingLastNameField) {
            var billingLastNameQueryValue = this.location.getUrlQueryByName(billingLastNameField.getCharacteristic("urlQuery"));
            if (billingLastNameQueryValue) {
                billingLastNameField.value = billingLastNameQueryValue;
            }
        }
        var billingEmailField = this.category.getAnyField("billingEmail");
        if (billingEmailField) {
            var billingEmailQueryValue = this.location.getUrlQueryByName(billingEmailField.getCharacteristic("urlQuery"));
            if (billingEmailQueryValue) {
                billingEmailField.value = billingEmailQueryValue;
            }
        }
    }

    attachFieldEvents() {
        super.attachFieldEvents();
        var submitSearchField = this.category.getAnyField("submitSearch");
        if (submitSearchField) {
            submitSearchField.onClick = this.submitSearch.bind(this);
        }
    }

    submitSearch(field: Field) {
        var orderIdField = this.category.getAnyField("orderId");
        if (orderIdField.getCharacteristic("urlQuery")) {
            this.location.updateQueryString(orderIdField.getCharacteristic("urlQuery"), orderIdField.value);
        }
        var billingNameField = this.category.getAnyField("billingName");
        if (billingNameField.getCharacteristic("urlQuery")) {
            this.location.updateQueryString(billingNameField.getCharacteristic("urlQuery"), billingNameField.value);
        }
        var billingLastNameField = this.category.getAnyField("billingLastName");
        if (billingLastNameField.getCharacteristic("urlQuery")) {
            this.location.updateQueryString(billingLastNameField.getCharacteristic("urlQuery"), billingLastNameField.value);
        }
        var billingEmailField = this.category.getAnyField("billingEmail");
        if (billingEmailField.getCharacteristic("urlQuery")) {
            this.location.updateQueryString(billingEmailField.getCharacteristic("urlQuery"), billingEmailField.value);
        }

        var paginationField = this.category.getAnyField("pagination");
        this.setPage(paginationField);
    }

    setPage(field: Field) {
        this.pagedList = new PagedList<Order>(null);
        var pagedListCommand = this.getPagedListCommand();
        pagedListCommand.id = this.category.getAnyField("orderId").value;
        pagedListCommand.billingName = this.category.getAnyField("billingName").value;
        pagedListCommand.billingLastName = this.category.getAnyField("billingLastName").value;
        pagedListCommand.billingEmail = this.category.getAnyField("billingEmail").value;

        this.httpService.get<PagedList<Order>>("/orderAdmin/listOrders", pagedListCommand).subscribe(result => {
            this.pagedList = new PagedList<Order>(result);
            this.pagedList.items = result.items.map(o => {
                return new Order(o);
            });

            field.customs.pager = this.paginationService.getPager(this.pagedList.totalCount, this.pagedList.pageIndex, this.pagedList.pageSize);
        });
    }
}
