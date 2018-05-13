import { Directive, ViewContainerRef } from '@angular/core';

@Directive({
    selector: '[app-component-factory-directive]',
})
export class ComponentFactoryDirective {
    constructor(public viewContainerRef: ViewContainerRef) {

    }
}
