import { verify, sign, decode } from 'jsonwebtoken';
import { environment } from '../../environments/environment';
import { getRepository } from '../datastore';
import { User } from '../datastore/entities/user';
import { UserIn, LoginIn } from '../models/user.model';
import { encrypt } from '../encrypt';
import { ResponseCode, Response } from '../models/response.models';
import { traceError } from '../utils';

export class AuthService {
  
  async register(data: UserIn) {
    const userRepository = await getRepository(User);
    const user = new User();
    user.username = data.username;
    user.email = data.email;
    user.password = encrypt(data.password);
    const result = await userRepository.insert(user);
    return new Response(ResponseCode.OK, 'User created');
  }

  async login({ username, password: plainPassword }: LoginIn) {
    const password = encrypt(plainPassword);

    const userRepository = await getRepository(User);
    const user: User = await userRepository.findOne({ username, password });
    if (!user) {
      return new Response(ResponseCode.ERROR, 'Username or password is invalid. Please try again');
    }

    const token = sign({ username, email: user.email, id: user.id }, environment.jwt.secret, {
      expiresIn: 60 * environment.jwt.timestamp
    });

    return new Response(ResponseCode.OK, '', {token});
  }

  async validate(authHeader: string) {
    const token = authHeader.replace('Bearer ', '');
    try {
      const jwtResult = await verify(token, environment.jwt.secret);
      return !!jwtResult;
    } catch (ex) {
      traceError(ex.message);
      return false;
    }
  }

  decode(authHeader: string) {
    if (authHeader) {
      const token = authHeader.replace('Bearer ', '');
      return decode(token);
    }
    return {};
  }

}