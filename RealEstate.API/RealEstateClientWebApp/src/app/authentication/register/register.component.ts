import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, FormArray, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { RegisterViewModel } from '../_ViewModels/RegisterViewModel';
import { AuthService } from '../../auth.service';
import { AuthCustomValidatorsService } from '../auth-custom-validators.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  registerForm: FormGroup;
  registerError: string = null;

  constructor(private formBuilder: FormBuilder, private router: Router,
    private customValidatorsService: AuthCustomValidatorsService, private authService: AuthService) { }

  ngOnInit(): void {
    this.registerForm = this.formBuilder.group({
      firstName: [null, [Validators.required]],
      lastName: [null, [Validators.required]],
      email: [null, [Validators.required, Validators.email], [this.customValidatorsService.DuplicateEmailValidator()], { updateOn: 'blur' }],
      password: [null, [Validators.required, Validators.minLength(6)]],
      confirmPassword: [null, [Validators.required, Validators.minLength(6)]],
    },
      {
        validators: [
          this.customValidatorsService.compareValidator("confirmPassword", "password")
        ]
      });

    this.registerForm.valueChanges.subscribe((value) => {
      //console.log(value);
    });
  }

  onSubmitClick() {
    this.registerForm["submitted"] = true;

    if (this.registerForm.valid) {
      var registerViewModel = this.registerForm.value as RegisterViewModel;
      this.authService.Register(registerViewModel).subscribe(
        (response) => {
          this.router.navigate(["home"]);
        },
        (error) => {
          this.registerError = "Unable to submit";
        });
    }

  }

}
