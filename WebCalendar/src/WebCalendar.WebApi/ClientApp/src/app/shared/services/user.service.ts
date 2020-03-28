import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {Observable} from "rxjs";
import {User} from "../User";

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

const baseUrl = "https://localhost:5001/api";

@Injectable()
export class UserService {

  constructor(private http:HttpClient) { }

  public registerUser(user: User): Observable<any>{
    return this.http.post(`${baseUrl}/user/registration`, user, httpOptions);
  }
}
