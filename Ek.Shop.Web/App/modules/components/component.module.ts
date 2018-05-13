import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { NgHttpLoaderModule } from 'ng-http-loader/ng-http-loader.module';
import { ConfirmationPopoverModule } from 'angular-confirmation-popover';

import { PipeModule } from '../pipes/pipe.module';
import { DirectiveModule } from '../directives/directive.module';
import { ComponentFactoryModule } from '../component-factory/component-factory.module';
import { FieldComponent } from './field/field.component';
import { DropdownComponent } from './dropdown/dropdown.component';
import { ButtonComponent } from './button/button.component';
import { CheckboxComponent } from './checkbox/checkbox.component';
import { PaginationComponent } from './pagination/pagination.component';
import { ClassifierTextboxComponent } from './classifier-textbox/classifier-textbox.component';
import { TextComponent } from './text/text.component';
import { TextboxComponent } from './textbox/textbox.component';
import { IncreasingTextboxComponent } from './increasing-textbox/increasing-textbox.component';
import { RadioComponent } from "./radio/radio.component";
import { RouterOutletComponent } from './router-outlet/router-outlet.component';
import { SpinnerComponent } from './spinner/spinner.component';
import { LocationService } from "../../shared/services/location.service";

@NgModule({
    declarations: [
        FieldComponent,
        DropdownComponent,
        ButtonComponent,
        CheckboxComponent,
        PaginationComponent,
        ClassifierTextboxComponent,
        TextComponent,
        TextboxComponent,
        IncreasingTextboxComponent,
        RadioComponent,
        RouterOutletComponent,
        SpinnerComponent
    ],
    exports: [
        FieldComponent,
        DropdownComponent,
        ButtonComponent,
        CheckboxComponent,
        PaginationComponent,
        ClassifierTextboxComponent,
        TextComponent,
        TextboxComponent,
        IncreasingTextboxComponent,
        RadioComponent,
        RouterOutletComponent,
        SpinnerComponent
    ],
    imports: [
        CommonModule,
        HttpClientModule,
        NgHttpLoaderModule,
        FormsModule,
        BsDropdownModule.forRoot(),
        ConfirmationPopoverModule.forRoot({
            confirmButtonType: 'danger'
        }),
        PipeModule,
        DirectiveModule,
        ComponentFactoryModule
    ],
    providers: [
        LocationService
    ]
})
export class ComponentModule {
}
