# Lỗi chưa fix

## Lỗi 1: Vẫn bắt buộc cả content và ảnh

**Cần info cụ thể:**
- Khi bạn gõ **chỉ text** (không upload ảnh) rồi click "Đăng", chuyện gì xảy ra? 
- Khi bạn **chỉ upload ảnh** (không gõ text) rồi click "Đăng", chuyện gì xảy ra?
- Lỗi hiện lên là gì cụ thể? (error message, hoặc nút không click được, hoặc form không submit?)

**Code hiện tại:**
- Form chỉ block submit khi cả content và images đều rỗng
- Validator: `if (!trimmedContent && images.length === 0)`
- Backend: chỉ reject nếu cả content và imageUrl đều empty

**Cần xác nhận:**
1. Lỗi ở frontend (form không submit) hay backend (API reject)?
2. Error message cụ thể là gì?
