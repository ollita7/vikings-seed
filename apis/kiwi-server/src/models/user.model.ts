import { IsString } from 'kiwi-server';

export class UserIn{
  @IsString() username: string;
  @IsString() email: string;
  @IsString() password: string;
}