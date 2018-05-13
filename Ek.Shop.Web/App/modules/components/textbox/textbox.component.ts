import { Component, Input, OnInit } from '@angular/core';
import { Field } from "../../../shared/models/field.model";

@Component({
    selector: 'app-textbox',
    templateUrl: './textbox.component.html'
})
export class TextboxComponent implements OnInit {
    @Input() field: Field;

    ngOnInit() {

    }

    onBlur = () => {
        this.field.isFieldValid();

        if (this.field.onBlur) {
            this.field.onBlur();
        }
    };
}
