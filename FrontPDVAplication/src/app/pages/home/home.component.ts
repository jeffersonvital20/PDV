import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';

@Component({
  selector: 'app-home',
  template: `
    <div class="card">
      <h1>Bem-vindo 👋</h1>
      <p>Este é um starter Angular 16 com autenticação JWT (com backend fake para testes).</p>
      <p>
        Usuário de teste: <code>admin</code> | Senha: <code>admin</code>
      </p>
      <button (click)="pingProtected()">Chamar endpoint protegido</button>
      <p *ngIf="message" style="margin-top:12px">{{message}}</p>
    </div>
  `
})
export class HomeComponent {
  message = '';
  constructor(private http: HttpClient) { }
  pingProtected() {
    this.http.get<{ data: string }>(`${environment.apiUrl}/protected`).subscribe({
      next: res => this.message = res.data,
      error: err => this.message = 'Erro: ' + (err?.error?.message ?? 'desconhecido')
    });
  }
}
