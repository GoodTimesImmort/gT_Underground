import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import {
  FormGroup, FormControl, Validators, AbstractControl, AsyncValidatorFn
} from '@angular/forms';

import { BaseFormComponent } from '../../base-form.component';
import { AuthService } from '../auth.service';
import { RegistrationRequest } from './registration-request';
import { RegistrationResult } from './registration-result';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent extends BaseFormComponent implements OnInit {

  title?: string;
  registrationResult?: RegistrationResult;

  constructor(
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private authService: AuthService) {
    super();
  }

  ngOnInit(): void {
    this.form = new FormGroup({
      firstName: new FormControl(''),
      lastName: new FormControl(''),
      email: new FormControl('', Validators.required),
      userName: new FormControl('', Validators.required),
      password: new FormControl('', Validators.required),
      passwordConfirmation: new FormControl('', Validators.required)
    });
  }

  onSubmit() {
    var registrationRequest = <RegistrationRequest>{};
    registrationRequest.firstName = this.form.controls['firstName'].value;
    registrationRequest.lastName = this.form.controls['lastName'].value;
    registrationRequest.email = this.form.controls['email'].value;
    registrationRequest.userName = this.form.controls['userName'].value;
    registrationRequest.password = this.form.controls['password'].value;

    this.authService
      .registerUser(registrationRequest)
      .subscribe(result => {
        console.log(result);
        this.registrationResult = result;
        if (result.success) {
          this.router.navigate(["/"]);
        }
      }, error => {
        console.log(error);
        if (error.status == 401) {
          this.registrationResult = error.error;
        }
      });
  }

}
