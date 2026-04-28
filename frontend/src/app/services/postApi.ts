import { apiRequest } from './api';
import { Comment, Post } from '../types';

export async function getPostsApi(): Promise<Post[]> {
  return apiRequest<Post[]>('/posts');
}

export async function createPostApi(content: string, imageUrl?: string): Promise<Post> {
  const body: { content: string; imageUrl?: string } = { content };
  if (imageUrl) {
    body.imageUrl = imageUrl;
  }
  return apiRequest<Post>('/posts', {
    method: 'POST',
    body: JSON.stringify(body),
  });
}

export async function likePostApi(postId: string): Promise<void> {
  await apiRequest<void>(`/posts/${postId}/like`, { method: 'POST' });
}

export async function unlikePostApi(postId: string): Promise<void> {
  await apiRequest<void>(`/posts/${postId}/like`, { method: 'DELETE' });
}

export async function addCommentApi(postId: string, content: string): Promise<Comment> {
  return apiRequest<Comment>(`/posts/${postId}/comments`, {
    method: 'POST',
    body: JSON.stringify({ content }),
  });
}
