export class PagedList<T> {
    constructor(data) {
        Object.assign(this, data);
    }

    items: T[];

    pageIndex: number = 0;

    pageSize: number = 0;

    totalCount: number = 0;

    totalPages: number = 0;
}
