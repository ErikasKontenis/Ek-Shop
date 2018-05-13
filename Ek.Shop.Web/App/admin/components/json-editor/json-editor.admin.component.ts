import { Component, Input, OnInit, OnDestroy, ViewChild } from '@angular/core';

import { Field } from "../../../shared/models/field.model";

@Component({
    selector: 'json-editor-admin',
    templateUrl: './json-editor.admin.component.html'
})
export class JsonEditorAdminComponent implements OnInit {
    constructor() { }

    @Input() field: Field;

    ngOnInit() {

    }
}
