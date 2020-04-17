import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpResponse
} from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { map, catchError } from 'rxjs/operators' ;
import { NgBlockUI, BlockUI } from 'ng-block-ui';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { StateService } from '../services/state/state.service';

@Injectable()
export class RequestInterceptor implements HttpInterceptor {
  @BlockUI() blockUI: NgBlockUI;

  constructor(private toast: ToastrService, private router: Router, private stateServide: StateService) {
  }

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    this.blockUI.start();
    if (this.stateServide.authorization) {
      request = request.clone({
        headers: request.headers.set('authorization', this.stateServide.authorization)
      });
    }
    return next.handle(request)
      .pipe(map((event: HttpEvent<any>) => {
        this.blockUI.stop();
        if (event instanceof HttpResponse) {
          if (event.body.result !== 0) {
            this.toast.error(event.body.msg);
          } else{
            this.toast.success(event.body.msg);
          }
        }
        return event;
      }),
      catchError(err => {
        if (err.status === 401){
          this.toast.error(err.error);
          this.router.navigate(['/login']);
        } else{
          this.toast.error('Error: Please contact the administrator');
        }
        this.blockUI.stop();
        return throwError(err);
      }));
  }
}
