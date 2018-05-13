declare global {
    interface Array<T> {
        first(): T
        last(): T
        orderBy(propertyExpression: (item: T) => any): T[]
        orderByDescending(propertyExpression: (item: T) => any): T[]
        orderByMany(propertyExpressions: [(item: T) => any]): T[]
        orderByManyDescending(propertyExpressions: [(item: T) => any]): T[]
        remove(item: T): boolean
        add(item: T): void
        addRange(items: T[]): void
        removeRange(items: T[]): void
        chunkArray(chunkSize: number): T[]
    }
}

if (!Array.prototype.first) {
    Array.prototype.first = function () {
        return this[0];
    }
}

if (!Array.prototype.last) {
    Array.prototype.last = function () {
        if (this.length)
            return this[this.length - 1];

        return this[0];
    }
}

if (!Array.prototype.remove) {
    Array.prototype.remove = function (item: any): boolean {
        let index = (<Array<any>>this).indexOf(item);
        if (index >= 0) {
            (<Array<any>>this).splice(index, 1);
            return true;
        }
        return false;
    }
}

if (!Array.prototype.removeRange) {
    Array.prototype.removeRange = function (items: any[]): void {
        for (var i = 0; i < items.length; i++) {
            (<Array<any>>this).remove(items[i]);
        }
    }
}

if (!Array.prototype.add) {
    Array.prototype.add = function (item: any): void {
        (<Array<any>>this).push(item);
    }
}

if (!Array.prototype.addRange) {
    Array.prototype.addRange = function (items: any[]): void {
        for (var i = 0; i < items.length; i++) {
            (<Array<any>>this).push(items[i]);
        }
    }
}

if (!Array.prototype.orderBy) {
    Array.prototype.orderBy = function (propertyExpression: (item: any) => any) {
        let result = [];
        var compareFunction = (item1: any, item2: any): number => {
            var result = parseInt(propertyExpression(item1));
            if (isNaN(result)) {
                if (propertyExpression(item1) > propertyExpression(item2)) return -1;
                if (propertyExpression(item2) > propertyExpression(item1)) return 1;
                return 0;
            }
            else {
                if (propertyExpression(item1) > propertyExpression(item2)) return 1;
                if (propertyExpression(item2) > propertyExpression(item1)) return -1;
                return 0;
            }
        }
        for (var i = 0; i < (<Array<any>>this).length; i++) {
            return (<Array<any>>this).sort(compareFunction);

        }
        return result;
    }
}



if (!Array.prototype.orderByDescending) {
    Array.prototype.orderByDescending = function (propertyExpression: (item: any) => any) {
        let result = [];
        var compareFunction = (item1: any, item2: any): number => {
            var result = parseInt(propertyExpression(item1));
            if (isNaN(result)) {
                if (propertyExpression(item1) > propertyExpression(item2)) return 1;
                if (propertyExpression(item2) > propertyExpression(item1)) return -1;
                return 0;
            }
            else {
                if (propertyExpression(item1) > propertyExpression(item2)) return -1;
                if (propertyExpression(item2) > propertyExpression(item1)) return 1;
                return 0;
            }
        }
        for (var i = 0; i < (<Array<any>>this).length; i++) {
            return (<Array<any>>this).sort(compareFunction);
        }
        return result;
    }
}

if (!Array.prototype.orderByMany) {
    Array.prototype.orderByMany = function (propertyExpressions: [(item: any) => any]) {
        let result = [];
        var compareFunction = (item1: any, item2: any): number => {
            for (var i = 0; i < propertyExpressions.length; i++) {
                let propertyExpression = propertyExpressions[i];
                if (propertyExpression(item1) > propertyExpression(item2)) return -1;
                if (propertyExpression(item2) > propertyExpression(item1)) return 1;
            }
            return 0;
        }
        for (var i = 0; i < (<Array<any>>this).length; i++) {
            return (<Array<any>>this).sort(compareFunction);
        }
        return result;
    }
}

if (!Array.prototype.orderByManyDescending) {
    Array.prototype.orderByManyDescending = function (propertyExpressions: [(item: any) => any]) {
        let result = [];
        var compareFunction = (item1: any, item2: any): number => {
            for (var i = 0; i < propertyExpressions.length; i++) {
                let propertyExpression = propertyExpressions[i];
                if (propertyExpression(item1) > propertyExpression(item2)) return 1;
                if (propertyExpression(item2) > propertyExpression(item1)) return -1;
            }
            return 0;
        }
        for (var i = 0; i < (<Array<any>>this).length; i++) {
            return (<Array<any>>this).sort(compareFunction);
        }
        return result;
    }
}

if (!Array.prototype.chunkArray) {
    Array.prototype.chunkArray = function (chunkSize: number) {
        if (chunkSize < 1) chunkSize = 1;

        var results = [];
        if (!(<Array<any>>this)) {
            return results;
        }

        while ((<Array<any>>this).length) {
            results.push((<Array<any>>this).splice(0, Math.trunc(chunkSize)));
        }

        return results;
    }
}

export class ArrayPrototype {

}
