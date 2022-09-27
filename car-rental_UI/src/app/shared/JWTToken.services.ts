import { Injectable } from '@angular/core';
import jwt_decode from "jwt-decode";


@Injectable()
export class JWTTokenService {

    jwtToken: string = '';
    decodedToken: { [key: string]: string } = {};

    constructor() {
    }

    setToken(token: string) {
        if (token) {
            this.jwtToken = token;
            localStorage.setItem("Role", this.getRole() || "")
        }
    }

    decodeToken() {
        if (this.jwtToken) {
            this.decodedToken = jwt_decode(this.jwtToken);
        }
    }

    getDecodeToken() {
        return jwt_decode(this.jwtToken);
    }

    getUser() {
        this.decodeToken();
        return this.decodedToken ? this.decodedToken.displayname : null;
    }

    getEmailId() {
        this.decodeToken();
        return this.decodedToken ? this.decodedToken.email : null;
    }

    getExpiryTime() {
        this.decodeToken();
        return this.decodedToken ? this.decodedToken.exp : null;
    }

    getRole() {
        this.decodeToken();
        return this.decodedToken ? this.decodedToken.RoleName : null;
    }

    isTokenExpired(): boolean {
        const expiryTime: any = this.getExpiryTime();
        if (expiryTime) {
            return ((1000 * expiryTime) - (new Date()).getTime()) < 5000;
        } else {
            return false;
        }
    }
}