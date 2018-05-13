import { Component, Input, OnInit } from '@angular/core';
import { Field } from "../../../shared/models/field.model";

@Component({
    selector: 'app-field',
    templateUrl: './field.component.html'
})
export class FieldComponent implements OnInit {
    constructor() { }
    @Input() field: Field;

    fieldText: string;

    ngOnInit() {
        if (!this.field) return;

        if (this.field.getCharacteristic("parameter")) {
            if (typeof this.field.getCharacteristic("parameter") !== "string") return;

            var parameter = JSON.parse(this.field.getCharacteristic("parameter"));
            this.field.setCharacteristic("parameter", parameter);
        }
    }
}
