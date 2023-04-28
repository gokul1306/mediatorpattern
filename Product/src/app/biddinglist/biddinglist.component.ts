import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Bidding } from '../Models/bidding';

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

  isShow = false;
  isShowTable = false;

  ngOnInit(): void {
  }
  title = 'Product';
  searchText = ''
  product={
    id: 0,
  productName:'',
  shortDescription:'',
  detailedDescription:'',                                                
  category:'',
  stratingPrice: '',
  bidEndDate:''
  };

  public bid: Bidding[] = [];
  public filter: Bidding[] = [];




  search()
  {
     this.http.get<any>(`https://localhost:7213/api/Product/GetById?id=${this.searchText}`, { headers: this.headers }).subscribe(data=>{
      this.product=data;
      this.isShow = true;
      this.http.get<any>(`https://localhost:7213/api/Bidding/GetAll`).subscribe(
        data =>{
          this.bid = data;
          this.filter = this.bid.filter(x => x.productId == this.product.id);
          console.log(this.filter)
        }
      )
      console.log(this.product);
    });
  }
  delete()
  {
    this.http.delete<any>(`https://localhost:7213/api/Product/Delete?id=${this.searchText}`).subscribe();
    this.isShow = false;
    
  }

  logout()
  {
    console.log("Hi Logout clicked.")
  }

}
