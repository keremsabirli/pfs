import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { environment } from "src/environments/environment";

@Injectable()
export class BaseRepository {
    constructor(
        public httpClient: HttpClient,
        public controller: string,
        ) {
    }
    protected baseUri = `${window.location.hostname}/api/${this.controller}/`;

    protected get<T>(url: string, headers?: HttpHeaders) {
        return this.httpClient.get(url, {headers: headers});
    }
    protected post<T>(url: string, body?: any, headers?: HttpHeaders) {
        return this.httpClient.post(url, body, {headers: headers});
    }
    protected put<T>(url: string, body?: any, headers?: HttpHeaders) {
        return this.httpClient.put(url, body, {headers: headers});
    }
    protected delete<T>(url: string, headers?: HttpHeaders) {
        return this.httpClient.delete(url, {headers: headers});
    }
}
