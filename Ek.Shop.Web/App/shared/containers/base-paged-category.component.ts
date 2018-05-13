import { OnInit, Injector } from '@angular/core';
import { Location } from '@angular/common';
import * as _ from "lodash";

import { BaseCategoryComponent } from "./base-category.component";
import { PaginationService } from "../services/pagination.service";
import { HttpService } from "../services/http.service";
import { Category } from "../../shared/models/category.model";
import { Field } from "../models/field.model";

export abstract class BasePagedCategoryComponent extends BaseCategoryComponent implements OnInit {
    constructor(public injector: Injector) {
        super(injector);
    }

    ngOnInit() {
        super.ngOnInit();
        this.attachFieldEvents();

        var paginationField = this.category.getAnyField("pagination");
        var sortingField = this.category.getAnyField("sorting");
        var pageSizeField = this.category.getAnyField("pageSize");
        var searchField = this.category.getAnyField("search");

        if (paginationField) {
            var paginationQueryValue = this.location.getUrlQueryByName(paginationField.getCharacteristic("urlQuery"));
            if (paginationQueryValue) {
                paginationField.value = paginationQueryValue;
            }
        }
        if (sortingField) {
            var sortingQueryValue = this.location.getUrlQueryByName(sortingField.getCharacteristic("urlQuery"));
            if (sortingQueryValue) {
                sortingField.value = sortingQueryValue;
            }
        }
        if (pageSizeField) {
            var pageSizeQueryValue = this.location.getUrlQueryByName(pageSizeField.getCharacteristic("urlQuery"));
            if (pageSizeQueryValue) {
                pageSizeField.value = pageSizeQueryValue;
            }
        }
        if (searchField) {
            var searchQueryValue = this.location.getUrlQueryByName(searchField.getCharacteristic("urlQuery"));
            if (searchQueryValue) {
                searchField.value = searchQueryValue;
            }
        }

        this.setPage(paginationField);
    }

    attachFieldEvents() {
        super.attachFieldEvents();
        var paginationField = this.category.getAnyField("pagination");
        if (paginationField) {
            paginationField.onClick = this.setPage.bind(this);
        }

        var sortingField = this.category.getAnyField("sorting");
        if (sortingField) {
            sortingField.onSelectClick = this.setSorting.bind(this);
        }

        var pageSizeField = this.category.getAnyField("pageSize");
        if (pageSizeField) {
            pageSizeField.onSelectClick = this.setPageSize.bind(this);
        }

        var searchField = this.category.getAnyField("search");
        if (searchField) {
            searchField.onClick = this.setSearch.bind(this);
        }
    }

    getPagedListCommand() {
        var pagedListCommand: any = { };

        var paginationField = this.category.getAnyField("pagination");
        if (paginationField && paginationField.value) {
            pagedListCommand.pageIndex = paginationField.value
        }

        var sortingField = this.category.getAnyField("sorting");
        if (sortingField && sortingField.value) {
            pagedListCommand.sorting = sortingField.value;
        }

        var pageSizeField = this.category.getAnyField("pageSize");
        if (pageSizeField && pageSizeField.value > 0) {
            pagedListCommand.pageSize = pageSizeField.value;
        }
        else {
            pagedListCommand.pageSize = 24;
        }

        var searchField = this.category.getAnyField("search");
        if (searchField && searchField.value) {
            pagedListCommand.search = searchField.value;
        }

        return pagedListCommand;
    }

    abstract setPage(field: Field);

    setSorting(field: Field, item: any) {
        var paginationField = this.category.getAnyField("pagination");
        this.setPage(paginationField);
    }

    setPageSize(field: Field, item: any) {
        var paginationField = this.category.getAnyField("pagination");
        this.setPage(paginationField);
    }

    setSearch(field: Field, item: any) {
        var paginationField = this.category.getAnyField("pagination");
        this.setPage(paginationField);
    }
}
