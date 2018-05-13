import { Characteristicable } from "./abstractions/characteristicable.abstraction";

export class Field extends Characteristicable {
    constructor(data) {
        super(data);
    }

    customs: any = {};
    message: string;
    onBlur: () => void;
    onClick: (field: Field) => void;
    onKeyup: (field: Field) => void;
    onSelectClick: (field: Field, item) => void;
    id: string;
    items: Array<any>;
    value: any;

    getLabel() {
        var label = this.getCharacteristic("label");
        var isRequired = this.getCharacteristic("isRequired");
        if (isRequired) {
            label += "*";
        }

        return label;
    }

    isFieldValid(): boolean {
        if (this.getCharacteristic("isRequired") && !this.value) {
            this.message = this.getCharacteristic("isRequiredMessage");
            return false;
        }
        else if (this.value < this.getCharacteristic("validateMinValue")) {
            this.message = this.getCharacteristic("validateMinValueMessage");
            return false;
        }
        else if (this.value > this.getCharacteristic("validateMaxValue")) {
            this.message = this.getCharacteristic("validateMaxValueMessage");
            return false;
        }
        else if (!(new RegExp(this.getCharacteristic("validateRegexValue")).test(this.value))) {
            
            this.message = this.getCharacteristic("validateRegexValueMessage");
            return false;
        }

        this.message = null;
        return true;
    }
}
