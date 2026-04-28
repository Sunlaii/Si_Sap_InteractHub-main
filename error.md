# Checklist test cho phần vừa hoàn thiện (F3, F4, B1, B4)

## A. Chuẩn bị chạy local

Thực hiện:
1. Chạy backend ở thư mục `backend`: `dotnet run --no-build`.
2. Chạy frontend ở thư mục `frontend`: `npm run dev`.
3. Mở web tại `http://localhost:5173`.

Kết quả mong đợi:
- Frontend mở bình thường.
- Backend có Swagger ở `http://localhost:5052/swagger`.

## B. Test F3 - Forms và Validation

### B1. Form đăng ký
Thực hiện:
1. Vào trang Register.
2. Bấm Đăng ký khi để trống.
3. Nhập dữ liệu hợp lệ và đăng ký lại.
4. Quan sát thanh độ mạnh mật khẩu khi gõ mật khẩu khác nhau.

Kết quả mong đợi:
- Các cảnh báo bắt buộc hiển thị đúng khi để trống.
- Khi nhập hợp lệ thì lỗi biến mất.
- Thanh độ mạnh mật khẩu thay đổi theo mật khẩu.
- Đăng ký thành công trả token và đăng nhập luôn.

### B2. Form tạo bài viết
Thực hiện:
1. Vào trang Home khi đã đăng nhập.
2. Bấm Đăng khi chưa nhập nội dung và chưa có ảnh.
3. Nhập nội dung dài hơn 2000 ký tự.
4. Nhập nội dung hợp lệ hoặc chọn ảnh rồi bấm Đăng.

Kết quả mong đợi:
- Trường hợp rỗng báo lỗi: cần nội dung hoặc ảnh.
- Nội dung > 2000 ký tự báo lỗi validation.
- Trường hợp hợp lệ tạo bài thành công và thấy bài mới trên feed.

## C. Test F4 - Routing, Protected Routes, Dynamic Features

### C1. Route guard
Thực hiện:
1. Đăng xuất.
2. Truy cập trực tiếp các route: `/`, `/friends`, `/notifications`.
3. Truy cập `/login` khi đã đăng nhập.

Kết quả mong đợi:
- Chưa đăng nhập thì bị chuyển về `/login`.
- Đã đăng nhập mà vào `/login` hoặc `/register` thì bị chuyển về `/`.

### C2. Admin route guard
Thực hiện:
1. Đăng nhập user thường, vào `/admin`.
2. Đăng nhập admin và vào `/admin`.

Kết quả mong đợi:
- User thường bị chuyển về trang chủ.
- Admin truy cập được trang quản trị.

### C3. Lazy loading + dynamic
Thực hiện:
1. Mở tab Network, lọc JS.
2. Điều hướng lần lượt giữa Home, Search, Notifications, Profile.
3. Ở Search gõ từ khóa nhanh liên tục.
4. Ở Home cuộn feed để load thêm.

Kết quả mong đợi:
- JS chunk tải theo từng trang (không tải tất cả ngay từ đầu).
- Search có debounce, kết quả cập nhật mượt.
- Infinite scroll/load more hoạt động.

## D. Test B1 - Database và EF Core

Thực hiện:
1. Kiểm tra thư mục `backend/Migrations`.
2. Chạy: `dotnet ef database update --configuration Release` trong thư mục backend.
3. Mở DB kiểm tra:
	- Bảng Hashtags có seed ban đầu.
	- Có unique index cho Name.
	- Có index mới cho thời gian tạo post/comment và expired story.

Kết quả mong đợi:
- Có tổng cộng 3 migration (Initial + 2 migration mới).
- Database update thành công, không lỗi migration.
- Constraint/index/seed áp dụng đúng.

## E. Test B4 - Service Layer

Thực hiện:
1. Mở code backend kiểm tra các file service:
	- `PostsService`
	- `FriendsService`
	- `StoriesService`
	- `NotificationsService`
	- `UsersService`
2. Kiểm tra controller tương ứng đã gọi service thay vì chứa full business logic.
3. Test API nhanh trên Swagger/Postman:
	- Posts: get/create/like/comment
	- Friends: send/update/delete
	- Stories: get/create/delete
	- Notifications: get/create/read
	- Users: get by id/update me/get my friends

Kết quả mong đợi:
- Controller mỏng hơn, chủ yếu nhận request + trả response.
- Logic chính nằm trong service layer.
- API vẫn chạy đúng như trước sau khi refactor.

## F. Nếu gặp lỗi thường gặp

1. Lỗi port `5052` đã dùng:
- Dừng tiến trình backend cũ rồi chạy lại.

2. `401 Unauthorized` khi login:
- Kiểm tra đúng email/mật khẩu.
- Dùng demo account: `nguyenvana@example.com` / `demo123`.

3. Build backend Debug lỗi file bị lock:
- Dùng `dotnet build -c Release` hoặc dừng tiến trình backend đang chạy.
