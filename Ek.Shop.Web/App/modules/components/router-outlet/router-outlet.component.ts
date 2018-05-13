// Workaround of the week! Add this to router routes with empty html to GTFO 
import { Component } from '@angular/core';

@Component({
    selector: 'app-router-outlet',
    template: ``
})
export class RouterOutletComponent {

}
