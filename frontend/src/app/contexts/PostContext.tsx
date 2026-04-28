import React, { createContext, useContext, useState, useEffect, ReactNode } from 'react';
import { Post, Comment } from '../types';
import { useAuth } from './AuthContext';
import { addCommentApi, createPostApi, getPostsApi, likePostApi, unlikePostApi } from '../services/postApi';

interface PostContextType {
  posts: Post[];
  loading: boolean;
  createPost: (content: string, images: string[], hashtags: string[]) => Promise<void>;
  likePost: (postId: string) => void;
  unlikePost: (postId: string) => void;
  addComment: (postId: string, content: string) => void;
  sharePost: (postId: string) => void;
  deletePost: (postId: string) => void;
  getPostById: (postId: string) => Post | undefined;
  getPostsByHashtag: (hashtag: string) => Post[];
  searchPosts: (query: string) => Post[];
}

const PostContext = createContext<PostContextType | undefined>(undefined);

export const PostProvider: React.FC<{ children: ReactNode }> = ({ children }) => {
  const [posts, setPosts] = useState<Post[]>([]);
  const [loading, setLoading] = useState(true);
  const { user } = useAuth();

  useEffect(() => {
    const loadPosts = async () => {
      setLoading(true);
      try {
        const data = await getPostsApi();
        setPosts(data);
      } catch {
        setPosts([]);
      } finally {
        setLoading(false);
      }
    };

    loadPosts();
  }, []);

  const createPost = async (content: string, images: string[], hashtags: string[]): Promise<void> => {
    if (!user) {
      throw new Error('Bạn phải đăng nhập để đăng bài');
    }

    try {
      const imageUrl = images && images.length > 0 ? images[0] : undefined;
      const createdPost = await createPostApi(content, imageUrl);
      setPosts((prev) => [createdPost, ...prev]);
    } catch (error) {
      const errorMessage = error instanceof Error ? error.message : 'Không thể đăng bài viết. Vui lòng thử lại!';
      throw new Error(errorMessage);
    }
  };

  const likePost = (postId: string) => {
    if (!user) return;

    setPosts((prev) => prev.map(post => {
      if (post.id === postId && !post.likes.includes(user.id)) {
        return { ...post, likes: [...post.likes, user.id] };
      }
      return post;
    }));

    void likePostApi(postId).catch(() => {
      setPosts((prev) => prev.map(post => {
        if (post.id === postId) {
          return { ...post, likes: post.likes.filter(id => id !== user.id) };
        }
        return post;
      }));
    });
  };

  const unlikePost = (postId: string) => {
    if (!user) return;

    setPosts((prev) => prev.map(post => {
      if (post.id === postId) {
        return { ...post, likes: post.likes.filter(id => id !== user.id) };
      }
      return post;
    }));

    void unlikePostApi(postId).catch(() => {
      setPosts((prev) => prev.map(post => {
        if (post.id === postId && !post.likes.includes(user.id)) {
          return { ...post, likes: [...post.likes, user.id] };
        }
        return post;
      }));
    });
  };

  const addComment = (postId: string, content: string) => {
    if (!user) return;

    const newComment: Comment = {
      id: `c${Date.now()}`,
      postId,
      userId: user.id,
      user: user,
      content,
      createdAt: new Date().toISOString(),
    };

    setPosts((prev) => prev.map(post => {
      if (post.id === postId) {
        return { ...post, comments: [...post.comments, newComment] };
      }
      return post;
    }));

    void addCommentApi(postId, content)
      .then((createdComment) => {
        setPosts((prev) => prev.map(post => {
          if (post.id !== postId) return post;

          const withoutOptimistic = post.comments.filter(c => c.id !== newComment.id);
          return { ...post, comments: [...withoutOptimistic, createdComment] };
        }));
      })
      .catch(() => {
        setPosts((prev) => prev.map(post => {
          if (post.id !== postId) return post;
          return { ...post, comments: post.comments.filter(c => c.id !== newComment.id) };
        }));
      });
  };

  const sharePost = (postId: string) => {
    setPosts(posts.map(post => {
      if (post.id === postId) {
        return { ...post, shares: post.shares + 1 };
      }
      return post;
    }));
  };

  const deletePost = (postId: string) => {
    setPosts(posts.filter(post => post.id !== postId));
  };

  const getPostById = (postId: string) => {
    return posts.find(post => post.id === postId);
  };

  const getPostsByHashtag = (hashtag: string) => {
    return posts.filter(post => 
      post.hashtags.some(tag => tag.toLowerCase() === hashtag.toLowerCase())
    );
  };

  const searchPosts = (query: string) => {
    const lowerQuery = query.toLowerCase();
    return posts.filter(post =>
      post.content.toLowerCase().includes(lowerQuery) ||
      post.user.fullName.toLowerCase().includes(lowerQuery) ||
      post.user.username.toLowerCase().includes(lowerQuery) ||
      post.hashtags.some(tag => tag.toLowerCase().includes(lowerQuery))
    );
  };

  return (
    <PostContext.Provider
      value={{
        posts,
        loading,
        createPost,
        likePost,
        unlikePost,
        addComment,
        sharePost,
        deletePost,
        getPostById,
        getPostsByHashtag,
        searchPosts,
      }}
    >
      {children}
    </PostContext.Provider>
  );
};

export const usePosts = () => {
  const context = useContext(PostContext);
  if (!context) {
    throw new Error('usePosts must be used within PostProvider');
  }
  return context;
};
