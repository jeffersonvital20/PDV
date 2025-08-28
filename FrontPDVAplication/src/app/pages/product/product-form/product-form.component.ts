import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductService } from '../../../core/product/Service/product.service';
import { Product } from '../../../core/product/model/product.model';

@Component({
    selector: 'app-product-form',
    templateUrl: './product-form.component.html'
})
export class ProductFormComponent implements OnInit {
    productForm!: FormGroup;
    productId: string | null = null;

    constructor(
        private fb: FormBuilder,
        private productService: ProductService,
        private router: Router,
        private route: ActivatedRoute
    ) { }

    ngOnInit(): void {
        this.productForm = this.fb.group({
            name: ['', Validators.required],
            amount: [0, Validators.required],
            price: [0, Validators.required]
        });

        this.productId = this.route.snapshot.paramMap.get('id');
        if (this.productId) {
            this.productService.getById(this.productId).subscribe(product => {
                this.productForm.patchValue(product);
            });
        }
    }

    submit() {
        const product: Product = {
            id: this.productId ?? '',
            ...this.productForm.value
        };

        if (this.productId) {
            this.productService.update(product).subscribe(() => this.router.navigate(['/products']));
        } else {
            this.productService.create(product).subscribe(() => this.router.navigate(['/products']));
        }
    }
}
