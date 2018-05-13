import { Characteristicable } from "./abstractions/characteristicable.abstraction";

export class Image extends Characteristicable {
    constructor(data) {
        super(data);
    }

    file: File;
    imageSizeType: string;
    imageSizeTypeId: number;
    url: string;
}
