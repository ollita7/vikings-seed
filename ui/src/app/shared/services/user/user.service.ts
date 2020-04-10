import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private httpClient: HttpClient) { }

  login(data){
    const url = `${environment.apiUrl}user/login`;
    return this.httpClient.post(url, data);
  }
}
