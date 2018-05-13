import { Component, ViewEncapsulation, OnInit, HostListener } from '@angular/core';
import { UserService } from "../shared/services/user.service";

@Component({
    selector: 'client',
    templateUrl: './client.component.html',
    styleUrls: ['./client.component.scss'],
    encapsulation: ViewEncapsulation.None
})
export class ClientComponent {
    constructor(public userService: UserService) {
        this.userService.updateAuth();
    }
}

