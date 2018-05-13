import { Component, Input, OnInit } from '@angular/core';
import { CategoryNavigation } from "../../../shared/models/category-navigation.model";

@Component({
    selector: 'breadcrumb-admin',
    templateUrl: './breadcrumb.admin.component.html'
})
export class BreadcrumbAdminComponent implements OnInit {
    @Input()
    navigations: CategoryNavigation[];

    ngOnInit() {

    }
}
