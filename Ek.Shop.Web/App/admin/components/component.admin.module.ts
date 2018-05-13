import { NgModule, Inject, Pipe } from '@angular/core';
import { CommonModule, APP_BASE_HREF } from '@angular/common';
import { HttpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';
import { CKEditorModule } from '../../modules/ckeditor';
import { ngfModule, ngf } from "angular-file";

import { ComponentModule } from '../../modules/components/component.module';
import { DirectiveModule } from '../../modules/directives/directive.module';
import { ComponentFactoryModule } from '../../modules/component-factory/component-factory.module';
import { PipeModule } from '../..//modules/pipes/pipe.module';
import { HttpService } from '../../shared/services/http.service';
import { FileUploadService } from "../../shared/services/file-upload.service";

import { NavMenuAdminComponent } from './navmenu/navmenu.admin.component';
import { FooterAdminComponent } from './footer/footer.admin.component';
import { BreadcrumbAdminComponent } from './breadcrumb/breadcrumb.admin.component';
import { HtmlEditorAdminComponent } from './html-editor/html-editor.admin.component';
import { JsonEditorAdminComponent } from "./json-editor/json-editor.admin.component";
import { FileUploadAdminComponent } from './file-upload/file-upload.admin.component';
import { SearchboxAdminComponent } from './searchbox/searchbox.admin.component';

@NgModule({
    declarations: [
        NavMenuAdminComponent,
        FooterAdminComponent,
        BreadcrumbAdminComponent,
        HtmlEditorAdminComponent,
        JsonEditorAdminComponent,
        FileUploadAdminComponent,
        SearchboxAdminComponent
    ],
    exports: [
        NavMenuAdminComponent,
        FooterAdminComponent,
        BreadcrumbAdminComponent,
        HtmlEditorAdminComponent,
        JsonEditorAdminComponent,
        FileUploadAdminComponent,
        SearchboxAdminComponent
    ],
    providers: [
        FileUploadService
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        CKEditorModule,
        ngfModule,
        ComponentModule,
        DirectiveModule,
        ComponentFactoryModule,
        PipeModule
    ]
})
export class ComponentAdminModule {
}
