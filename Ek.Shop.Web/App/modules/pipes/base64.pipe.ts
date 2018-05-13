import { PipeTransform, Pipe } from '@angular/core';
import { FileUploader } from "angular-file";

@Pipe({
    name: 'base64'
})

export class Base64Pipe implements PipeTransform {
    transform(input) {
        return new FileUploader().dataUrl(input)
            .then((src: any) => {
                return src;
            });
    }
}
