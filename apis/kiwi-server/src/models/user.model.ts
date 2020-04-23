import { IsString, IsEmail } from 'kiwi-server';

export class UserIn{
  @IsString() username: string;
  @IsString() email: string;
  @IsString() password: string;
}

export class LoginIn{
  @IsString() username: string;
  @IsString() password: string;
}

export class ForgotPasswordIn{
  @IsString() username: string;
}

export class ResetPasswordIn{
  @IsString() token: string;
  @IsString() password: string;
}