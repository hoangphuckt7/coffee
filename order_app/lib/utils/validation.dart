class Validations {
  static String? validUsername(String? username) {
    if (username == null || username.isEmpty || username.isEmpty) {
      return 'Tên đăng nhập không được trống!';
    }
    return null;
  }

  static String? validPassword(String? password) {
    if (password == null || password.isEmpty || password.isEmpty) {
      return "Mật khẩu không được trống!";
    }
    return null;
  }
}
