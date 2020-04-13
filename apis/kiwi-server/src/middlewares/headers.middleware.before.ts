import { IMiddleware } from 'kiwi-server';
import { MiddlewareBefore } from 'kiwi-server';
import * as http from 'http';

@MiddlewareBefore()
export class HeadersMiddleware implements IMiddleware {
    
    execute(request: http.IncomingMessage, response: http.ServerResponse, next: any){
        response.setHeader('Access-Control-Allow-Headers', 'authorization');
        next();
    }
}