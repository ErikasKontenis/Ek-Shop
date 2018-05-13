import { Component, OnInit, ReflectiveInjector, Injector } from '@angular/core';
import { Location, LocationStrategy } from '@angular/common';

import { BasePagedCategoryComponent } from "../../../shared/containers/base-paged-category.component";
import { HttpService } from '../../../shared/services/http.service';
import { ListCategoryAdminComponentItem } from "../../../shared/models/list-category-admin-component-item.model";
import { PagedList } from "../../../shared/models/table-page.model";
import { Field } from "../../../shared/models/field.model";
import { Product } from "../../../shared/models/product.model";

@Component({
    selector: 'list-product-admin',
    templateUrl: './list-product.admin.component.html'
})
export class ListProductAdminComponent extends BasePagedCategoryComponent implements OnInit {
    public static readonly componentName = "ListProductAdminComponent";
    public pagedList: PagedList<Product>;

    constructor(public injector: Injector,
        public httpService: HttpService) {
        super(injector);
    }

    ngOnInit() {
        super.ngOnInit();
    }

    setPage(field: Field) {
        this.pagedList = new PagedList<Product>(null);

        this.httpService.get<PagedList<Product>>("/productAdmin/listProducts", this.getPagedListCommand()).subscribe(result => {
            this.pagedList = new PagedList<Product>(result);
            this.pagedList.items = result.items.map(o => {
                return new Product(o);
            });

            field.customs.pager = this.paginationService.getPager(this.pagedList.totalCount, this.pagedList.pageIndex, this.pagedList.pageSize);
        });
    }
}
