import { Model } from "./model.abstraction";

export abstract class Classifier extends Model {
    constructor(data) {
        super(data);
    }

    text: string;
    value: any;
}
