import { Component } from '@angular/core';

@Component({
  selector: 'app-dashboard',
  template: `
    <div class="card">
      <h2>Dashboard (Rota Protegida)</h2>
      <p>Se você está vendo isso, o guard de autenticação liberou seu acesso ✅</p>
      <a routerLink="/products" routerLinkActive="active">Product</a>
    </div>
  `
})
export class DashboardComponent { }
