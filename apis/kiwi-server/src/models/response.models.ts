export class Response {
  data: any;
  msg: string;
  result: number;

  constructor(code: number, message: string, result?: any) {
    this.data = result;
    this.result = code;
    this.msg = message;
  }
}

export class ResponseCode {
  static OK = 0;
  static ERROR = 1;
  static WARNING = 2;
}