import { Component, Input, OnInit } from '@angular/core';
import { Field } from "../../../shared/models/field.model";
import { LocationService } from "../../../shared/services/location.service";

@Component({
    selector: 'app-pagination',
    templateUrl: './pagination.component.html',
    styleUrls: ['./pagination.component.scss']
})
export class PaginationComponent implements OnInit {
    constructor(public location: LocationService) { }
    @Input() field: Field;

    pager: any;

    ngOnInit() {
        if (!this.field) return;

        this.pager = this.field.customs.pager;
        if (!this.field || !this.field.value) {
            this.field.value = 1;
        }
    }

    onClick(pageIndex: number) {
        if (pageIndex <= 0 || pageIndex > this.field.customs.pager.totalPages
        || this.field.value == pageIndex) {
            return;
        }

        this.field.value = pageIndex;

        if (pageIndex <= 1) {
            this.setUrlQuery(null);
        }
        else {
            this.setUrlQuery();
        }

        if (this.field.onClick) {
            this.field.onClick(this.field);
        }
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
