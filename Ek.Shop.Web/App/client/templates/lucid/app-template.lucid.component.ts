import { Component, OnInit, ViewEncapsulation } from '@angular/core';

import { ComponentFactoryService } from '../../../modules/component-factory/component-factory.service';

@Component({
    selector: 'app-template',
    templateUrl: './app-template.lucid.component.html',
    styleUrls: ['./app-template.lucid.component.scss'],
    encapsulation: ViewEncapsulation.None
})
export class AppTemplateLucidComponent {
    public componentFactoryData: any;

    constructor(private componentFactoryService: ComponentFactoryService)
    { }

    ngOnInit() {
        this.componentFactoryService.create();
        this.componentFactoryService.componentData$.subscribe((result) => this.componentFactoryData = result);
    }
}
