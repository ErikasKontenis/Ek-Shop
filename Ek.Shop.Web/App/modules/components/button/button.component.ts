import { Component, Input, OnInit } from '@angular/core';
import { Field } from "../../../shared/models/field.model";
import { ComponentFactoryService } from "../../component-factory/component-factory.service";

@Component({
    selector: 'app-button',
    templateUrl: './button.component.html'
})
export class ButtonComponent implements OnInit {
    @Input() field: Field;

    constructor(private componentFactoryService: ComponentFactoryService)
    { }

    ngOnInit() {

    }

    onClick() {
        if (this.field.getCharacteristic("isYesNoPopoverRequired")) {
            return;
        }

        this.onSuccessClick();
    };

    onSuccessClick() {
        if (this.field.getCharacteristic("url")) {
            this.componentFactoryService.create(this.field.getCharacteristic("url"));
        }

        if (this.field.onClick) {
            this.field.onClick(this.field);
        }
    }
}
