import { HttpErrorResponse } from '@angular/common/http';
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
      email: new FormControl('',
        [Validators.required, Validators.email]),
      userName: new FormControl('', Validators.required),
      password: new FormControl('', Validators.required),
      passwordConfirmation: new FormControl('', [Validators.required])
    });
  }

  onSubmit() {
    var registrationRequest = <RegistrationRequest>{};
    registrationRequest.firstName = this.form.controls['firstName'].value;
    registrationRequest.lastName = this.form.controls['lastName'].value;
    registrationRequest.email = this.form.controls['email'].value;
    registrationRequest.userName = this.form.controls['userName'].value;
    registrationRequest.password = this.form.controls['password'].value;
    registrationRequest.passwordConfirmation = this.form.controls['passwordConfirmation'].value;

    this.authService
      .registerUser(registrationRequest)
      .subscribe(result => {
        this.registrationResult = result;


      if (this.registrationResult.success) {
          this.router.navigate(['login']);
        }
          
      }, error => console.error(error));
  }

}
