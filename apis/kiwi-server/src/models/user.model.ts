import { IsString } from 'kiwi-server';

export class UserIn{
  @IsString() username: string;
  @IsString() password: string;
}