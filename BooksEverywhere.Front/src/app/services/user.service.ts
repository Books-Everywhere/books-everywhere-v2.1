import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { of } from 'rxjs/observable/of';
import { catchError, map, tap } from 'rxjs/operators';
import { BaseService } from './base.service';
import { User } from '../models/user';
import { AppConfig } from '../config/config';
import { Helpers } from '../helpers/helpers';

@Injectable()
export class UserService extends BaseService {

    private pathAPI = this.config.setting['user/'];

    constructor(private http: HttpClient, private config: AppConfig, helper: Helpers) { super(helper); }

    /** GET heroes from the server */
    //getUsers(): Observable<any[]> {
    //    return this.http.get(this.pathAPI + 'user', super.header()).pipe(
    //        catchError(super.handleError));
    //}

    create(item: any): Promise<any> {
        const url = `${this.pathAPI}`;
        return this.http.post<any>(url, JSON.stringify(item)).toPromise();
    }

    edit(user: User): Promise<any> {
        const url = `${this.pathAPI}${user.id}`;
        return this.http.put<User>(url, JSON.stringify(user)).toPromise();
    }
}
