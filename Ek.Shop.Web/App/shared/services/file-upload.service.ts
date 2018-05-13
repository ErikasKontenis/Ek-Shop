import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { HttpService } from './http.service';

@Injectable()
export class FileUploadService {
    constructor(private httpService: HttpService) {

    }

    uploadFiles(files: File[]) {
        var formData = new FormData();
        files.forEach(file => {
            formData.append("file", file);
        });

        this.httpService.post("/fileUploadAdmin/uploadFiles/", formData).subscribe(response => { console.log("pavyko") })
    }
}
