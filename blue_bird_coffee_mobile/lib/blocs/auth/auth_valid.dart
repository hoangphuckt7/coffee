import 'dart:async';

class AuthValid {
  var _userStreamController = new StreamController();
  var _passStreamController = new StreamController();

  Stream get userStream => _userStreamController.stream;
  Stream get passStream => _passStreamController.stream;

  bool isValid(String? username, String? password) {
    if (username == null || username.isEmpty) {
      _userStreamController.sink.addError("Tên tài khoản không được trống!");
      return false;
    }
    if (password == null || password.isEmpty) {
      _userStreamController.sink.addError("Tên tài khoản không được trống!");
      return false;
    }

    return true;
  }
}
