import { Component, OnInit, Inject, ViewEncapsulation } from '@angular/core';
import { ComponentFactoryService } from '../modules/component-factory/component-factory.service';
import { UserService } from '../shared/services/user.service';

@Component({
    selector: 'admin',
    templateUrl: './admin.component.html',
    styleUrls: ['./admin.component.scss'],
    encapsulation: ViewEncapsulation.None
})
export class AdminComponent implements OnInit {
    public componentFactoryData: any;

    constructor(private componentFactoryService: ComponentFactoryService,
        public userService: UserService) {

    }

    ngOnInit() {
        this.userService.updateAuth();
        this.componentFactoryService.create();
        this.componentFactoryService.componentData$.subscribe((result) => this.componentFactoryData = result);
    }
}
