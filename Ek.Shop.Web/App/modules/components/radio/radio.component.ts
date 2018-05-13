import { Component, Input, OnInit } from '@angular/core';
import { Field } from "../../../shared/models/field.model";
import { LocationService } from "../../../shared/services/location.service";

@Component({
    selector: 'app-radio',
    templateUrl: './radio.component.html'
})
export class RadioComponent implements OnInit {
    constructor(public location: LocationService) { }
    @Input() field: Field;

    ngOnInit() {
        var parameter = this.field.getCharacteristic("parameter");
        if (parameter && parameter.items) {
            this.field.items = parameter.items;
        }

        if (this.field.value) {
            var item = this.field.items.find(o => o.value == this.field.value);
            if (item) {
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
    };

    setFieldValue(item) {
        this.field.value = item.value;
    }
}
