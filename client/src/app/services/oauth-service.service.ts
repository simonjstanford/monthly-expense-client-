import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class OauthServiceService {
  currentUser: User | null;

  constructor(private http: HttpClient) { 
    this.currentUser = null;
  }
  
  getUser() {
    try {
      this.http.get('/.auth/me').subscribe((resp: any) => {
        console.log(resp);
        if (resp.text) {
          this.currentUser = resp.text.json();
        } else {
          this.currentUser = null;
        }
      });
    } catch (e) {
      console.log(e);
    }
  }
}
