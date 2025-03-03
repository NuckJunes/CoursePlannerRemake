import { Injectable } from "@angular/core";
import { BehaviorSubject } from "rxjs";

@Injectable({
    providedIn: 'root',
})

export class globalData {
    private loggedInSource = new BehaviorSubject<boolean>(this.loadLoginFromLocalStorage());

    getLoggedIn() {
        return this.loggedInSource;
    }

    updateLoginStatus(login: boolean) {
        this.loggedInSource.next(login);
        localStorage.setItem('LoggedIn', login.toString());
    }

    private loadLoginFromLocalStorage(): boolean {
        try{
            const loginString = localStorage.getItem('LoggedIn');
            return loginString ? JSON.parse(loginString) : false;
        } catch(error) {

        }
        return false;
    }
}