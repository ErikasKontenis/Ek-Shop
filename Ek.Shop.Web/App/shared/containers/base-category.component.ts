import { OnInit, Injector } from '@angular/core';
import { Location } from '@angular/common';
import * as _ from "lodash";

import { BaseComponent } from "./base.component";
import { PaginationService } from "../services/pagination.service";
import { HttpService } from "../services/http.service";
import { Category } from "../../shared/models/category.model";
import { Field } from "../models/field.model";

export abstract class BaseCategoryComponent extends BaseComponent implements OnInit {
    private componentFactoryData: any;
    category: Category;
    readonly paginationService: PaginationService;
    readonly httpService: HttpService;

    constructor(public injector: Injector) {
        super(injector);
        this.paginationService = injector.get(PaginationService);
        this.httpService = injector.get(HttpService);
    }

    ngOnInit() {
        this.category = new Category(this.componentFactoryData);
        this.attachFieldEvents();
    }

    attachFieldEvents() {
        // In future might be necessary
    }
}
