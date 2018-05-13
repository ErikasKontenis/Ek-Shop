import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ORIGIN_URL, REQUEST } from '@nguniversal/aspnetcore-engine';
import { BrowserTransferStateModule } from '@angular/platform-browser'; //TODO: waiting for angular5 fixes
import { BrowserPrebootModule } from 'preboot/browser';

import { ClientModuleShared } from './client.module';
import { ClientComponent } from './client.component';

export function getOriginUrl() {
  return window.location.origin;
}

export function getRequest() {
  // the Request object only lives on the server
  return { cookie: document.cookie };
}

@NgModule({
    bootstrap: [ClientComponent],
    imports: [
        BrowserPrebootModule.replayEvents(),
        BrowserAnimationsModule,
        ClientModuleShared
    ],
    providers: [
        {
            provide: ORIGIN_URL,
            useFactory: (getOriginUrl)
        }, {
            provide: REQUEST,
            useFactory: (getRequest)
        }
    ]
})
export class ClientModule {
}
