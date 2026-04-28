1 Giới thiệu

Bài tập này yêu cầu bạn phát triển một ứng dụng web mạng xã hội đầy đủ chức năng có tên InteractHub. Bạn sẽ triển khai cả frontend và backend, qua đó thể hiện sự hiểu biết về thực hành phát triển web hiện đại, thiết kế cơ sở dữ liệu, phương pháp kiểm thử và triển khai lên đám mây.

1.1 Mục tiêu học tập
Khi hoàn thành bài tập này, bạn sẽ:
• Thiết kế và triển khai giao diện người dùng đáp ứng bằng TypeScript/JavaScript và các framework CSS hiện đại
• Xây dựng RESTful API bằng kiến trúc ASP.NET Core MVC
• Làm việc với Entity Framework Core cho các thao tác cơ sở dữ liệu
• Triển khai cơ chế xác thực và phân quyền
• Viết unit test cho các thành phần quan trọng của ứng dụng
• Triển khai ứng dụng lên hạ tầng đám mây (Microsoft Azure)
• Thiết lập pipeline CI/CD cho triển khai tự động

1.2 Mô tả ứng dụng
InteractHub là một nền tảng mạng xã hội cho phép người dùng:
• Tạo tài khoản và xác thực an toàn
• Đăng cập nhật trạng thái bằng văn bản và hình ảnh
• Chia sẻ story (nội dung tạm thời)
• Thích, bình luận và chia sẻ bài viết
• Gửi và quản lý lời mời kết bạn
• Nhận thông báo thời gian thực
• Quản lý hồ sơ và cài đặt người dùng
• Theo dõi hashtag xu hướng
• Báo cáo nội dung không phù hợp (cho quản trị viên kiểm duyệt)

2 Yêu cầu kỹ thuật

2.1 Công nghệ sử dụng

2.1.1 Frontend
• Framework: React 18+ với TypeScript
• Ngôn ngữ: TypeScript (bật strict mode)
• CSS Framework: Tailwind CSS
• Quản lý trạng thái: React Context API hoặc Redux Toolkit
• Routing: React Router v6+
• HTTP Client: Axios hoặc Fetch API
• Công cụ build: Vite hoặc Create React App
• Thư viện bổ sung: React Hook Form (cho biểu mẫu), React Query (tùy chọn cho lấy dữ liệu)

Lưu ý quan trọng: Frontend phải là ứng dụng SPA (Single Page Application) xây dựng bằng React và TypeScript. Frontend cần giao tiếp với backend thông qua các RESTful API endpoint sử dụng định dạng JSON.

2.1.2 Backend
• Framework: ASP.NET Core 8.0 Web API hoặc cao hơn
• Kiến trúc: RESTful API với mẫu Repository và Service
• ORM: Entity Framework Core 8.0+
• Cơ sở dữ liệu: SQL Server
• Xác thực: JWT (JSON Web Tokens) với ASP.NET Core Identity
• Phân quyền: Role-based và Policy-based authorization
• Tài liệu API: Swagger/OpenAPI
• CORS: Cấu hình cho frontend React
• Thời gian thực: SignalR (cho thông báo)

2.1.3 Cloud và DevOps
• Nền tảng đám mây: Microsoft Azure
• CI/CD: Azure DevOps hoặc GitHub Actions
• Lưu trữ: Azure Blob Storage (cho hình ảnh)

3 Yêu cầu bài tập (10 điểm)

Tiến độ hiện tại (đối chiếu theo mã nguồn):
- [x] 3.1.1 F1: Kiến trúc React Component và Responsive
- [x] 3.1.2 F2: State Management và API Integration
- [x] 3.1.3 F3: React Forms và Validation
- [x] 3.1.4 F4: Routing, Protected Routes và Dynamic Features
- [x] 3.2.1 B1: Database Design và Entity Framework
- [x] 3.2.2 B2: RESTful API Controllers và DTOs
- [x] 3.2.3 B3: JWT Authentication và Authorization
- [x] 3.2.4 B4: Business Logic và Services Layer
- [ ] 3.3.1 T1: Unit Testing
- [ ] 3.4.1 D1: Azure Deployment và CI/CD Pipeline

3.1 Yêu cầu Frontend (4 điểm)

3.1.1 Yêu cầu F1: Kiến trúc React Component và thiết kế Responsive (1 điểm)
Trạng thái: [x] Đã hoàn thành
Mô tả: Xây dựng ứng dụng React theo hướng component với TypeScript, tuân thủ thực hành tốt về cấu trúc component, kiểu dữ liệu props và thiết kế responsive.

