import { Component, OnInit } from "@angular/core";
import { ProductService } from "./product.service";

@Component({
  selector: "app-product",
  templateUrl: "product.component.html",
  providers:[ProductService]
})
export class ProductComponent implements OnInit {

  products: any[]
  constructor(private productService:ProductService) {}

  ngOnInit() {
    this.getAll();
  }

  getAll() {
    this.productService.GetAll().subscribe( data => {
      this.products = data
      console.log(this.products)
    })
  }
}
