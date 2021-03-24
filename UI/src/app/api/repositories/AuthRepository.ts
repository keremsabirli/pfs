import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import LoginModel from "src/app/shared/models/requestmodels/login.model";
import RegisterModel from "src/app/shared/models/requestmodels/register.model";
import { BaseRepository } from "./BaseRepository";

@Injectable()
export class AuthRepository extends BaseRepository {
    constructor(
        httpClient: HttpClient
    ) {
        super(httpClient, 'Auth');
    }

    public login(loginModel: LoginModel) {
        return this.post(this.baseUri + 'Login', loginModel);
    }

    public register(registerModel: RegisterModel) {
        return this.post(this.baseUri + 'Register', registerModel);
    }
}
