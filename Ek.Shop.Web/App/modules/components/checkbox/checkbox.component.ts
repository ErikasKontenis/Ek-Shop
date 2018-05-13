import { Component, Input, OnInit } from '@angular/core';
import { Field } from "../../../shared/models/field.model";

@Component({
    selector: 'app-checkbox',
    templateUrl: './checkbox.component.html'
})
export class CheckboxComponent implements OnInit {
    @Input() field: Field;

    ngOnInit() {
        this.field.value = this.field.value == "True" ? true : this.field.value == "False" ? false : this.field.value;
    }

    onClick() {
        this.field.isFieldValid();

        if (this.field.onClick) {
            this.field.onClick(this.field);
        }
    };

    onBlur = () => {

    };
}
