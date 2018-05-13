import { Characteristicable } from "./characteristicable.abstraction";
import { Fieldset } from "../fieldset.model";
import { Field } from "../field.model";

export abstract class ComponentContainer extends Characteristicable {
    constructor(data) {
        super(data);

        for (var ifieldset in data.fieldsets) {
            this.fieldsets[ifieldset] = new Fieldset(data.fieldsets[ifieldset]);
        }
    }

    angularComponentCode: string;
    description: string;
    fieldsets: any;
    headerErrors: string[];
    title: string;
    url: string;

    getAnyField(field: string): Field {
        for (var ifieldset in this.fieldsets) {
            var fieldset = this.getFieldset(ifieldset);
            var anyField = fieldset.getField(field);
            if (anyField) {
                return anyField;
            }
        }

        return null;
    }

    getFieldset(fieldset: string): Fieldset {
        if (!this.fieldsets || !this.fieldsets[fieldset]) {
            return null;
        }

        return this.fieldsets[fieldset];
    }

    validateFieldsets(response) {
        if (response.status === 400) {
            var errors = response.error;

            this.headerErrors = [];
            for (var ierror in errors) {
                if (errors[ierror].type === "HeaderErrors") {
                    this.headerErrors.push(errors[ierror].value);
                }
            }

            for (var ifieldset in this.fieldsets)
            {
                for (var ifield in this.getFieldset(ifieldset).fields) 
                {
                    for (var ierror in errors) {
                        var fieldFullNameSplit = ierror.split('.');
                        if (ifieldset === fieldFullNameSplit[0] && ifield === fieldFullNameSplit[1] && errors[ierror].type === "Field") {
                            this.getFieldset(ifieldset).getField(ifield).message = errors[ierror].value;
                        }
                    }
                }
            }
        }
    }
}
