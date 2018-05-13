import { Component, Input, OnInit, ViewChild, ComponentFactoryResolver, OnDestroy, ComponentRef, OnChanges, SimpleChanges, Type, HostListener } from '@angular/core';
import { ComponentFactoryDirective } from "./component-factory.directive";

import { ComponentFactoryService } from "./component-factory.service";

@Component({
    selector: 'app-component-factory',
    templateUrl: './component-factory.component.html'
})

export class ComponentFactoryComponent implements OnInit, OnChanges, OnDestroy  {
    @Input() data: any;
    @ViewChild(ComponentFactoryDirective) componentFactoryDirective: ComponentFactoryDirective;
    
    constructor(private componentFactoryResolver: ComponentFactoryResolver, private componentFactoryService: ComponentFactoryService) {
        
    }

    @HostListener('window:popstate', ['$event'])
    onPopState(event) {
        this.componentFactoryService.create();
    }

    ngOnInit() {
        this.renderComponents();
    }

    private componentRef: ComponentRef<any> = null;

    ngOnChanges(changes: SimpleChanges) {
        this.renderComponents();
    }

    // https://stackoverflow.com/questions/40115072/how-to-load-component-dynamically-using-component-name-in-angular2
    renderComponents() {
        if (this.data) {
            var factories = Array.from(this.componentFactoryResolver['_factories'].keys());
            var component = <Type<any>>factories.find((x: any) => x.componentName === this.data.angularComponentCode);
            if (component) {
                let componentFactory = this.componentFactoryResolver.resolveComponentFactory(component);
                let viewContainerRef = this.componentFactoryDirective.viewContainerRef;
                viewContainerRef.clear();
                this.componentRef = viewContainerRef.createComponent(componentFactory);

                (<IComponentFactory>this.componentRef.instance).componentFactoryData = this.data;
                this.componentRef.changeDetectorRef.detectChanges();
            }
            else {
                this.ngOnDestroy();
            }
        }
    }

    ngOnDestroy(): void {
        if (this.componentRef) {
            this.componentRef.changeDetectorRef.detach();
            this.componentRef.destroy();
        }
    }
}
