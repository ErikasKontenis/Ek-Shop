import { Component, Input, OnInit, OnDestroy } from '@angular/core';
import { Field } from "../../../shared/models/field.model";
declare var CKEDITOR: any;

@Component({
    selector: 'html-editor-admin',
    templateUrl: './html-editor.admin.component.html'
})
export class HtmlEditorAdminComponent implements OnInit, OnDestroy {
    constructor() { }

    @Input() field: Field;

    public htmlEditorConfig = {
        removeButtons: 'Save,Preview,About,Form,Checkbox,Radio,TextField,Textarea,Select,Button,ImageButton,HiddenField'
    }

    ngOnInit() {

    }

    ngOnDestroy() {
        // TODO: sitai neveikia nes dar pries OnDestroy metoda CKEDITOR.instance buna sunaikinta su warningu ir sita metoda reiketu paleisti pvz factory.create callback'e ar panasiai kur dar bus pries komponento sunaikinima
        for (var instance of CKEDITOR.instances) {
            //console.log(instance);
            CKEDITOR.instances[instance].destroy();
        }
    }
}
