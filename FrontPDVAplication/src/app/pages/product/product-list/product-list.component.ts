import { Component, OnInit } from '@angular/core';
import { ProductService } from '../../../core/product/Service/product.service';
import { Product } from '../../../core/product/model/product.model';

@Component({
    selector: 'app-product-list',
    templateUrl: './product-list.component.html'
})
export class ProductListComponent implements OnInit {
    products: Product[] = [];

    constructor(private productService: ProductService) { }

    ngOnInit(): void {
        this.loadProducts();
    }

    loadProducts() {
        this.productService.getAll().subscribe(res => this.products = res);
    }

    deleteProduct(id: string) {
        if (confirm('Deseja realmente deletar?')) {
            this.productService.delete(id).subscribe(() => this.loadProducts());
        }
    }
}
