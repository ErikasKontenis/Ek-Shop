import { NgModule } from '@angular/core';
import { ServerModule } from '@angular/platform-server';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { ServerTransferStateModule } from '@angular/platform-server'; //TODO: waiting for angular5 fixes
import { ServerPrebootModule } from 'preboot/server';

import { ClientModuleShared } from './client.module';
import { ClientComponent } from './client.component';

@NgModule({
    bootstrap: [ClientComponent],
    imports: [
        ServerModule,
        ServerPrebootModule.recordEvents({ appRoot: 'client' }),
        NoopAnimationsModule,
        ClientModuleShared
    ]
})
export class ClientModule {

    constructor() { }
    
}
