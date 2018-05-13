import { Component, OnInit, Injector } from '@angular/core';
import { ToastrService } from "ngx-toastr";

import { ProductComponent } from '../../../../containers/product/product.component';
import { HttpService } from "../../../../../shared/services/http.service";

@Component({
    selector: 'product-lucid',
    templateUrl: './product.lucid.component.html'
})

export class ProductLucidComponent extends ProductComponent implements OnInit {
    constructor(public injector: Injector,
        public httpService: HttpService,
        public toastr: ToastrService
    ) {
        super(injector, httpService, toastr);
    }

    ngOnInit() {
        super.ngOnInit();
    }
}
