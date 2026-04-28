# Cần cài đặt để hoàn thành đồ án InteractHub

Dưới đây là danh sách những thứ cần cài đặt hoặc chuẩn bị theo yêu cầu đồ án và theo đúng cấu trúc project hiện tại.

## 1. Bắt buộc để chạy project local

### 1.1 .NET SDK
- [x] `.NET SDK 10.0` vì backend hiện tại đang target `net10.0`.
- Dùng để chạy API ASP.NET Core, Entity Framework Core, migration và Swagger.

### 1.2 Node.js và npm
- [x] Node.js bản LTS hiện đại, kèm theo `npm`.
- Dùng để chạy frontend React + Vite.

### 1.3 SQL Server
- [x] SQL Server local hoặc dùng SQL Server Express/Developer.
- Đây là database chính của backend theo chuỗi kết nối trong `backend/appsettings.json`.

### 1.4 SQL Server Management Studio hoặc công cụ quản lý DB
- [ ] SSMS hoặc Azure Data Studio.
- Dùng để xem database, kiểm tra bảng, seed data và debug lỗi kết nối.

## 2. Bắt buộc để phát triển đúng yêu cầu đồ án

### 2.1 Visual Studio Code hoặc Visual Studio
- [x] Visual Studio Code hoặc Visual Studio.
- Dùng để chỉnh sửa mã nguồn frontend và backend.
- Nếu dùng Visual Studio, nên cài workload ASP.NET and web development.

### 2.2 Extension C#
- [ ] C# Dev Kit hoặc C# extension trong VS Code.
- Hỗ trợ IntelliSense, debug và làm việc với project .NET.

### 2.3 Extension TypeScript/React nếu dùng VS Code
- [ ] Extension TypeScript/React nếu dùng VS Code.
- Dùng để hỗ trợ code frontend React + TypeScript.

## 3. Cần có để làm đúng các phần bắt buộc của đề

### 3.1 Entity Framework Core tools
- [x] `dotnet-ef` để tạo và cập nhật migration.
- Lệnh cài nếu máy chưa có: `dotnet tool install --global dotnet-ef`.

### 3.2 Git
- [x] Git để quản lý source code, nộp bài và làm CI/CD.

### 3.3 Tài khoản GitHub
- [ ] Tài khoản GitHub để đẩy code lên repo và thiết lập GitHub Actions nếu dùng CI/CD.

### 3.4 Tài khoản Microsoft Azure
- [ ] Tài khoản Microsoft Azure cho phần deploy lên Azure App Service, Azure SQL Database và Azure Blob Storage.

## 4. Nên chuẩn bị thêm để làm đủ yêu cầu bài

### 4.1 Postman hoặc Insomnia
- [ ] Postman hoặc Insomnia để test API login, register, posts, friends, notifications.

### 4.2 Swagger UI
- [x] Không cần cài riêng, backend đã có Swagger.
- Dùng để test API trực tiếp tại `/swagger` sau khi chạy backend.

### 4.3 Trình duyệt hiện đại
- [x] Trình duyệt hiện đại để chạy frontend và kiểm tra UI responsive.

### 4.4 Công cụ chụp màn hình
- [ ] Công cụ chụp màn hình để lấy ảnh minh chứng cho báo cáo đồ án.

## 5. Ghi chú theo project hiện tại

- Backend hiện tại chạy với URL local là `http://localhost:5052`.
- Frontend chạy với URL local là `http://localhost:5173`.
- Backend đang có cấu hình SQL Server trong `backend/appsettings.json`.
- Project backend hiện target `net10.0`, nên nếu máy chỉ có .NET 8 thì nên cài thêm .NET 10 để chạy đúng.

## 6. Checklist ngắn

1. [x] `.NET SDK 10.0`
2. [x] `Node.js` + `npm`
3. [x] `SQL Server`
4. [ ] `SSMS` hoặc `Azure Data Studio`
5. [x] `VS Code` hoặc `Visual Studio`
6. [ ] `C# Dev Kit` / `C# extension`
7. [x] `dotnet-ef`
8. [x] `Git`
9. [ ] `GitHub account`
10. [ ] `Azure account`
11. [ ] `Postman`

## 7. Nếu chỉ muốn chạy demo trên máy

- Chỉ cần cài đủ `.NET SDK 10.0`, `Node.js`, `npm`, và `SQL Server`.
- Các phần `GitHub Actions`, `Azure`, `Blob Storage` chỉ cần khi làm phần deploy và báo cáo hoàn chỉnh.

## 8. Toàn bộ stack yêu cầu của đề

Phần này liệt kê đầy đủ các công nghệ mà đề bài yêu cầu, để bạn đối chiếu khi làm báo cáo hoặc chuẩn bị môi trường.

Lưu ý: đây là danh sách yêu cầu của đề, không phải checklist cài đặt trên máy.

### 8.1 Frontend
- React 18+ với TypeScript
- TypeScript bật `strict mode`
- Tailwind CSS
- React Context API hoặc Redux Toolkit
- React Router v6+
- Axios hoặc Fetch API
- Vite hoặc Create React App
- React Hook Form
- React Query là tùy chọn

