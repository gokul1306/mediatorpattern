import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthenticationService } from '../authentication.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})

export class LoginComponent implements OnInit {
  public headers = new HttpHeaders({
    'Content-Type': 'application/json',
  })
  constructor(private fb: FormBuilder,private http:HttpClient,private router : Router) { }

  LoginForm = this.fb.group({
    email: [''],
    password:['']

  });

  ngOnInit(): void {
  }

  onSubmit(){
    return this.http.post<any>(`https://localhost:7213/api/User?Email=${this.LoginForm.value.email}&Password=${this.LoginForm.value.password}`, this.LoginForm.value, { headers: this.headers }).subscribe({
      next: (data) => {
        console.log(data);
        AuthenticationService.SetDateWithExpiry("token", data.token, data.expiryInMinutes)
        AuthenticationService.SetDateWithExpiry("Role", data.role, data.expiryInMinutes)
        AuthenticationService.SetDateWithExpiry("Id", data.id, data.expiryInMinutes)
        AuthenticationService.SetDateWithExpiry("Name", data.name, data.expiryInMinutes)
        AuthenticationService.SetDateWithExpiry("Email", data.email, data.expiryInMinutes)
        data  ? this.router.navigate(['/Bidding']) : null}});
  }

}
