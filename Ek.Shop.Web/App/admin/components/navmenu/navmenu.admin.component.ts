import { Component, OnInit, Inject, ViewChild } from '@angular/core';

import { HttpService } from '../../../shared/services/http.service';
import { CategoryNavigation } from "../../../shared/models/category-navigation.model";

@Component({
    selector: 'navmenu-admin',
    templateUrl: './navmenu.admin.component.html'
})
export class NavMenuAdminComponent {
    public activeTabIndex: number = -1;
    public firstNavigation: CategoryNavigation;
    public leftNavigations: CategoryNavigation[];

    constructor(private httpService: HttpService)
    { }

    ngOnInit() {
        this.httpService.get<CategoryNavigation[]>("/categoryAdmin/getCategoryNavigations").subscribe(result => {
            var navigations: CategoryNavigation[] = result.map(o => {
                return new CategoryNavigation(o);
            });
            this.leftNavigations = navigations.filter(o => o.type === "Left");
            this.firstNavigation = navigations.filter(o => o.parentId == null)[0];
        });
    }
}
