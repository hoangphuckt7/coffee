class Validations {
  static String validUsername(String? username) {
    if (username == null || username.isEmpty || username.length <= 0) {
      return 'Tên đăng nhập không được trống!';
    }
    return '';
  }

  static String validPassword(String? password) {
    if (password == null || password.isEmpty || password.length <= 0) {
      return "Mật khẩu không được trống!";
    } else if (password.length > 0 && password.length < 6) {
      return 'Mật khẩu tối thiểu 6 ký tự';
    }
    return '';
  }
}
