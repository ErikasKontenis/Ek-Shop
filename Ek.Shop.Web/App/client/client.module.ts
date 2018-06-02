import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { BrowserModule, BrowserTransferStateModule } from '@angular/platform-browser';
import { TransferHttpCacheModule } from '@nguniversal/common';
import { RouterModule } from '@angular/router';
import { ServiceWorkerModule } from '@angular/service-worker';

import { ArrayPrototype } from '../shared/prototypes/array.prototype';
import { StringPrototype } from '../shared/prototypes/string.prototype';
import { ObjectPrototype } from "../shared/prototypes/object.prototype";

import { RouterOutletComponent } from '../modules/components/router-outlet/router-outlet.component';
import { ClientHeaderInterceptor } from "./client-header-interceptor";
import { ClientComponent } from './client.component';
import { HttpService } from '../shared/services/http.service';
import { UserService } from '../shared/services/user.service';
import { PaginationService } from '../shared/services/pagination.service';
import { LucidTemplateModule } from './templates/lucid/lucid-template.module';

@NgModule({
    declarations: [
        ClientComponent
    ],
    imports: [
        CommonModule,
        BrowserModule.withServerTransition({
            appId: 'my-app-id' // make sure this matches with your Server NgModule
        }),
        HttpClientModule,
        TransferHttpCacheModule,
        BrowserTransferStateModule,
        FormsModule,
        // TODO: Remove RouterModule from application
        RouterModule.forRoot([{ component: RouterOutletComponent, path: "**", pathMatch: "prefix" }]),
        // TODO make enabled property configurable by working environment debug = false, prod = true
        ServiceWorkerModule.register('/ngsw-worker.js', { enabled: false }),
        LucidTemplateModule
    ],
    providers: [
        HttpService,
        UserService,
        PaginationService,
        ArrayPrototype,
        StringPrototype,
        ObjectPrototype,
        {
            provide: HTTP_INTERCEPTORS,
            useClass: ClientHeaderInterceptor,
            multi: true,
        }
    ]
})
export class ClientModuleShared {
}
