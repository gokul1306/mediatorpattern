import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Product';

  searchText = ''
  product_name="Redmi";
  category="mobile";
  BidEndDate="30/04/2022";
  bidstartprice=1200;
  search()
  {
    console.log(this.searchText)
  }
}
