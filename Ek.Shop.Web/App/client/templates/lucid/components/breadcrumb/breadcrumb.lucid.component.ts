import { Component, Input, OnInit } from '@angular/core';
import { CategoryNavigation } from "../../../../../shared/models/category-navigation.model";

@Component({
    selector: 'breadcrumb-lucid',
    templateUrl: './breadcrumb.lucid.component.html'
})
export class BreadcrumbLucidComponent implements OnInit {
    private _navigations: CategoryNavigation[];
    public lastNavigation: CategoryNavigation;

    @Input()
    set navigations(navigations: CategoryNavigation[]) {
        this.lastNavigation = navigations.filter(item => navigations.indexOf(item) + 1 === navigations.length)[0];
        this._navigations = navigations.filter(item => navigations.indexOf(item) + 1 !== navigations.length);
    }
    get navigations(): CategoryNavigation[] {
        return this._navigations;
    }

    ngOnInit() {

    }
}
