import { JsonController, Get, Post, Param, Body, IsString, AuthorizeResponse, Authorize, Put} from 'kiwi-server';
import { UserIn, LoginIn, ForgotPasswordIn, ResetPasswordIn } from '../models/user.model';
import { AuthService } from '../services/auth.service';

@JsonController('/user')
export class UserController {

  constructor(private authService: AuthService){ }

  @Post('/login')
  public post(@Body() body: LoginIn){
    return this.authService.login(body);
  }

  @Post()
  public register(@Body() body: UserIn){
    return this.authService.register(body);
  }

  @Authorize()
  @Get('/current')
  public current(request: any){
    console.log(request.user);
    return {
      result: 0,
      user: "kiwi"
    }
  }

  @Post('/forgot-password')
  public forgotPassword(@Body() body: ForgotPasswordIn){}

  
  @Put('/reset-password')
  public resetPassword(@Body() body: ResetPasswordIn){}
}

