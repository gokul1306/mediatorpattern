import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-bid-update',
  templateUrl: './bid-update.component.html',
  styleUrls: ['./bid-update.component.css']
})
export class BidUpdateComponent implements OnInit {

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
