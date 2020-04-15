import { JsonController, Get, Post, Param, Body, IsString, AuthorizeResponse, Authorize} from 'kiwi-server';
import { UserIn } from '../models/user.model';
import { UserService } from 'services/user.service';

@JsonController('/user')
export class UserController {

  constructor(private userService: UserService){ }

  @Post('/login')
  public post(@Body() body: UserIn){
    this.userService.login(body);

    /*
    if(body.username === 'kiwi' && body.password === '123456'){
      return { result: 0, token: 'HARCODED_TOKEN'};
    }
    return { result: -1, msg: 'User or password incorrect'};
    */
  }

  @Post()
  public register(@Body() body: UserIn){
    
  }

  @Authorize()
  @Get('/current')
  public current(){
    return {
      result: 0,
      user: "kiwi"
    }
  }
}

