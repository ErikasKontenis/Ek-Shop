import { NgModule } from '@angular/core';
import { ServerModule } from '@angular/platform-server';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { ServerTransferStateModule } from '@angular/platform-server'; //TODO: waiting for angular5 fixes
import { PrebootModule } from 'preboot';

import { ClientModuleShared } from './client.module';
import { ClientComponent } from './client.component';

@NgModule({
    bootstrap: [ClientComponent],
    imports: [
        ServerModule,
        PrebootModule.withConfig({ appRoot: 'client' }),
        NoopAnimationsModule,
        ClientModuleShared
    ]
})
export class ClientModule {

    constructor() { }
    
}
