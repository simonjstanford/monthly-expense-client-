import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UserExpenses } from '../models/userExpenses';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private http: HttpClient) { 
  }
  
  getUserData() {
    return this.http.get<UserExpenses>('/api/monthexpenses');
  }
}
