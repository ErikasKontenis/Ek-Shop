import { Model } from "./abstractions/model.abstraction";

export class User extends Model {
    constructor(data) {
        super(data);
    }

    address: string;
    city: string;
    companyCode: string;
    companyName: string;
    companyVat: string;
    created: Date;
    email: string;
    isBuyerCompany: boolean;
    lastLogin: Date;
    lastName: string;
    name: string;
    phoneNumber: string;
    postCode: number;
    roles: string[];

    isRole(roleName: string) {
        if (this.roles.find(o => o === roleName)) {
            return true;
        }

        return false;
    }

    getFullName() {
        return this.name + " " + this.lastName;
    }
}
