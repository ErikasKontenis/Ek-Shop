import { Injector } from '@angular/core';
import { LocationService } from "../services/location.service";

export abstract class BaseComponent {
    readonly location: LocationService;

    constructor(public injector: Injector) {
        this.location = injector.get(LocationService);
    }
}
