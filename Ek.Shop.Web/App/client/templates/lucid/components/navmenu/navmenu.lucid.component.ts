import { Component, OnInit, Inject, ViewChild } from '@angular/core';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { HttpService } from '../../../../../shared/services/http.service';
import { CategoryNavigation } from "../../../../../shared/models/category-navigation.model";
import { UserService } from "../../../../../shared/services/user.service";

@Component({
    selector: 'nav-menu-lucid',
    templateUrl: './navmenu.lucid.component.html',
    styleUrls: ['./navmenu.lucid.component.css']
})

export class NavMenuLucidComponent {
    public productNavigations: CategoryNavigation[];
    public parentProductNavigations: CategoryNavigation[];
    public topNavigations: CategoryNavigation[];
    public firstNavigation: CategoryNavigation;
    public topUserNavigations: CategoryNavigation[];
    //public languagesDropdown: IField;
    public productNavigationsContainerSplit: number[]; // TODO: this data needs to come from inputFormOption
    private _recommendedContainerSplitCount: number = 4;

    constructor(private httpService: HttpService, public userService: UserService)
    { }

    ngOnInit() {
        this.httpService.get<CategoryNavigation[]>("/category/getCategoryNavigations").subscribe(result => {
            var navigations: CategoryNavigation[] = result.map(o => {
                return new CategoryNavigation(o);
            });

            this.firstNavigation = navigations.filter(o => o.parentId == null)[0];
            this.parentProductNavigations = navigations.filter(o => o.type === "Product" && o.parentId == this.firstNavigation.id);
            

            this.productNavigations = navigations.filter(o => o.type === "Product");
            this.topNavigations = navigations.filter(o => o.type === "Top");
            this.topUserNavigations = navigations.filter(o => o.type === "TopUser");
            
            
        });
    }

    formSub1ProductNavigationContainers(parentCategoryId: number) {
        var sub1ProductNavigationContainers;
        var sub1ProductNavigations: CategoryNavigation[] = this.productNavigations.filter(i => i.parentId === parentCategoryId);

        if (!this.productNavigationsContainerSplit) {
            var chunkNumber = 1;
            if (sub1ProductNavigations && sub1ProductNavigations.length > 1)
                chunkNumber = sub1ProductNavigations.length / this._recommendedContainerSplitCount;

            sub1ProductNavigationContainers = sub1ProductNavigations.chunkArray(chunkNumber);
        }
        else {
            sub1ProductNavigationContainers = [];
            this.productNavigationsContainerSplit.forEach((splitNumber, i) => {
                if (i >= 1) {
                    var sub1Navigations = sub1ProductNavigations.splice(0, splitNumber)
                    sub1ProductNavigations.removeRange(sub1Navigations);
                    sub1ProductNavigationContainers.push(sub1Navigations);
                }
            });
            if (sub1ProductNavigations.length > 0) {
                sub1ProductNavigationContainers.push(sub1ProductNavigations);
            }
        }

        return sub1ProductNavigationContainers;
    }

    filterParentNavigation(navigation: CategoryNavigation) {
        return navigation.parentId == null
    }
}
