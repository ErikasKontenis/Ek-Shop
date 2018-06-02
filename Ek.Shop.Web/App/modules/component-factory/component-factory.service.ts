import { Injectable, Injector } from '@angular/core';
import { Subject } from 'rxjs/Subject';
import { Location } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Meta, Title } from '@angular/platform-browser';
import { ORIGIN_URL } from '@nguniversal/aspnetcore-engine/tokens';

@Injectable()
export class ComponentFactoryService {
    private baseUrl: string;

    constructor(private httpClient: HttpClient,
        private location: Location,
        private meta: Meta,
        private title: Title,
        private injector: Injector) {
        this.baseUrl = this.injector.get(ORIGIN_URL);
    }

    private componentData = new Subject<string[]>();
    componentData$ = this.componentData.asObservable();

    updateComponementData(data) {
        // Pro Hint: Never leave meta tags null since then preloading throws exception
        this.meta.updateTag({ property: "description", content: data.description || data.characteristics["name"] || "" });
        this.meta.updateTag({ property: "statusCode", content: "200" });
        this.title.setTitle(data.title || data.characteristics["name"] || "");
        this.componentData.next(data);
    }

    create(url?: string) {
        if (url) {
            this.location.go(url);
        }
        
        this.httpClient.get(this.baseUrl + "/api/componentFactory/create", { params: { url: (url || this.location.path()) } }).subscribe(result => {
            this.updateComponementData(result);
        });
    }
}
