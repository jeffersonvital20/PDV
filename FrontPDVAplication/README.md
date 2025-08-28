# Angular 16 + JWT (Starter)

Projeto mínimo com autenticação JWT no front-end, guard de rota, interceptor para anexar o token e um **backend fake** (interceptor) para testes locais.

> **Credenciais de teste**: usuário `admin` e senha `admin`.

## Requisitos
- Node.js 18+
- Angular CLI 16 (`npm i -g @angular/cli@16`)

## Como rodar
```bash
npm install
npm start
```
Abra http://localhost:4200

## O que tem aqui
- `AuthService`: login, logout, persistência de token (localStorage) e estado do usuário.
- `AuthInterceptor`: injeta `Authorization: Bearer <token>` automaticamente.
- `AuthGuard`: protege rotas autenticadas.
- `FakeBackendInterceptor`: simula endpoints `/api/auth/login` e `/api/protected`.
- Páginas: Home (pública), Login, Dashboard (protegida).

## Produção
- Remova o `FakeBackendInterceptor` do `AppModule`.
- Aponte `environment.apiUrl` para sua API real.
- Garanta que sua API devolve `{ token, username }` no login e valida o JWT nos endpoints protegidos.
