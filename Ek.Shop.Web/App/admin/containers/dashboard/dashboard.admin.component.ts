import { Component, OnInit, ReflectiveInjector, Injector } from '@angular/core';
import { Location, LocationStrategy } from '@angular/common';

import { BaseCategoryComponent } from '../../../shared/containers/base-category.component';

@Component({
    selector: 'dashboard-admin',
    templateUrl: './dashboard.admin.component.html'
})
export class DashboardAdminComponent extends BaseCategoryComponent implements OnInit {
    public static readonly componentName = "DashboardAdminComponent";
    public data: any;

    constructor(public injector: Injector) {
        super(injector);
    }

    ngOnInit() {
        super.ngOnInit();
        this.httpService.get("/dashboardAdmin/getDashboard").subscribe(result => {
            this.data = result;
        });
    }
}
