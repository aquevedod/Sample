import restClient from "./RestClient";

export class Office {
    constructor(public id: string, public address: string) {}
}

//this is to receive a correct response from the api. Apply the same solution for Users
export class Response {
    constructor(public entities: Office[], public code: string, public message: string) { }
}

export class OfficeService {
    public getOffices(pattern: string) {
        return restClient.get<Office[]>("offices/getOffices", { searchPattern: pattern });
    }
}


let officeService = new OfficeService()
export default officeService