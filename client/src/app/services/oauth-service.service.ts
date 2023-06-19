import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from '../models/user';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class OauthServiceService {

  public currentUserSubject = new Subject<User | null>();

  constructor(private http: HttpClient) { 
  }
  
  getUser() {
    this.http.get('/.auth/me', {observe: "response"})
      .toPromise()
      .then((resp: any) => {
        console.log(resp);
        if (resp && resp.text) {
          const user = resp.text.json();
          this.currentUserSubject.next(user)
        } else {
          this.currentUserSubject.next(null)
        }
      })
      .catch((err) => {
        console.log(err);
        this.currentUserSubject.next(null)
      });

    return this.currentUserSubject;
  }
}
