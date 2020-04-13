import { FormGroup } from '@angular/forms';

export function ValidatePassowrd(passwordName: string, password2Name: string, message: string){
  return (formGroup: FormGroup) => {
    const password = formGroup.controls[passwordName];
    const password2 = formGroup.controls[password2Name];
    if (password2.errors && password.errors){
      return;
    }
    if (password.value !== password2.value){
      password2.setErrors({ doesntmutch: message});
    } else {
      password2.setErrors(null);
    }
  };
}
