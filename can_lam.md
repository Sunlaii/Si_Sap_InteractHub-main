# Cần làm tiếp để hoàn thành đồ án InteractHub

File này ghi lại các việc cần làm tiếp theo, theo đúng trạng thái hiện tại của project và yêu cầu đồ án.

## 1. Chạy và kiểm tra lại project local

1. [x] Chạy backend bằng `dotnet run` trong thư mục `backend`.
2. [x] Chạy frontend bằng `npm run dev` trong thư mục `frontend`.
3. [x] Kiểm tra backend ở `http://localhost:5052/swagger`.
4. [x] Kiểm tra frontend ở `http://localhost:5173`.
5. [x] Nếu backend báo lỗi database, kiểm tra SQL Server và chuỗi kết nối trong `backend/appsettings.json`.

## 2. Hoàn thiện backend trước

### 2.1 Bổ sung xác thực JWT
- [x] Tạo cấu hình JWT trong `Program.cs`.
- [x] Tạo service sinh token.
- [x] Làm API `POST /api/auth/register` và `POST /api/auth/login`.
- [x] Lưu token và claims đúng chuẩn.

### 2.2 Bổ sung phân quyền
- [x] Tạo role `User` và `Admin`.
- [x] Gắn `[Authorize]` cho các API cần bảo vệ.
- [x] Thêm policy-based authorization.

### 2.3 Bổ sung CORS
- [x] Cho phép frontend React gọi backend.
- [x] Kiểm tra lại origin local của frontend.

### 2.4 Tạo đủ API controller
- [x] Hoàn thiện ít nhất 6 controller chính: Auth, Posts, Users, Friends, Stories, Notifications.
- [x] Đảm bảo có đủ endpoint CRUD và trả JSON. (Đã có AuthController + PostsController cơ bản, thêm Users/Friends/Stories/Notifications)

### 2.5 Tách service layer
- [x] Tách business logic ra khỏi controller.
- [x] Tạo ít nhất 5 service class.
- [ ] Dùng repository pattern nếu chưa có.

### 2.6 Hoàn thiện Entity Framework
- [x] Kiểm tra lại quan hệ giữa các entity.
- [x] Tạo thêm migration nếu còn thiếu.
- [x] Seed dữ liệu ban đầu cho test.

## 3. Hoàn thiện frontend tiếp theo

### 3.1 Nối frontend với backend thật
- [x] Tạo tầng API service bằng Axios hoặc Fetch.
- [x] Không dùng mock data cho các chức năng chính nữa.
- [x] Đồng bộ model/DTO với backend.

### 3.2 Làm state management
- Dùng React Context API hoặc Redux Toolkit.
- Quản lý auth state, posts, notifications, friends.

### 3.3 Làm forms và validation
- [x] Dùng React Hook Form cho login, register, post creation, profile update.
- [x] Hiển thị lỗi validation rõ ràng.

### 3.4 Làm routing và protected routes
- [x] Bảo vệ route cần đăng nhập.
- [x] Chuyển hướng user chưa đăng nhập về login.
- [x] Bổ sung lazy loading nếu chưa có.

### 3.5 Làm các tính năng động
- Tìm kiếm có debounce.
- Pagination hoặc infinite scroll.
- SignalR cho thông báo thời gian thực nếu còn thời gian.

## 4. Làm phần kiểm thử

1. Tạo test project bằng xUnit hoặc NUnit.
2. Viết test cho ít nhất 3 service.
3. Mock dependency bằng Moq.
4. Viết đủ ít nhất 15 test case.
5. Chạy test và lưu kết quả để đưa vào báo cáo.

## 5. Làm phần tài liệu

1. Viết README hướng dẫn cài và chạy.
2. Vẽ sơ đồ database và sơ đồ component.
3. Liệt kê API endpoint.
4. Chụp ảnh các màn hình chính.
5. Ghi chú rõ những gì đã làm theo từng yêu cầu của đề.

## 6. Làm phần deploy nếu còn thời gian

1. Tạo tài khoản Azure nếu chưa có.
2. Chuẩn bị Azure App Service, Azure SQL và Azure Blob Storage.
3. Tạo pipeline GitHub Actions hoặc Azure DevOps.
4. Thiết lập biến môi trường và connection string production.
5. Kiểm tra log sau khi deploy.

## 7. Thứ tự làm hợp lý nhất

1. Chạy được backend và frontend local.
2. Hoàn thiện backend auth, CORS, API và service.
3. Nối frontend với backend thật.
4. Làm form, validation, protected routes và state management.
5. Viết test.
6. Viết tài liệu.
7. Deploy lên Azure nếu còn thời gian.

## 8. Ưu tiên trước mắt

- [x] Ưu tiên cao nhất: JWT, API, CORS, và frontend gọi backend thật.
- Ưu tiên tiếp theo: form, protected routes, state management.
- Ưu tiên sau cùng: test, tài liệu, deploy.
