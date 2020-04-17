import { UserIn } from "../models/user.model";
import { getRepository } from "../datastore";
import { User } from "../datastore/entities/user";
import { Response, ResponseCode } from "../models/response.models";

export class UserService {
  
  async register(data: UserIn){
    const userRepository = await getRepository(User);
    const user = new User();
    user.username = data.username;
    user.email = data.email;
    user.password = data.password;
    user.createdAt = new Date();
    user.updatedAt = new Date();
    const result = await userRepository.insert(user);
    return new Response(ResponseCode.OK, 'User created');
  }
}