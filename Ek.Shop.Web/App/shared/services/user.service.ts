import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { HttpService } from './http.service';
import { User } from "../models/user.model";

@Injectable()
export class UserService {
    user: User;

    constructor(private httpService: HttpService) {

    }

    updateAuth() {
        this.httpService.get<User>("/authentication/authenticate").subscribe(result => {
            this.user = new User(result);
        }, result => {
            this.user = null;
        });
    }
}
