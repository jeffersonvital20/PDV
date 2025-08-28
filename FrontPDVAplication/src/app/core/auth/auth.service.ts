import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { environment } from '../../../environments/environment';

export interface LoginRequest { name: string; password: string; }
export interface LoginResponse { token: string; name: string; }

@Injectable({ providedIn: 'root' })
export class AuthService {
  private tokenKey = 'app_token';
  user: { username: string } | null = null;

  constructor(private http: HttpClient, private router: Router) {
    const token = this.getToken();
    const username = localStorage.getItem('app_username');
    if (token && username) {
      this.user = { username };
    }
  }

  login(credentials: LoginRequest) {
    return this.http.post<LoginResponse>(`${environment.apiUrl}/Auth/login`, credentials);
    // return this.http.post<LoginResponse>(`https://localhost:7263/api/Auth/login`, credentials);
  }

  setSession(res: LoginResponse) {
    localStorage.setItem(this.tokenKey, res.token);
    localStorage.setItem('app_username', res.name);
    this.user = { username: res.name };
  }

  logout() {
    localStorage.removeItem(this.tokenKey);
    localStorage.removeItem('app_username');
    this.user = null;
    this.router.navigate(['/login']);
  }

  getToken(): string | null {
    return localStorage.getItem(this.tokenKey);
  }

  isAuthenticated(): boolean {
    return !!this.getToken();
  }
}
