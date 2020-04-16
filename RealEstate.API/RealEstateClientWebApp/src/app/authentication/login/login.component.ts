import { Component, OnInit } from '@angular/core';
import { LoginViewModel } from '../_ViewModels/LoginViewModel';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { AuthService } from '../../auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  loginForm: FormGroup;
  loginError: string = null;
  returnUrl: string;

  constructor(private formBuilder: FormBuilder,
    private router: Router,
    private route: ActivatedRoute,
    private authService: AuthService) { }

  ngOnInit() {
    this.loginForm = this.formBuilder.group({
      username: [null, [Validators.required, Validators.email]],
      password: [null, [Validators.required]]
    });

    this.loginForm["submitted"] = false;

    this.loginForm.valueChanges.subscribe((value) => {
      //console.log(value);
    });

    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }

  onSubmitClick() {
    debugger
    this.loginForm["submitted"] = true;

    if (this.loginForm.valid) {
      var loginVieModel = this.loginForm.value as LoginViewModel;
      this.authService.login(loginVieModel).subscribe(
        (response) => {
          this.router.navigate(["home"]);
          this.router.navigateByUrl(this.returnUrl);
        },
        (error) => {
          this.loginError = "Username or password is incorrect";
        });
    }

  }

}
