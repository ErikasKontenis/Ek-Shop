import { NgModule, Inject } from '@angular/core';
import { CommonModule, APP_BASE_HREF } from '@angular/common';
import { HttpModule, Http } from '@angular/http';
import { FormsModule } from '@angular/forms';
import { CarouselModule } from 'ngx-bootstrap/carousel';
import { TabsModule } from "ngx-bootstrap/tabs";
import { ToastrModule, ToastNoAnimation, ToastNoAnimationModule } from "ngx-toastr";

import { ComponentModule } from '../../../modules/components/component.module';
import { DirectiveModule } from '../../../modules/directives/directive.module';
import { PipeModule } from '../../../modules/pipes/pipe.module';

import { ComponentFactoryModule } from '../../../modules/component-factory/component-factory.module';
import { ComponentLucidModule } from './components/component.lucid.module';
import { AppTemplateLucidComponent } from './app-template.lucid.component';
import { BasketLucidComponent } from "./containers/basket/basket.lucid.component";
import { OrderLucidComponent } from "./containers/order/order.lucid.component";
import { PageNotFoundLucidComponent } from './containers/page-not-found/page-not-found.lucid.component';
import { HomeLucidComponent } from './containers/home/home.lucid.component';
import { ProductCategoryLucidComponent } from './containers/product-category/product-category.lucid.component';
import { SubCategoryLucidComponent } from './containers/sub-category/sub-category.lucid.component';
import { TextCategoryLucidComponent } from './containers/text-category/text-category.lucid.component';
import { ProductLucidComponent } from './containers/product/product.lucid.component';
import { ProfileLucidComponent } from "./containers/profile/profile.lucid.component";
import { LoginLucidComponent } from './containers/login/login.lucid.component';
import { LogoutLucidComponent } from "./containers/logout/logout.lucid.component";
import { RegistrationLucidComponent } from './containers/registration/registration.lucid.component';

@NgModule({
    declarations: [
        AppTemplateLucidComponent,
        BasketLucidComponent,
        OrderLucidComponent,
        PageNotFoundLucidComponent,
        HomeLucidComponent,
        ProductCategoryLucidComponent,
        ProfileLucidComponent,
        SubCategoryLucidComponent,
        TextCategoryLucidComponent,
        ProductLucidComponent,
        LoginLucidComponent,
        LogoutLucidComponent,
        RegistrationLucidComponent
    ],
    entryComponents: [
        AppTemplateLucidComponent,
        BasketLucidComponent,
        OrderLucidComponent,
        PageNotFoundLucidComponent,
        HomeLucidComponent,
        ProductCategoryLucidComponent,
        ProfileLucidComponent,
        SubCategoryLucidComponent,
        TextCategoryLucidComponent,
        ProductLucidComponent,
        LoginLucidComponent,
        LogoutLucidComponent,
        RegistrationLucidComponent
    ],
    exports: [
        AppTemplateLucidComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        // TODO: MOVE CAROUSEL TO THE COMPONENTS MODULE
        CarouselModule.forRoot(),
        TabsModule.forRoot(),
        ToastNoAnimationModule,
        ToastrModule.forRoot({
            timeOut: 10000,
            positionClass: 'toast-top-right',
            toastComponent: ToastNoAnimation,
        }),
        ComponentFactoryModule,
        ComponentModule,
        DirectiveModule,
        PipeModule,
        ComponentLucidModule
    ],
    providers: [

    ]
})
export class LucidTemplateModule {
}
