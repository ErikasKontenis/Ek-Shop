import { Component, Input, OnInit } from '@angular/core';
import { Field } from "../../../shared/models/field.model";
import { LocationService } from "../../../shared/services/location.service";

@Component({
    selector: 'app-dropdown',
    templateUrl: './dropdown.component.html'
})
export class DropdownComponent implements OnInit {
    constructor(public location: LocationService) { }
    @Input() field: Field;

    fieldText: string;

    ngOnInit() {
        var parameter = this.field.getCharacteristic("parameter");
        if (parameter && parameter.items) {
            this.field.items = parameter.items;
        }

        if (this.field.value) {
            var item = this.field.items.find(o => o.value == this.field.value);
            if (item) {
                this.fieldText = item.text;
                this.setFieldValue(item);
            }
        }
    }

    onClick() {

    };

    onSelectClick(item) {
        this.setFieldValue(item);
        this.field.isFieldValid();

        if (this.field.onSelectClick) {
            this.field.onSelectClick(this.field, item);
        }

        this.setUrlQuery();
    };

    setFieldValue(item) {
        this.field.value = item.value;
        this.fieldText = item.text;
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
