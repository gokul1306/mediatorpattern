import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-bid',
  templateUrl: './bid.component.html',
  styleUrls: ['./bid.component.css']
})
export class BidComponent implements OnInit {

  constructor(private fb: FormBuilder) { }
  BidForm = this.fb.group({
    id: [0],
    productName: [''],
    bidAmount:['']

  });
  ngOnInit(): void {
  }
  onSubmit(){

  }
}