Công việc cụ thể:
• Tạo các React component có thể tái sử dụng với TypeScript interface phù hợp
• Triển khai functional component với React Hooks (useState, useEffect, useContext, ...)
• Dùng Tailwind CSS cho thiết kế responsive theo hướng mobile-first
• Tổ chức component theo cấu trúc thư mục hợp lý (components, pages, layouts, utils)
• Triển khai custom hooks cho logic tái sử dụng
• Tạo hệ thống điều hướng responsive thích ứng với kích thước màn hình
• Đảm bảo tất cả component thân thiện trên thiết bị di động

Sản phẩm bàn giao:
• Ít nhất 15 React component có TypeScript interface
• Tài liệu cây phân cấp component
• Thanh điều hướng responsive dùng React Router
• Custom hooks cho chức năng dùng chung
• Ảnh chụp màn hình thể hiện thiết kế responsive trên nhiều thiết bị

Tiêu chí đánh giá:
• Kiến trúc component và khả năng tái sử dụng (35%)
• TypeScript typing và interfaces (25%)
• Cách sử dụng React Hooks và best practices (25%)
• Triển khai responsive design (15%)

3.1.2 Yêu cầu F2: Quản lý trạng thái và tích hợp API (1 điểm)
Trạng thái: [x] Đã hoàn thành
Mô tả: Triển khai quản lý trạng thái bằng React Context API hoặc Redux, đồng thời tích hợp RESTful API backend bằng Axios.

Công việc cụ thể:
• Thiết lập React Context API hoặc Redux Toolkit cho quản lý trạng thái toàn cục
• Tạo tầng API service bằng Axios cho các HTTP request
• Quản lý trạng thái xác thực (login, logout, lưu token)
• Quản lý trạng thái ứng dụng (posts, users, notifications, friends)
• Xử lý trạng thái loading, lỗi và phản hồi thành công từ API
• Lưu JWT token và tự động chèn header
• Tạo API interceptor cho xác thực và xử lý lỗi
• Triển khai optimistic UI update để cải thiện trải nghiệm

Sản phẩm bàn giao:
• Cấu hình Context providers hoặc Redux store
• Các file API service với kiểu dữ liệu phản hồi rõ ràng
• Authentication context/slice có action login/logout
• Custom hooks cho API calls (ví dụ: usePosts, useAuth)
• Xử lý loading và error state xuyên suốt component
• TypeScript interface cho toàn bộ API response

Tiêu chí đánh giá:
• Triển khai quản lý trạng thái (30%)
• Tích hợp API và xử lý lỗi (30%)
• TypeScript typing cho API response (20%)
• Luồng xác thực (20%)

3.1.3 Yêu cầu F3: React Forms và Validation (1 điểm)
Trạng thái: [x] Đã hoàn thành
Mô tả: Triển khai biểu mẫu bằng React Hook Form với kiểm tra dữ liệu toàn diện, typing bằng TypeScript và trải nghiệm người dùng tốt.

Công việc cụ thể:
• Dùng React Hook Form cho mọi biểu mẫu (đăng ký, đăng nhập, tạo bài viết, cập nhật hồ sơ)
• Triển khai kiểm tra dữ liệu phía client với thông báo lỗi rõ ràng
• Thêm các quy tắc kiểm tra tùy chỉnh (độ mạnh mật khẩu, định dạng email, loại tệp)
• Tạo component input tái sử dụng (TextInput, FileInput, ...)
• Triển khai phản hồi validation theo thời gian thực
• Thêm chức năng upload tệp với xem trước
• Hiển thị trạng thái loading khi gửi biểu mẫu
• Hiển thị thông báo thành công/lỗi sau phản hồi API

Sản phẩm bàn giao:
• Form đăng ký có validation (username, email, password)
• Form đăng nhập có xử lý lỗi
• Form tạo bài viết có upload ảnh và xem trước
• Form cập nhật hồ sơ
• Component biểu mẫu tái sử dụng có TypeScript props
• Chỉ báo độ mạnh mật khẩu
• Validation schemas/rules cho biểu mẫu

Tiêu chí đánh giá:
• Triển khai React Hook Form (30%)
• Độ đầy đủ và chính xác của validation (30%)
• Trải nghiệm người dùng và thông báo lỗi (25%)
• Khả năng tái sử dụng component (15%)

3.1.4 Yêu cầu F4: Routing, Protected Routes và tính năng động (1 điểm)
Trạng thái: [x] Đã hoàn thành
Mô tả: Triển khai React Router với route bảo vệ, tải nội dung động, chức năng tìm kiếm và tối ưu hiệu năng.

