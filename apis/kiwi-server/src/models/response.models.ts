export class Metadata {
  code: number;
  message: string;

  constructor(code: number, message: string) {
    this.code = code;
    this.message = message;
  }
}

export class Response {
  data: any;
  meta: Metadata;

  constructor(code: number, message: string, result?: any) {
    this.data = result;
    this.meta = new Metadata(code, message);
  }
}

export class ResponseCode {
  static OK = 0;
  static ERROR = 1;
  static WARNING = 2;
}