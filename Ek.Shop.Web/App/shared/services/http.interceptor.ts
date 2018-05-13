//import { Injectable } from '@angular/core';

//import { HttpService } from '../../shared/services/http.service';
////import { ComponentFactoryService } from "../../modules/component-factory/component-factory.service";
//import { Resource } from "../models/resource.model";
//import { Observable } from "rxjs/Observable";

//@Injectable()
//export class HttpInterceptor {
//    constructor(private httpService: HttpService,
//        )
//    { }

//    intercept<TResult>(observable: Observable<TResult>): Observable<TResult> {
//        return observable.catch((error) => {
//            if (error.status == 401) {
//                this.httpService.getResources().subscribe(result => {
//                    var resource = new Resource(result);
//                    console.log(resource)
//                    //this.componentFactoryService.create(resource.adminLoginPath);
//                });
//            }

//            return Observable.throw(error);
//        });
//    }
//}