Công việc cụ thể:
• Thiết lập React Router v6 với nested routes
• Triển khai protected routes yêu cầu xác thực
• Tạo route guard chuyển hướng người dùng chưa đăng nhập về trang login
• Triển khai tìm kiếm có debouncing
• Thêm pagination hoặc infinite scroll cho bảng tin bài viết
• Triển khai lazy loading cho route và hình ảnh
• Tạo loading skeleton để tăng cảm nhận hiệu năng
• Thêm thông báo thời gian thực bằng SignalR client
• Triển khai client-side caching cho dữ liệu truy cập thường xuyên

Sản phẩm bàn giao:
• Cấu hình React Router với protected routes
• Component/hook authentication guard
• Component tìm kiếm với debounced API calls
• Component pagination hoặc infinite scroll
• Các route component được lazy-load
• Loading skeleton cho bài viết, người dùng, ...
• Tích hợp SignalR cho thông báo thời gian thực

Tiêu chí đánh giá:
• Triển khai routing và cơ chế bảo vệ (30%)
• Chức năng tìm kiếm và lọc (25%)
• Tối ưu hiệu năng (25%)
• Tích hợp tính năng thời gian thực (20%)

3.2 Yêu cầu Backend (4 điểm)

3.2.1 Yêu cầu B1: Thiết kế cơ sở dữ liệu và Entity Framework (1 điểm)
Trạng thái: [x] Đã hoàn thành
Mô tả: Thiết kế và triển khai lược đồ cơ sở dữ liệu chuẩn hóa bằng Entity Framework Core với quan hệ và ràng buộc phù hợp.

Công việc cụ thể:
• Thiết kế lược đồ cơ sở dữ liệu có ít nhất 8 thực thể liên quan
• Triển khai DbContext với cấu hình phù hợp
• Tạo migration bằng Entity Framework
• Định nghĩa quan hệ (One-to-Many, Many-to-Many)
• Triển khai data annotations và Fluent API configurations
• Seed dữ liệu ban đầu để kiểm thử

Thực thể bắt buộc:
• User (AspNetUsers với Identity)
• Post
• Comment
• Like
• Friendship
• Story
• Notification
• Hashtag
• PostReport

Sản phẩm bàn giao:
• Sơ đồ cơ sở dữ liệu thể hiện quan hệ thực thể
• File entity class có annotation phù hợp
• Triển khai DbContext
• Ít nhất 3 file migration
• Cấu hình seed dữ liệu

Tiêu chí đánh giá:
• Mức độ chuẩn hóa cơ sở dữ liệu (30%)
• Định nghĩa quan hệ chính xác (30%)
• Triển khai migration (20%)
• Ràng buộc kiểm tra dữ liệu (20%)

3.2.2 Yêu cầu B2: RESTful API Controllers và DTOs (1 điểm)
Trạng thái: [x] Đã hoàn thành
Mô tả: Triển khai RESTful Web API controllers trả về JSON với HTTP methods phù hợp, DTOs (Data Transfer Objects) và tài liệu API đầy đủ.

Công việc cụ thể:
• Tạo API controllers có thuộc tính [ApiController] (AuthController, PostsController, UsersController, FriendsController, StoriesController, NotificationsController)
• Triển khai CRUD trả về JSON (không trả về view)
• Sử dụng đúng HTTP verbs và status codes (200, 201, 400, 401, 404, 500)
• Tạo DTOs/ViewModels cho dữ liệu request và response
• Triển khai model validation bằng DataAnnotations
• Cấu hình CORS cho phép request từ frontend React
• Thêm tài liệu Swagger/OpenAPI
• Chuẩn hóa định dạng API response (success, data, errors)

Sản phẩm bàn giao:
• Ít nhất 6 API controller có [ApiController] và [Route]
• Tổng cộng ít nhất 20 API endpoint
• Request DTOs và Response DTOs cho từng endpoint
• Cấu hình CORS trong Program.cs
• Swagger UI truy cập được tại endpoint /swagger
• Cấu trúc API response nhất quán
• Tài liệu API có ví dụ request/response

Tiêu chí đánh giá:
• Thiết kế RESTful API và HTTP status codes (30%)
• Triển khai DTO và validation (25%)
• CORS và cấu hình API (20%)
• Chất lượng tài liệu Swagger (15%)
• Tính nhất quán định dạng response (10%)

3.2.3 Yêu cầu B3: JWT Authentication và Authorization (1 điểm)
Trạng thái: [x] Đã hoàn thành
Mô tả: Triển khai xác thực JWT (JSON Web Token) với ASP.NET Core Identity để truy cập API an toàn từ frontend React.

