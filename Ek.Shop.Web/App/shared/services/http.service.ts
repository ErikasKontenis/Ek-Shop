import { HttpClient } from '@angular/common/http';
import { ORIGIN_URL } from '@nguniversal/aspnetcore-engine/tokens';
import { Injector, Injectable, Inject, PLATFORM_ID } from '@angular/core';
import { Observable } from "rxjs/Observable";
import 'rxjs/add/observable/throw';
import { Resource } from "../models/resource.model";
import { ComponentFactoryService } from "../../modules/component-factory/component-factory.service";
import { isPlatformServer } from '@angular/common';

@Injectable()
export class HttpService {
    private isServer: boolean = isPlatformServer(this.platform_id);
    private baseUrl: string;

    constructor(private http: HttpClient, private componentFactoryService: ComponentFactoryService, @Inject(PLATFORM_ID) private platform_id, private injector: Injector) {
        this.baseUrl = this.injector.get(ORIGIN_URL);
    }

    getResources() {
        return this.get<Resource>("/application/getResources");
    }

    get<TResult = any>(url: string, data: any = null) {
        if (data) {
            return this.intercept(this.http.get<TResult>(`${this.baseUrl}/api/${url}`, { params: data }));
        }
        else {
            return this.intercept(this.http.get<TResult>(`${this.baseUrl}/api/${url}`));
        }
    }

    post<TResult = any>(url: string, data: any) {
        return this.http.post<TResult>(`${this.baseUrl}/api/${url}`, data);
    }

    intercept<TResult>(observable: Observable<TResult>): Observable<TResult> {
        return observable.catch((error) => {
            if (error.status == 401 && !this.isServer) {
                this.getResources().subscribe(result => {
                    var resource = new Resource(result);
                    this.componentFactoryService.create(resource.loginPath);
                });
            }

            return Observable.throw(error);
        });
    }
}
