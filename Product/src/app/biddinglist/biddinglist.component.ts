import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-biddinglist',
  templateUrl: './biddinglist.component.html',
  styleUrls: ['./biddinglist.component.css']
})
export class BiddinglistComponent implements OnInit {
  public headers = new HttpHeaders({
    'Content-Type': 'application/json',
  })
  constructor(private http:HttpClient) { }

  ngOnInit(): void {
  }
  title = 'Product';
  searchText = ''
  product={
    id: '',
  productName:'',
  shortDescription:'',
  detailedDescription:'',                                                
  category:'',
  stratingPrice: '',
  bidEndDate:'',
  biddings:''
  };
  search()
  {
     this.http.get<any>(`https://localhost:7213/api/Product/GetById?id=${this.searchText}`, { headers: this.headers }).subscribe(data=>{
      this.product=data;
      console.log(this.product);
    });
  }
  delete()
  {
    this.http.delete<any>(`https://localhost:7213/api/Product/Delete?id=${this.searchText}`, { headers: this.headers }).subscribe();
    
  }

}
