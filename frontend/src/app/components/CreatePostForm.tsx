import React, { useState } from 'react';
import { useForm } from 'react-hook-form';
import { Image as ImageIcon, X, Hash } from 'lucide-react';
import { useAuth } from '../contexts/AuthContext';
import { usePosts } from '../contexts/PostContext';
import { useImageUpload } from '../hooks/useImageUpload';
import { Avatar, AvatarFallback, AvatarImage } from './ui/avatar';
import { Button } from './ui/button';
import { Textarea } from './ui/textarea';
import { Card } from './ui/card';
import { toast } from 'sonner';

interface CreatePostFormData {
  content: string;
}

const CreatePostForm: React.FC = () => {
  const { user } = useAuth();
  const { createPost } = usePosts();
  const { images, previews, uploading, handleFileChange, removeImage, clearImages } = useImageUpload(4);
  const [submitting, setSubmitting] = useState(false);
  const {
    register,
    handleSubmit,
    watch,
    reset,
    formState: { errors },
  } = useForm<CreatePostFormData>({
    defaultValues: {
      content: '',
    },
    mode: 'onChange',
  });
  const content = watch('content') ?? '';

  const extractHashtags = (text: string): string[] => {
    if (!text || !text.trim()) return [];
    const hashtagRegex = /#(\w+)/g;
    const matches = text.match(hashtagRegex);
    return matches ? matches.map(tag => tag.slice(1)) : [];
  };

  const onSubmit = async (data: CreatePostFormData) => {
    const trimmedContent = (data.content ?? '').trim();
    
    if (!trimmedContent && images.length === 0) {
      toast.error('Vui lòng nhập nội dung hoặc thêm hình ảnh!');
      return;
    }

    setSubmitting(true);

    try {
      const hashtags = extractHashtags(trimmedContent);
      await createPost(trimmedContent, images, hashtags);

      reset();
      clearImages();
      toast.success('Đã đăng bài viết!');
    } catch (error) {
      const errorMessage = error instanceof Error ? error.message : 'Không thể đăng bài viết. Vui lòng thử lại!';
      toast.error(errorMessage);
    } finally {
      setSubmitting(false);
    }
  };

  if (!user) return null;

  return (
    <Card className="p-4">
      <form onSubmit={handleSubmit(onSubmit)} className="space-y-4">
        <div className="flex gap-3">
          <Avatar>
            <AvatarImage src={user.avatar} alt={user.fullName} />
            <AvatarFallback>{user.fullName[0]}</AvatarFallback>
          </Avatar>
          <Textarea
            placeholder="Bạn đang nghĩ gì?"
            aria-invalid={!!errors.content}
            className="flex-1 min-h-[100px] resize-none"
            {...register('content', {
              maxLength: {
                value: 2000,
                message: 'Nội dung tối đa 2000 ký tự',
              },
            })}
          />
        </div>
        {errors.content && (
          <p className="text-sm text-red-500">{errors.content.message}</p>
        )}

        {/* Image Previews */}
        {previews.length > 0 && (
          <div className="grid grid-cols-2 gap-2">
            {previews.map((preview, index) => (
              <div key={index} className="relative aspect-square rounded-lg overflow-hidden bg-gray-100">
                <img src={preview} alt={`Preview ${index + 1}`} className="w-full h-full object-cover" />
                <button
                  type="button"
                  onClick={() => removeImage(index)}
                  className="absolute top-2 right-2 p-1 bg-black/50 hover:bg-black/70 rounded-full text-white"
                >
                  <X className="w-4 h-4" />
                </button>
              </div>
            ))}
          </div>
        )}

        <div className="flex items-center justify-between pt-3 border-t">
          <div className="flex items-center gap-2">
            <label htmlFor="image-upload">
              <Button
                type="button"
                variant="ghost"
                size="sm"
                disabled={uploading || images.length >= 4}
                onClick={() => document.getElementById('image-upload')?.click()}
              >
                <ImageIcon className="w-5 h-5 mr-2" />
                Hình ảnh
              </Button>
            </label>
            <input
              id="image-upload"
              type="file"
              accept="image/*"
              multiple
              onChange={handleFileChange}
              className="hidden"
            />
            
            <div className="text-sm text-gray-500 flex items-center gap-1">
              <Hash className="w-4 h-4" />
              <span>Sử dụng #hashtag</span>
            </div>
          </div>

          <Button type="submit" disabled={uploading}>
            {uploading || submitting ? 'Đang xử lý...' : 'Đăng'}
          </Button>
        </div>
      </form>
    </Card>
  );
};

export default CreatePostForm;
