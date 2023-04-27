import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddProductComponent } from './add-product/add-product.component';
import { BidComponent } from './bid/bid.component';
import { BiddinglistComponent } from './biddinglist/biddinglist.component';
import { BidUpdateComponent } from './bid-update/bid-update.component';
import { LoginComponent } from './login/login.component';
import { SigninComponent } from './signin/signin.component';

const routes: Routes = [
  {path:'',component:LoginComponent},
  {path:'Bidding',component:BiddinglistComponent},
  {path:'signin',component:SigninComponent},
  {path:'Bid',component:BidComponent},
  {path:'Addproduct',component:AddProductComponent},
  {path:'UpdateBid',component:BidUpdateComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
