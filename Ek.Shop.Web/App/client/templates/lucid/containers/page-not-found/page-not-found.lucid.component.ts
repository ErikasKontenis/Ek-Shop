import { Component, OnInit, Injector } from '@angular/core';
import { PageNotFoundComponent } from '../../../../containers/page-not-found/page-not-found.component';

@Component({
    selector: 'page-not-found-lucid',
    templateUrl: './page-not-found.lucid.component.html'
})

export class PageNotFoundLucidComponent extends PageNotFoundComponent implements OnInit {
    constructor(public injector: Injector) {
        super(injector);
    }

    ngOnInit() {

    }
}
