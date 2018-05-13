import { OnInit, Injector } from '@angular/core';
import { BasePagedCategoryComponent } from "../../../shared/containers/base-paged-category.component";
import { Field } from "../../../shared/models/field.model";
import { PagedList } from "../../../shared/models/table-page.model";
import { Product } from "../../../shared/models/product.model";

export class HomeComponent extends BasePagedCategoryComponent implements OnInit {
    public static readonly componentName = "HomeComponent";

    constructor(public injector: Injector) {
        super(injector);
    }

    ngOnInit() {
        super.ngOnInit();
    }

    setPage(field: Field) {
        this.category.products = new PagedList<Product>(null);
        var pagedListCommand = this.getPagedListCommand();
        pagedListCommand.isShowHomePage = true;

        this.httpService.get<PagedList<Product>>("/product/listProductsByCategory", pagedListCommand).subscribe(result => {
            this.category.products = new PagedList<Product>(result);
            this.category.products.items = result.items.map(o => {
                return new Product(o);
            });

            field.customs.pager = this.paginationService.getPager(this.category.products.totalCount, this.category.products.pageIndex, this.category.products.pageSize);
        });
    }
}
