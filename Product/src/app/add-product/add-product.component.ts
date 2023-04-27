import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css']
})
export class AddProductComponent implements OnInit {
  public headers = new HttpHeaders({
    'Content-Type': 'application/json',
  })
  constructor(private fb: FormBuilder,private http : HttpClient,private router : Router) { }

  productForm = this.fb.group({
    id: [0],
    productname: [''],
    shortDescription: [''],
    detailedDescription: [''],
    category: [''],
    price: [],
    bidEndDate: []
  });
  option: any=[
    {values:"Painting"
    },{values:"Sculptor"},{values:"Ornament"}
  ]

  ngOnInit(): void {

  }

  onSubmit(){
    console.log(this.productForm.value)
    return this.http.post<any>('https://localhost:7213/api/Product/Create', this.productForm.value, { headers: this.headers }).subscribe({next: (data) => {data  ? this.router.navigate(['/Bidding']) : null}});
  }

}