Công việc cụ thể:
• Cấu hình ASP.NET Core Identity với User entity tùy chỉnh
• Triển khai tạo JWT token khi đăng nhập thành công
• Tạo API endpoints: POST /api/auth/register, POST /api/auth/login
• Cấu hình JWT authentication middleware với xác thực bearer token
• Triển khai role-based authorization (User, Admin)
• Bảo vệ API endpoint bằng [Authorize]
• Trả JWT token trong login response để lưu phía client
• Triển khai cơ chế refresh token (tùy chọn nhưng khuyến nghị)
• Thêm claims-based authorization cho dữ liệu theo người dùng

Sản phẩm bàn giao:
• AuthController có endpoint Register/Login trả JWT
• Cấu hình JWT trong Program.cs (secret key, issuer, audience, expiration)
• User entity kế thừa IdentityUser với thuộc tính mở rộng
• Seed role (User, Admin) vào cơ sở dữ liệu
• Gắn [Authorize] cho các endpoint cần bảo vệ
• Service/helper tạo JWT token
• Xác thực token và trích xuất claims

Tiêu chí đánh giá:
• Tạo và xác thực JWT (35%)
• Triển khai endpoint xác thực (30%)
• Role-based authorization (20%)
• Cấu hình bảo mật (15%)

3.2.4 Yêu cầu B4: Business Logic và tầng Services (1 điểm)
Trạng thái: [x] Đã hoàn thành
Mô tả: Triển khai service layer để tách business logic khỏi controller, tuân theo nguyên tắc SOLID.

Công việc cụ thể:
• Tạo service interfaces và implementations
• Triển khai ít nhất 5 service class (PostsService, FriendsService, ...)
• Dùng dependency injection để đăng ký service
• Triển khai repository pattern cho truy cập dữ liệu
• Thêm business logic cho tác vụ phức tạp (lời mời kết bạn, thông báo)
• Triển khai service upload tệp cho Azure Blob Storage
• Tạo helper classes và extension methods

Sản phẩm bàn giao:
• Định nghĩa service interface
• Triển khai service class
• Cấu hình dependency injection trong Program.cs
• Business logic cho các tính năng chính
• Service upload/lưu trữ tệp
• Cấu trúc code dễ unit test

Tiêu chí đánh giá:
• Tách biệt trách nhiệm (30%)
• Tuân thủ nguyên tắc SOLID (30%)
• Sử dụng dependency injection (20%)
• Tái sử dụng và bảo trì code (20%)

3.3 Yêu cầu kiểm thử (1 điểm)

3.3.1 Yêu cầu T1: Unit Testing (1 điểm)
Trạng thái: [ ] Chưa hoàn thành
Mô tả: Viết unit test cho các backend service quan trọng và frontend component để đảm bảo độ tin cậy của mã nguồn.

Công việc cụ thể:
• Tạo test project bằng xUnit hoặc NUnit
• Viết unit test cho ít nhất 3 service class
• Kiểm thử logic xác thực và phân quyền
• Mock dependencies bằng Moq hoặc framework tương tự
• Đạt tối thiểu 60% code coverage cho services
• Kiểm thử edge cases và kịch bản lỗi
• Viết integration test cho các luồng quan trọng

Sản phẩm bàn giao:
• Test project có cấu trúc phù hợp
• Ít nhất 15 unit test methods
• Báo cáo test coverage
• Test cho cả kịch bản positive và negative
• Cấu hình mock và dữ liệu kiểm thử
• Tài liệu kiểm thử

Tiêu chí đánh giá:
• Độ phủ và tính đầy đủ của kiểm thử (35%)
• Chất lượng test case và kịch bản (30%)
• Sử dụng đúng mocking framework (20%)
• Tài liệu kiểm thử (15%)

3.4 CI/CD và triển khai Cloud (1 điểm)

3.4.1 Yêu cầu D1: Triển khai Azure và pipeline CI/CD (1 điểm)
Trạng thái: [ ] Chưa hoàn thành
Mô tả: Triển khai ứng dụng lên Microsoft Azure với pipeline CI/CD tự động cho tích hợp và triển khai liên tục.

Công việc cụ thể:
• Tạo tài khoản Azure và resource group
• Triển khai ứng dụng lên Azure App Service
• Cấu hình Azure SQL Database
• Thiết lập Azure Blob Storage cho upload tệp
• Tạo CI/CD pipeline bằng Azure DevOps hoặc GitHub Actions
• Cấu hình biến môi trường và chuỗi kết nối
• Tự động build và deploy khi git push
• Thiết lập giám sát và logging cho ứng dụng

