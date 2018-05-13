import { Model } from "./abstractions/model.abstraction";

export class Resource extends Model {
    constructor(data) {
        super(data);
    }

    loginPath: string;
    loginRedirect: string;
}
