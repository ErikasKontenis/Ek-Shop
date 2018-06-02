import { NgModule } from '@angular/core';
import { BrowserTransferStateModule } from '@angular/platform-browser'; //TODO: waiting for angular5 fixes
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ORIGIN_URL } from '@nguniversal/aspnetcore-engine/tokens';
import { PrebootModule } from 'preboot';

import { AdminModuleShared } from './admin.module';
import { AdminComponent } from './admin.component';

export function getOriginUrl() {
    return window.location.origin;
}

@NgModule({
    bootstrap: [AdminComponent],
    imports: [
        PrebootModule.withConfig({ appRoot: 'admin' }),
        BrowserAnimationsModule,

        AdminModuleShared
    ],
    providers: [
        {
            provide: ORIGIN_URL,
            useFactory: (getOriginUrl)
        }
    ]
})
export class AdminModule {
}
