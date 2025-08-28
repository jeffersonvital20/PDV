import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../../core/auth/auth.service';

@Component({
  selector: 'app-login',
  template: `
    <div class="card" style="max-width:420px;margin:0 auto;">
      <h2>Entrar</h2>
      <form [formGroup]="form" (ngSubmit)="submit()">
        <div style="display:grid;gap:10px">
          <input placeholder="Usuário" formControlName="username">
          <input placeholder="Senha" type="password" formControlName="password">
          <button type="submit" [disabled]="form.invalid || loading">
            {{ loading ? 'Entrando...' : 'Entrar' }}
          </button>
        </div>
        <div class="alert" *ngIf="error">{{error}}</div>
      </form>
    </div>
  `
})
export class LoginComponent {
  error = '';
  loading = false;
  form = this.fb.group({
    username: ['', Validators.required],
    password: ['', Validators.required],
  });

  constructor(private fb: FormBuilder, private auth: AuthService, private router: Router){}

  submit(){
    this.error = '';
    if (this.form.invalid) return;
    this.loading = true;
    this.auth.login(this.form.value as any).subscribe({
      next: (res) => {
        this.auth.setSession(res);
        this.router.navigate(['/dashboard']);
      },
      error: err => {
        this.error = err?.error?.message ?? 'Erro ao autenticar';
        this.loading = false;
      }
    });
  }
}
