import { Component, Input, OnInit } from '@angular/core';
import { Field } from "../../../shared/models/field.model";

@Component({
    selector: 'app-text',
    templateUrl: './text.component.html'
})
export class TextComponent implements OnInit {
    @Input() field: Field;

    ngOnInit() {

    }
}
