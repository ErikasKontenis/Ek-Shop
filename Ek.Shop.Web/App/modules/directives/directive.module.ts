import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';
import { InitDirective } from "./init.directive";

@NgModule({
    declarations: [
        InitDirective
    ],
    exports: [
        InitDirective
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule
    ]
})
export class DirectiveModule {
}
