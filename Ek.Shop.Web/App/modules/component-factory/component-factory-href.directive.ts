import { Directive, Input } from '@angular/core';
import { ComponentFactoryService } from "./component-factory.service";

@Directive({
    selector: '[href]',
    host: {
        '(click)': 'onClick($event)',
        '[href]': 'href'
    }
})
export class ComponentFactoryHrefDirective {
    constructor(private componentFactoryService: ComponentFactoryService)
    { }

    @Input() href;

    onClick(event) {
        this.componentFactoryService.create(this.href);
        event.preventDefault();
    }
}
