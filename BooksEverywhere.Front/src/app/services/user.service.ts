import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from './base.service';
import { User } from '../models/user';
import { AppConfig } from '../config/config';
import { Helpers } from '../helpers/helpers';

@Injectable({
    providedIn: 'root'
})
export class UserService extends BaseService {

    private pathAPI = this.config.setting['PathAPI'] + 'user';

    constructor(private http: HttpClient,
        private config: AppConfig,
        helper: Helpers) { super(helper); }

    /** GET heroes from the server */
    //getUsers(): Observable<any[]> {
    //    return this.http.get(this.pathAPI + 'user', super.header()).pipe(
    //        catchError(super.handleError));
    //}

    create(item: User) {
        const url = `${this.pathAPI}`;
        return this.http.post<User>(url, item).subscribe(res => console.log(res));
    }

    async edit(user: User): Promise<any> {
        const url = `${this.pathAPI}${user.id}`;
        return await this.http.put<User>(url, JSON.stringify(user)).toPromise();
    }
}
