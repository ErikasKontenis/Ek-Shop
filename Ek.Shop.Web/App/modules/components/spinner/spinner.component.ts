import { Component, Input, OnInit } from '@angular/core';
import { Field } from "../../../shared/models/field.model";

@Component({
    selector: 'app-spinner',
    templateUrl: './spinner.component.html'
})
export class SpinnerComponent implements OnInit {
    @Input() field: Field;

    ngOnInit() {

    }
}
