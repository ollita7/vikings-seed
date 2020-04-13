import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class StateService {
  private AUTHORIZATION = 'WORKSHOP_AUTHORIZATION';

  get authorization() { return localStorage.getItem(this.AUTHORIZATION); }
  set authorization(value) { localStorage.setItem(this.AUTHORIZATION, value); }

  constructor() { }
}
