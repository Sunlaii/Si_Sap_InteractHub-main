import { apiRequest } from './api';
import { User } from '../types';

export interface AuthResponse {
  token: string;
  user: User;
}

export async function loginApi(email: string, password: string): Promise<AuthResponse> {
  return apiRequest<AuthResponse>('/auth/login', {
    method: 'POST',
    body: JSON.stringify({ email, password }),
  });
}

export async function registerApi(payload: {
  fullName: string;
  userName: string;
  email: string;
  password: string;
}): Promise<AuthResponse> {
  return apiRequest<AuthResponse>('/auth/register', {
    method: 'POST',
    body: JSON.stringify(payload),
  });
}

export async function getMeApi(): Promise<User> {
  return apiRequest<User>('/auth/me');
}
