import { Component, OnInit, ReflectiveInjector, Injector } from '@angular/core';

import { BaseComponent } from '../../../shared/containers/base.component';

@Component({
    selector: 'page-not-found-admin',
    templateUrl: './page-not-found.admin.component.html'
})
export class PageNotFoundAdminComponent extends BaseComponent implements OnInit {
    public static readonly componentName = "PageNotFoundAdminComponent";

    constructor(public injector: Injector) {
        super(injector);
    }

    ngOnInit() {

    }
}
