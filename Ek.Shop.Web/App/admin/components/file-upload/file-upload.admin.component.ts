import { Component, OnInit, Input } from '@angular/core'
import { Fieldset } from "../../../shared/models/fieldset.model";
import { Image } from "../../../shared/models/image.model";

@Component({
    selector: 'file-upload-admin',
    templateUrl: './file-upload.admin.component.html'
})
export class FileUploadAdminComponent implements OnInit {
    @Input()
    images: Image[];

    newFiles: File[];
    constructor() { }

    ngOnInit() {
        console.log(this.images);
    }

    onFileUpload() {
        this.newFiles.forEach(item => {
            var image = new Image(null);
            image.file = item;
            image.imageSizeTypeId = 1;
            image.url = item.name;
            this.images.push(image);
        });

        this.newFiles = [];
    }
}
