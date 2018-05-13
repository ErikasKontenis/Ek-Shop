import { Model } from "./model.abstraction";

export abstract class Characteristicable extends Model {
    constructor(data) {
        super(data);
    }

    characteristics: any;

    getCharacteristic(characteristic: string) {
        if (!this.characteristics || !this.characteristics[characteristic]) {
            return null;
        }

        return this.characteristics[characteristic];
    }

    setCharacteristic(characteristic: string, value: any): void {
        if (!this.characteristics) {
            return;
        }

        this.characteristics[characteristic] = value;
    }
}
