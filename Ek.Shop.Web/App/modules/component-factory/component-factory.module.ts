import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';

import { ComponentFactoryComponent } from './component-factory.component';
import { ComponentFactoryDirective } from './component-factory.directive';
import { ComponentFactoryHrefDirective } from './component-factory-href.directive';
import { ComponentFactoryService } from "./component-factory.service";
import { HttpService } from '../../shared/services/http.service';

@NgModule({
    declarations: [
        ComponentFactoryComponent,
        ComponentFactoryDirective,
        ComponentFactoryHrefDirective
    ],
    exports: [
        ComponentFactoryComponent,
        ComponentFactoryDirective,
        ComponentFactoryHrefDirective
    ],
    imports: [
        CommonModule,
        HttpClientModule
    ],
    providers: [
        ComponentFactoryService,
        HttpService
    ]
})
export class ComponentFactoryModule {
}
