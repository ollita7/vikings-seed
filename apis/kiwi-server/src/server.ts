import { createKiwiServer, IKiwiOptions, AuthorizeResponse } from 'kiwi-server';
import { UserController } from './controllers/user.controller'
import { HeadersMiddleware } from './middlewares/headers.middleware.before';
import { AuthService } from './services/auth.service';

async function validateAuthentication(request: any, roles: Array<string>): Promise<AuthorizeResponse | boolean> {
  const token = request.headers['authorization'];
  if (!token) {
    return new AuthorizeResponse(401, 'User is not atuhenticated')
  }
  const authService = new AuthService();
  request['user'] = authService.decode(token);
  return await authService.validate(token);
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