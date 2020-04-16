import { Injectable } from '@angular/core';
import { AuthService } from '../auth.service';
import { ValidatorFn, ValidationErrors, FormGroup, AsyncValidatorFn, AbstractControl } from '@angular/forms';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthCustomValidatorsService {

  constructor(private authService: AuthService) { }

  public compareValidator(controlToValidate: string, controlToCompare: string): ValidatorFn {
    return (formGroup: FormGroup): ValidationErrors | null => {
      if (!formGroup.get(controlToValidate).value)
        return null; //return, if the confirm password is null

      if (formGroup.get(controlToValidate).value == formGroup.get(controlToCompare).value)
        return null; //valid
      else {
        formGroup.get(controlToValidate).setErrors({ compareValidator: { valid: false } });
        return { compareValidator: { valid: false } }; //invalid
      }
    };
  }

  public DuplicateEmailValidator(): AsyncValidatorFn {
    return (control: AbstractControl): Observable<ValidationErrors | null> => {
      return this.authService.checkUserExistsByEmail(control.value).pipe(map((existingUser: any) => {
        if (existingUser == true) {
          return { uniqueEmail: { valid: false } }; //invalid
        }
        else {
          return null;
        }
      }));
    };
  }
}
