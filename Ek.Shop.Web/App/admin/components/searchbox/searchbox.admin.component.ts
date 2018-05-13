import { Component, Input, OnInit } from '@angular/core';
import { LocationService } from "../../../shared/services/location.service";
import { Field } from "../../../shared/models/field.model";

@Component({
    selector: 'searchbox-admin',
    templateUrl: './searchbox.admin.component.html'
})
export class SearchboxAdminComponent implements OnInit {
    constructor(public location: LocationService) { }

    @Input() field: Field;

    ngOnInit() {

    }

    onClick() {
        if (this.field.onClick) {
            this.field.onClick(this.field);
        }

        this.setUrlQuery();
    }

    setUrlQuery(value?: any) {
        if (value === undefined) {
            value = this.field.value;
        }

        if (this.field.getCharacteristic("urlQuery")) {
            this.location.updateQueryString(this.field.getCharacteristic("urlQuery"), value);
        }
    }
}
