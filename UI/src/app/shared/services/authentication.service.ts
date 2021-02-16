import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { AuthRepository } from 'src/app/api/repositories/AuthRepository';
import LoginModel from '../models/requestmodels/login.model';
import RegisterModel from '../models/requestmodels/register.model';

@Injectable({providedIn: 'root'})
export class AuthenticationService {
    private isAuthenticatedSource = new BehaviorSubject<boolean>(false);

    isAuthenticated = this.isAuthenticatedSource.asObservable();

    constructor(
        public authRepository: AuthRepository
    ) { }

    login(loginModel: LoginModel) {
        this.authRepository.login(loginModel).subscribe((loginResult) => {
            
        });
    }

    register(registerModel: RegisterModel) {
        return this.authRepository.register(registerModel);
    }
    
}