Sản phẩm bàn giao:
• URL ứng dụng hoạt động trên Azure App Service
• File cấu hình CI/CD pipeline (YAML)
• Tài liệu cấu hình tài nguyên Azure
• Hướng dẫn thiết lập connection strings và môi trường
• Log triển khai thể hiện build thành công
• Thiết lập Application Insights hoặc công cụ giám sát
• Tài liệu triển khai kèm ảnh chụp màn hình

Tiêu chí đánh giá:
• Triển khai Azure thành công (30%)
• Triển khai CI/CD pipeline (30%)
• Cấu hình môi trường (20%)
• Chất lượng tài liệu (20%)

4 Hướng dẫn nộp bài

4.1 Nội dung cần nộp
1. Mã nguồn:
• Toàn bộ solution Visual Studio (.sln)
• Tất cả project files và dependencies
• URL kho Git (GitHub/Azure Repos)
• File .gitignore (loại trừ bin, obj, packages)

2. Cơ sở dữ liệu:
• SQL script tạo cơ sở dữ liệu
• Các file migration của Entity Framework
• Script seed dữ liệu

3. Tài liệu:
• README.md mô tả tổng quan dự án
• Hướng dẫn cài đặt và chạy
• Sơ đồ cơ sở dữ liệu
• Tài liệu API hoặc danh sách endpoint
• Ảnh chụp các tính năng chính (ít nhất 10 ảnh)
• Video demo (5-10 phút, tùy chọn nhưng khuyến nghị)

4. Kiểm thử:
• Test project với đầy đủ test cases
• Báo cáo test coverage
• Kết quả chạy test

5. Triển khai:
• URL ứng dụng đang chạy
• Cấu hình CI/CD pipeline
• Tài liệu triển khai
• Danh sách tài nguyên Azure và cấu hình

4.2 Định dạng nộp bài
• Code Repository: Chia sẻ link GitHub/Azure DevOps repository để giảng viên truy cập
• Documentation: Nộp tài liệu PDF hoặc README.md được trình bày rõ ràng
• Compressed Archive: File zip chứa toàn bộ tài liệu (tối đa 50MB, loại trừ node_modules, bin, obj)
• Submission Portal: Tải lên hệ thống LMS theo yêu cầu

4.3 Chính sách nộp trễ
• Nộp đúng hạn: 100% số điểm đạt được
• Trễ 1-3 ngày: trừ 10%
• Trễ 4-7 ngày: trừ 20%
• Trễ quá 7 ngày: trừ 50%
• Không nhận bài sau 14 ngày nếu không có phê duyệt trước

5 Tóm tắt thang điểm

Hạng mục | Điểm | Tỷ trọng
Frontend - Responsive UI | 1 | 10%
Frontend - Interactive Components | 1 | 10%
Frontend - Form Validation | 1 | 10%
Frontend - Dynamic Content | 1 | 10%
Frontend Subtotal | 4 | 40%
Backend - Database và EF | 1 | 10%
Backend - RESTful API | 1 | 10%
Backend - Authentication | 1 | 10%
Backend - Business Logic | 1 | 10%
Backend Subtotal | 4 | 40%
Testing | 1 | 10%
CI/CD và Cloud Deployment | 1 | 10%
Tổng | 10 | 100%

Bảng 1: Phân bổ điểm bài tập

6 Tài nguyên tham khảo

6.1 Tài liệu chính thức
• ASP.NET Core Documentation: https://docs.microsoft.com/aspnet/core
• Entity Framework Core: https://docs.microsoft.com/ef/core
• TypeScript Documentation: https://www.typescriptlang.org/docs
• Tailwind CSS: https://tailwindcss.com/docs
• Azure App Service: https://docs.microsoft.com/azure/app-service

6.2 Công cụ khuyến nghị
• Visual Studio 2022 hoặc VS Code
• SQL Server Management Studio (SSMS)
• Postman (kiểm thử API)
• Azure Data Studio
• Git cho quản lý phiên bản

7 Liêm chính học thuật

7.1 Không được phép
• Sao chép mã từ sinh viên khác
• Nộp dự án hoàn chỉnh mua hoặc tải về
• Dùng AI tạo toàn bộ tính năng mà không hiểu nội dung
• Chia sẻ mã của bạn với sinh viên khác

7.2 Trích dẫn phù hợp
• Ghi chú trong mã để giải thích logic phức tạp
• Trích dẫn các thư viện và framework bên ngoài đã sử dụng
• Ghi rõ các đoạn mã tham khảo từ nguồn trực tuyến
• Giải thích các tích hợp bên thứ ba

Lưu ý: Đạo văn sẽ dẫn đến 0 điểm cho bài tập và có thể kéo theo các hậu quả học thuật khác.
