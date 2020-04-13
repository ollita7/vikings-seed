import { JsonController, Get, Post, Param, Body, IsString, AuthorizeResponse, Authorize} from 'kiwi-server';

export class UserIn{
  @IsString() username: string;
  @IsString() password: string;
}

@JsonController('/user')
export class UserController {

    @Post('/login')
    public post(@Body() body: UserIn){
      if(body.username === 'kiwi' && body.password === '123456'){
        return { result: 0, token: 'HARCODED_TOKEN'};
      }
      return { result: -1, msg: 'User or password incorrect'};
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

