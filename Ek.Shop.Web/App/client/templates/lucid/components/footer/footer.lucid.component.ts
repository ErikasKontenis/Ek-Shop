import { Component, OnInit, Inject } from '@angular/core';
import { HttpService } from "../../../../../shared/services/http.service";
import { CategoryNavigation } from "../../../../../shared/models/category-navigation.model";

@Component({
    selector: 'footer-lucid',
    templateUrl: './footer.lucid.component.html'
})
export class FooterLucidComponent {
    public footerNavigations: CategoryNavigation[];

    constructor(private httpService: HttpService)
    { }

    dateNow: Date = new Date();

    ngOnInit() {
        this.httpService.get<CategoryNavigation[]>("/category/getCategoryNavigations").subscribe(result => {
            var navigations: CategoryNavigation[] = result.map(o => {
                return new CategoryNavigation(o);
            });
            this.footerNavigations = navigations.filter(o => o.type === "Footer");
        });
    }

    filterParentNavigation(navigation: CategoryNavigation) {
        console.log(navigation);
        return navigation.parentId == null
    }
}