### 8.2 Backend
- ASP.NET Core 8.0 Web API hoặc cao hơn
- RESTful API theo kiến trúc Repository và Service
- Entity Framework Core 8.0+
- SQL Server
- ASP.NET Core Identity
- JWT authentication
- Role-based và Policy-based authorization
- Swagger/OpenAPI
- CORS cho frontend React
- SignalR cho thông báo thời gian thực

### 8.3 Cloud và DevOps
- Microsoft Azure
- Azure DevOps hoặc GitHub Actions
- Azure Blob Storage cho hình ảnh

### 8.4 Công cụ hỗ trợ nên có
- Git
- Visual Studio Code hoặc Visual Studio
- C# Dev Kit hoặc C# extension
- dotnet-ef
- Postman hoặc Insomnia
- SSMS hoặc Azure Data Studio

### 8.5 Ghi chú quan trọng
- File này nên dùng như checklist cài đặt và checklist công nghệ cần có.
- Nếu mục tiêu là làm đúng yêu cầu đồ án, bạn nên bảo đảm toàn bộ stack ở trên đều có mặt trong môi trường hoặc trong mã nguồn, ngay cả khi không phải tất cả đều cần cài riêng trên máy local.

## 9. Hướng dẫn cài đầy đủ theo thứ tự

Nếu bạn muốn chuẩn bị đầy đủ từ đầu trên Windows, làm theo thứ tự này để tránh lỗi dây chuyền.

### Bước 1: Cài .NET SDK 10.0
- Tải và cài .NET SDK 10.0 từ trang chính thức của Microsoft.
- Sau khi cài xong, mở PowerShell và kiểm tra:

```powershell
dotnet --list-sdks
```

### Bước 2: Cài Node.js LTS
- Tải bản LTS mới nhất của Node.js.
- Kiểm tra sau khi cài:

```powershell
node -v
npm -v
```

### Bước 3: Cài SQL Server
- Cài SQL Server Developer hoặc SQL Server Express.
- Nếu chưa quen cấu hình, nên dùng SQL Server Developer cho đủ tính năng.
- Ghi nhớ tên instance nếu có, vì backend dùng chuỗi kết nối trong `backend/appsettings.json`.

### Bước 4: Cài SSMS hoặc Azure Data Studio
- Dùng để quản lý database, kiểm tra bảng, chạy query và debug migration.

### Bước 5: Cài Git
- Dùng để quản lý mã nguồn và làm CI/CD.
- Kiểm tra:

```powershell
git --version
```

### Bước 6: Cài Visual Studio Code hoặc Visual Studio
- Nếu dùng VS Code, cài thêm C# Dev Kit và extension TypeScript/React.
- Nếu dùng Visual Studio, chọn workload `ASP.NET and web development`.

### Bước 7: Cài dotnet-ef
- Cần cho migration Entity Framework Core.
- Cài bằng:

```powershell
dotnet tool install --global dotnet-ef
```

- Kiểm tra:

```powershell
dotnet ef --version
```

### Bước 8: Cài Postman hoặc Insomnia
- Dùng để test API backend nhanh hơn trình duyệt.

### Bước 9: Tạo hoặc đăng nhập tài khoản GitHub
- Dùng cho push code và thiết lập GitHub Actions nếu làm CI/CD.

### Bước 10: Tạo hoặc đăng nhập tài khoản Azure
- Cần cho App Service, Azure SQL và Blob Storage.
- Nếu có thể, cài thêm Azure CLI để thao tác dễ hơn, nhưng không bắt buộc cho chạy local.

### Bước 11: Cài các package của project

Sau khi cài xong môi trường, vào từng thư mục để cài dependencies:

```powershell
cd "d:\SGU Nam 3 HK2\C\fake\Si_Sap_InteractHub-main\backend"
dotnet restore

cd "d:\SGU Nam 3 HK2\C\fake\Si_Sap_InteractHub-main\frontend"
npm install
```

### Bước 12: Chạy và kiểm tra

Backend:

```powershell
cd "d:\SGU Nam 3 HK2\C\fake\Si_Sap_InteractHub-main\backend"
dotnet ef database update
dotnet run
```

Frontend:

```powershell
cd "d:\SGU Nam 3 HK2\C\fake\Si_Sap_InteractHub-main\frontend"
npm run dev
```

### Bước 13: Mở đường dẫn kiểm tra
- Frontend: `http://localhost:5173`
- Backend / Swagger: `http://localhost:5052/swagger`

## 10. Nếu máy đã có sẵn một phần

- Nếu đã có `.NET SDK`, chỉ cần kiểm tra version có phải 10.0 hay không.
- Nếu đã có Node.js, chỉ cần đảm bảo có `npm`.
- Nếu đã có SQL Server, chỉ cần đảm bảo service đang chạy và connection string đúng.
- Nếu đã có `dotnet-ef`, không cần cài lại.
