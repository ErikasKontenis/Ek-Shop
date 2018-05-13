import { Injectable } from '@angular/core';
import { Location } from '@angular/common';

@Injectable()
export class LocationService {
    private baseUrl: string;

    constructor(private location: Location) {
    }

    go(url: string) {
        this.location.go(url);
    }

    getUrlQueryByName(name: string, url?: string) {
        if (!url) {
            url = this.location.path();
        }

        name = name.replace(/[\[\]]/g, "\\$&");
        var regex = new RegExp("[?&]" + name + "(=([^&#]*)|&|#|$)");
        var results = regex.exec(url);

        if (!results) {
            return null;
        }

        if (!results[2]) {
            return '';
        }

        return decodeURIComponent(results[2].replace(/\+/g, " "));
    }

    updateQueryString(key: string, value: string, url?: string) {
        if (!url) url = this.location.path();
        var re = new RegExp("([?&])" + key + "=.*?(&|#|$)(.*)", "gi"),
            hash;

        if (re.test(url)) {
            if (typeof value !== 'undefined' && value !== null)
                this.go(url.replace(re, '$1' + key + "=" + value + '$2$3'));
            else {
                hash = url.split('#');
                url = hash[0].replace(re, '$1$3').replace(/(&|\?)$/, '');
                if (typeof hash[1] !== 'undefined' && hash[1] !== null)
                    url += '#' + hash[1];
                this.go(url);
            }
        }
        else {
            if (typeof value !== 'undefined' && value !== null) {
                var separator = url.indexOf('?') !== -1 ? '&' : '?';
                hash = url.split('#');
                url = hash[0] + separator + key + '=' + value;
                if (typeof hash[1] !== 'undefined' && hash[1] !== null)
                    url += '#' + hash[1];
                this.go(url);
            }
            else
                this.go(url);
        }
    }

    path(parameter?: IPathParameter) {
        var url = this.location.path();
        if (!parameter) {
            return url;
        }

        if (parameter.removeQueries) {
            return url.split('?')[0];
        }

        return url;
    }
}

interface IPathParameter {
    removeQueries: boolean;
}
