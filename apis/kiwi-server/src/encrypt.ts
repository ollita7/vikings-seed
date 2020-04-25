import { environment } from "../environments/environment";
const crypto = require('crypto');

export function encrypt(text: string): string {
  const hash = crypto
    .createHmac('sha256', environment.password_secret)
    .update(text)
    .digest('hex');

  return hash.toString();
}

