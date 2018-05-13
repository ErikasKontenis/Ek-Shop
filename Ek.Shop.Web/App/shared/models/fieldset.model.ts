import { Characteristicable } from "./abstractions/characteristicable.abstraction";
import { Field } from "./field.model";

export class Fieldset extends Characteristicable {
    constructor(data) {
        super(data);

        for (var ifield in data.fields) {
            this.fields[ifield] = new Field(data.fields[ifield]);
            this.fields[ifield].id = ifield;
        }
    }

    fields: any;

    getField(field: string): Field {
        if (!this.fields || !this.fields[field]) {
            return null;
        }

        return this.fields[field];
    }
}
