import { verify, sign } from 'jsonwebtoken';
import { environment } from '../../environments/environment';
import { getRepository } from '../datastore';
import { User } from '../datastore/entities/user';
import { UserIn } from '../models/user.model';
import { encrypt } from '../encrypt';
import { ResponseCode, Response } from '../models/response.models';

export class AuthService {
  
  async login({ username, password: plainPassword }: UserIn) {
    const password = encrypt(plainPassword);

    const userRepository = await getRepository(User);
    const user: User = await userRepository.findOne({ username, password });
    if (!user) {
      return new Response(ResponseCode.ERROR, 'Username or password is invalid. Please try again');
    }

    const token = sign({ username, email: user.email, userId: user.id }, environment.jwt.secret, {
      expiresIn: 60 * environment.jwt.timestamp
    });

    return new Response(ResponseCode.OK, '', token);
  }

  async validate(authHeader: string) {
    const token = authHeader.replace('Bearer ', '');
    try {
      const jwtResult = await verify(token, environment.jwt.secret);
      return !!jwtResult;
    } catch (ex) {
      return false;
    }
  }

  decode(token: string) {
    if (token) {
      const [, payload] = token.split('.');
      const decoded = Buffer.from(payload, 'base64').toString();
      const { userId } = JSON.parse(decoded);
      return { id: userId };
    }
    return {};
  }

}