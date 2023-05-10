import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-signin',
  templateUrl: './signin.component.html',
  styleUrls: ['./signin.component.css']
})
export class SigninComponent implements OnInit {
  public headers = new HttpHeaders({
    'Content-Type': 'application/json',
  })
  constructor(private fb: FormBuilder,private http : HttpClient,private router : Router) { }
  SigninForm = this.fb.group({
    
    'firstName': [''],
    'lastName':[''],
    'email':[''],
    'phoneNumber':[''],
    'password':[''],
    'address':[''],
    'city':[''],
    'state': [''],
    'pincode': [''],
    'role' :['']

  });
  ngOnInit(): void {
  }
  onSubmit(){
    console.log("--------",this.SigninForm)
    return this.http.post<any>('https://localhost:7213/api/User/Create', this.SigninForm.value, { headers: this.headers }).subscribe();
    
  }
}
