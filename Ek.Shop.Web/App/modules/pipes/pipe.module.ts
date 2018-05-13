import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpModule } from '@angular/http';

import { CallbackPipe } from './callback.pipe';
import { KeysPipe } from './keys.pipe';
import { NavMenuPipe } from './navmenu.pipe';
import { Base64Pipe } from './base64.pipe';

@NgModule({
    declarations: [
        CallbackPipe,
        KeysPipe,
        NavMenuPipe,
        Base64Pipe
    ],
    exports: [
        CallbackPipe,
        KeysPipe,
        NavMenuPipe,
        Base64Pipe
    ],
    imports: [
        CommonModule,
        HttpModule
    ]
})
export class PipeModule {
}
