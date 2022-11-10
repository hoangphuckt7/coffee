// ignore_for_file: constant_identifier_names

class AppInfo {
  static const String Name = "Order";
  static const List<String> Roles = ["ADMIN", "BARTENDER"];
  static const int IncreaseStep = 25;
  static const int DecreaseStep = -25;
  static const String ErrMsg = 'Đã xảy ra lỗi!';
}

// LS = Local Storage
class KeyLS {
  static const String token = "token";
  static const String user_json = "user_json";
  static const String login_info = "login_info";
  static const String login_resp = "login_resp";
  static const String cates = "cates";
  static const String items = "items";
  static const String tables = "tables";
  static const String floors = "floors";
}
