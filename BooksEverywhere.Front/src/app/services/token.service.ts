import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { of } from 'rxjs/observable/of';
import { catchError, map, tap } from 'rxjs/operators';
import { AppConfig } from '../config/config';
import { BaseService } from './base.service';
import { Helpers } from '../helpers/helpers';
import { User } from '../models/user';

@Injectable()

export class TokenService extends BaseService {

    private pathAPI = this.config.setting['PathAPI'];
    public errorMessage: string;

    constructor(private http: HttpClient, private config: AppConfig, helper: Helpers) { super(helper); }

    // private getToken(body: any): Observable<any> {
    //     return this.http.post<any>(this.pathAPI + 'user/login', body, super.header()).pipe(
    //         catchError(super.handleError)
    //     );
    // }

    public getToken(body: User){
        return this.http.post<User>(this.pathAPI + 'user/login', body).subscribe(res => console.log(res));
    }
}
