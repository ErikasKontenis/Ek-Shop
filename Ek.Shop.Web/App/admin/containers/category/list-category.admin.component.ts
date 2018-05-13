import { Component, OnInit, ReflectiveInjector, Injector } from '@angular/core';
import { Location, LocationStrategy } from '@angular/common';

import { BasePagedCategoryComponent } from "../../../shared/containers/base-paged-category.component";
import { HttpService } from '../../../shared/services/http.service';
import { ListCategoryAdminComponentItem } from "../../../shared/models/list-category-admin-component-item.model";
import { PagedList } from "../../../shared/models/table-page.model";
import { Category } from "../../../shared/models/category.model";
import { Field } from "../../../shared/models/field.model";

@Component({
    selector: 'list-category-admin',
    templateUrl: './list-category.admin.component.html'
})
export class ListCategoryAdminComponent extends BasePagedCategoryComponent implements OnInit {
    public static readonly componentName = "ListCategoryAdminComponent";
    public pagedList: PagedList<Category>;

    constructor(public injector: Injector,
        public httpService: HttpService) {
        super(injector);
    }

    ngOnInit() {
        super.ngOnInit();
    }

    setPage(field: Field) {
        this.pagedList = new PagedList<Category>(null);
        var pagedListCommand = this.getPagedListCommand();
        pagedListCommand.categoryId = this.category.id;

        this.httpService.get<PagedList<Category>>("/categoryAdmin/listCategories", pagedListCommand).subscribe(result => {
            this.pagedList = new PagedList<Category>(result);
            this.pagedList.items = result.items.map(o => {
                return new Category(o);
            });

            field.customs.pager = this.paginationService.getPager(this.pagedList.totalCount, this.pagedList.pageIndex, this.pagedList.pageSize);
        });
    }
}
