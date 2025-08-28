import { Component } from '@angular/core';
import { AuthService } from './core/auth/auth.service';

@Component({
  selector: 'app-root',
  template: `
    <nav class="container">
      <a routerLink="/" routerLinkActive="active">Home</a>
      <a routerLink="/dashboard" routerLinkActive="active">Dashboard</a>
      <span style="float:right">
        <ng-container *ngIf="auth.isAuthenticated(); else loggedOut">
          Olá, {{auth.user?.name}} |
          <button (click)="logout()">Sair</button>
        </ng-container>
        <ng-template #loggedOut>
          <a routerLink="/login">Entrar</a>
        </ng-template>
      </span>
    </nav>
    <main class="container">
      <router-outlet></router-outlet>
    </main>
  `
})
export class AppComponent {
  constructor(public auth: AuthService) { }
  logout() { this.auth.logout(); }
}
