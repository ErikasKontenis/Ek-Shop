import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';

import { ComponentFactoryModule } from '../../../../modules/component-factory/component-factory.module';
import { ComponentModule } from '../../../../modules/components/component.module';
import { DirectiveModule } from '../../../../modules/directives/directive.module';
import { PipeModule } from '../../../../modules/pipes/pipe.module';

import { NavMenuLucidComponent } from './navmenu/navmenu.lucid.component';
import { FooterLucidComponent } from './footer/footer.lucid.component';
import { BreadcrumbLucidComponent } from './breadcrumb/breadcrumb.lucid.component';

@NgModule({
    declarations: [
        NavMenuLucidComponent,
        FooterLucidComponent,
        BreadcrumbLucidComponent
    ],
    exports: [
        NavMenuLucidComponent,
        FooterLucidComponent,
        BreadcrumbLucidComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        BsDropdownModule.forRoot(),
        ComponentFactoryModule,
        ComponentModule,
        DirectiveModule,
        PipeModule
    ]
})
export class ComponentLucidModule {
}
