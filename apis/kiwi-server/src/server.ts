import { createKiwiServer, IKiwiOptions, AuthorizeResponse } from 'kiwi-server';
import * as http from 'http';
import { UserController } from './controllers/user.controller'
import { HeadersMiddleware } from './middlewares/headers.middleware.before';

async function validateAuthentication(request: http.IncomingMessage, roles: Array<string>): Promise<AuthorizeResponse | boolean> {
  const accessToken = request.headers['authorization'];
  if (!accessToken) {
    return new AuthorizeResponse(401, 'User is not atuhenticated')
  }
  if (accessToken !== 'HARCODED_TOKEN') {
    return new AuthorizeResponse(401, 'Invalid User Token');
  }
  return true;
}

const options: IKiwiOptions = {
    controllers: [UserController],
    authorization: validateAuthentication,
    middlewares: [ HeadersMiddleware ],
    cors: {
        enabled: true,
        domains: ["http://localhost:4200"]
    },
    documentation: {
        enabled: true,
        path: '/apidoc'
    },
    log: true,
    port: 8086
}

const server = createKiwiServer(options);