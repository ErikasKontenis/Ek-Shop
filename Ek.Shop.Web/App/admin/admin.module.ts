import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { ToastrModule, ToastNoAnimation, ToastNoAnimationModule } from "ngx-toastr";

import { ComponentModule } from '../modules/components/component.module';
import { DirectiveModule } from '../modules/directives/directive.module';
import { PipeModule } from '../modules/pipes/pipe.module';
import { ComponentAdminModule } from './components/component.admin.module';
import { ComponentFactoryModule } from '../modules/component-factory/component-factory.module';
import { RouterOutletComponent } from '../modules/components/router-outlet/router-outlet.component';

import { ArrayPrototype } from '../shared/prototypes/array.prototype';
import { StringPrototype } from '../shared/prototypes/string.prototype';
import { ObjectPrototype } from "../shared/prototypes/object.prototype";

import { AdminHeaderInterceptor } from "./admin-header-interceptor";
import { AdminComponent } from './admin.component';
import { PageNotFoundAdminComponent } from './containers/page-not-found/page-not-found.admin.component';
import { DashboardAdminComponent } from './containers/dashboard/dashboard.admin.component';
import { ListCategoryAdminComponent } from './containers/category/list-category.admin.component';
import { ListOrderAdminComponent } from "./containers/orders/list-order.admin.component";
import { ListProductAdminComponent } from './containers/product/list-product.admin.component';
import { EditCategoryAdminComponent } from './containers/category/edit-category.admin.component';
import { EditOrderAdminComponent } from "./containers/orders/edit-order.admin.component";
import { EditProductAdminComponent } from './containers/product/edit-product.admin.component';
import { LoginAdminComponent } from './containers/login/login.admin.component';
import { LogoutAdminComponent } from "./containers/logout/logout.admin.component";

import { HttpService } from '../shared/services/http.service';
import { PaginationService } from '../shared/services/pagination.service';
import { UserService } from '../shared/services/user.service';

@NgModule({
    declarations: [
        AdminComponent,
        PageNotFoundAdminComponent,
        DashboardAdminComponent,
        ListCategoryAdminComponent,
        ListOrderAdminComponent,
        ListProductAdminComponent,
        EditCategoryAdminComponent,
        EditOrderAdminComponent,
        EditProductAdminComponent,
        LoginAdminComponent,
        LogoutAdminComponent
    ],
    entryComponents: [
        PageNotFoundAdminComponent,
        DashboardAdminComponent,
        ListCategoryAdminComponent,
        ListOrderAdminComponent,
        ListProductAdminComponent,
        EditCategoryAdminComponent,
        EditOrderAdminComponent,
        EditProductAdminComponent,
        LoginAdminComponent,
        LogoutAdminComponent
    ],
    imports: [
        CommonModule,
        HttpClientModule,
        FormsModule,
        // TODO: Remove RouterModule from application
        RouterModule.forRoot([{ component: RouterOutletComponent, path: "**", pathMatch: "prefix" }]),
        TabsModule.forRoot(),
        ToastNoAnimationModule,
        ToastrModule.forRoot({
            timeOut: 10000,
            positionClass: 'toast-top-right',
            toastComponent: ToastNoAnimation,
        }),
        ComponentModule,
        DirectiveModule,
        PipeModule,
        ComponentAdminModule,
        ComponentFactoryModule
    ],
    providers: [
        HttpService,
        PaginationService,
        ArrayPrototype,
        StringPrototype,
        ObjectPrototype,
        UserService,
        {
            provide: HTTP_INTERCEPTORS,
            useClass: AdminHeaderInterceptor,
            multi: true,
        }
    ]
})
export class AdminModuleShared {
}
