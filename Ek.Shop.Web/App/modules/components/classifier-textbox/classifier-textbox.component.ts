import { Component, Input, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Subject } from 'rxjs/Subject';
import { HttpService } from '../../../shared/services/http.service';
import { Field } from "../../../shared/models/field.model";

@Component({
    selector: 'app-classifier-textbox',
    templateUrl: './classifier-textbox.component.html',
    styleUrls: ['./classifier-textbox.component.scss'],
    providers: [HttpService]
})
export class ClassifierTextboxComponent implements OnInit {
    @Input() field: Field;

    public items: Observable<any[]>;
    public isDropdownOpen: boolean;
    private searchTerms = new Subject<string>();

    constructor(private httpService: HttpService) {
    }

    ngOnInit() {
        this.items = this.searchTerms
            .debounceTime(300)
            .distinctUntilChanged()
            .switchMap(term => term
                ? this.httpService.get<any[]>(this.field.getCharacteristic("apiUrl"), { term: term, characteristic: this.field.getCharacteristic("characteristic") })
                : Observable.of<any[]>([]))
            .catch(error => {
                console.log(error);
                return Observable.of<any[]>([]);
            });
    }

    onKeyup(value: string) {
        this.isDropdownOpen = true;
        this.searchTerms.next(value);

        if (this.field.onKeyup) {
            this.field.onKeyup(this.field);
        }
    }

    onSelectClick = (item) => {
        this.isDropdownOpen = false;
        this.field.value = item.text;

        if (this.field.onSelectClick) {
            this.field.onSelectClick(this.field, item);
        }
    };

    onBlur = () => {
        this.isDropdownOpen = false;
        this.isFieldValid(this.field.value);
    };

    isFieldValid = (value: number): boolean => {
        if (value < this.field.getCharacteristic("validateMinValue")) {
            this.field.message = this.field.getCharacteristic("validateMinValueMessage") as string;
            return false;
        }
        else if (value > this.field.getCharacteristic("validateMaxValue")) {
            this.field.message = this.field.getCharacteristic("validateMaxValueMessage") as string;
            return false;
        }

        this.field.message = null;
        return true;
    };
}
