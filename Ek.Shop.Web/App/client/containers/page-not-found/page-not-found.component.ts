import { OnInit, Injector } from '@angular/core';

import { BaseComponent } from "../../../shared/containers/base.component";

export class PageNotFoundComponent extends BaseComponent implements OnInit {
    public static readonly componentName = "PageNotFoundComponent";
    private componentFactoryData: any;

    constructor(public injector: Injector) {
        super(injector);
    }

    ngOnInit() {

    }
}
