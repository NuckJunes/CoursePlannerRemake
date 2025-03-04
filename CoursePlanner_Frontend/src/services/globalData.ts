import { Injectable } from "@angular/core";
import { BehaviorSubject } from "rxjs";
import AccountReturnDTO from "../app/models/AccountReturnDTO";

@Injectable({
    providedIn: 'root',
})

export class globalData {
    private loggedInSource = new BehaviorSubject<boolean>(this.loadLoginFromLocalStorage());
    loggedIn = this.loggedInSource.asObservable();

    private accountSource = new BehaviorSubject<AccountReturnDTO | undefined>(this.loadAccountFromLocalStorage())
    account = this.accountSource.asObservable();

    getLoggedIn() {
        return this.loggedInSource;
    }

    getAccount() {
        return this.accountSource;
    }

    updateLoginStatus(login: boolean) {
        this.loggedInSource.next(login);
        localStorage.setItem('LoggedIn', login.toString());
    }

    updateAccountStatus(account: AccountReturnDTO | undefined) {
        this.accountSource.next(account);
        localStorage.setItem('Account', JSON.stringify(account));
    }

    private loadLoginFromLocalStorage(): boolean {
        try{
            const loginString = localStorage.getItem('LoggedIn');
            return loginString ? JSON.parse(loginString) : false;
        } catch(error) {

        }
        return false;
    }

    private loadAccountFromLocalStorage(): AccountReturnDTO|undefined {
        try{
            const accountString = localStorage.getItem('Account');
            return accountString ? JSON.parse(accountString) : undefined;
        } catch(error) {

        }
        return undefined;
    }
}