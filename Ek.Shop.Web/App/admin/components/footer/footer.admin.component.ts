import { Component, OnInit, Inject } from '@angular/core';

@Component({
    selector: 'footer-admin',
    templateUrl: './footer.admin.component.html'
})
export class FooterAdminComponent {
    constructor()
    { }

    dateNow: Date = new Date();
    ngOnInit() {

    }
}
