import { Component, Input, OnInit } from '@angular/core';
import { Field } from "../../../shared/models/field.model";

@Component({
    selector: 'app-increasing-textbox',
    templateUrl: './increasing-textbox.component.html'
})
export class IncreasingTextboxComponent implements OnInit {
    @Input() field: Field;

    ngOnInit() {

    }

    onBlur = () => {
        this.isFieldValid(this.field.value);
    };

    onMinusClick = () => {
        if (this.isFieldValid(this.field.value - 1)) {
            this.field.value--;
        }
    };

    onPlusClick = () => {
        if (this.isFieldValid(this.field.value + 1)) {
            this.field.value++;
        }
    };

    isFieldValid = (value: number): boolean => {
        if (value < this.field.getCharacteristic("validateMinValue")) {
            this.field.message = this.field.getCharacteristic("validateMinValueMessage") as string;
            return false;
        }
        else if (value > this.field.getCharacteristic("validateMaxValue")) {
            this.field.message = this.field.getCharacteristic("validateMaxValueMessage") as string;
            return false;
        }

        this.field.message = null;
        return true;
    };
}
