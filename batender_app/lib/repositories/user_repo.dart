import 'dart:convert';
import 'dart:developer';

import 'package:bartender_app/api/fetch.dart';
import 'package:bartender_app/api/host.dart';
import 'package:bartender_app/api/status_code.dart';
import 'package:bartender_app/models/login/login_req_model.dart/login_req_model.dart';
import 'package:bartender_app/models/login/login_res_model/login_res_model.dart';
import 'package:bartender_app/models/user/user_model.dart';
import 'package:bartender_app/utils/const.dart';
import 'package:bartender_app/utils/local_storage.dart';

class UserRepo {
  static const controllerUrl = '${Host.currentHostApi}/User';

  Future<dynamic> login(LoginReqModel model) async {
    var resp = await Fetch.POST('$controllerUrl/Login', model.toJson());
    try {
      if (resp.statusCode == HttpStatusCode.OK) {
        var data = LoginResModel.fromJson(jsonDecode(resp.body));

        await LocalStorage.setItem(KeyLS.token, data.token.toString());
        await LocalStorage.setItem(KeyLS.login_info, jsonEncode(model));
        await LocalStorage.setItem(
          KeyLS.user_json,
          jsonEncode(LoginResModel(data.fullname, null, data.role)),
        );

        return data;
      } else if (resp.statusCode == HttpStatusCode.BadRequest) {
        return resp.body.toString();
      }
    } catch (e) {
      log(e.toString());
      throw Exception('Lỗi! Không thể đăng nhập');
    }
    return null;
  }

  Future<bool> checkLogin() async {
    try {
      await LocalStorage.removeItem(KeyLS.token);
      String? loginInfoJson = await LocalStorage.getItem(KeyLS.login_info);
      if (loginInfoJson != null && loginInfoJson.isNotEmpty) {
        var loReqModel = LoginReqModel.fromJson(jsonDecode(loginInfoJson));
        var resp =
            await Fetch.POST('$controllerUrl/Login', loReqModel.toJson());
        if (resp.statusCode == HttpStatusCode.OK) {
          var data = LoginResModel.fromJson(jsonDecode(resp.body));

          await LocalStorage.setItem(KeyLS.token, data.token.toString());

          await LocalStorage.setItem(
            KeyLS.user_json,
            jsonEncode(LoginResModel(data.fullname, null, data.role)),
          );

          return true;
        } else if (resp.statusCode == HttpStatusCode.BadRequest) {
          return false;
        }
      }
    } catch (e) {
      log(e.toString());
      throw Exception('Lỗi! Không thể đăng nhập');
    }
    return false;
  }

  Future logout() async {
    await LocalStorage.removeAll();
  }

  Future<dynamic> updateInfo(UserModel model) async {
    try {
      var resp = await Fetch.PUT('$controllerUrl/Info', model.toJson());
      if (resp.statusCode == HttpStatusCode.OK) {
        LoginResModel? user;
        String? userJson = await LocalStorage.getItem(KeyLS.user_json);
        if (userJson != null && userJson.isNotEmpty) {
          user = LoginResModel.fromJson(jsonDecode(userJson));
          user.fullname = model.fullname;
        } else {
          user = LoginResModel(model.fullname, null, null);
        }
        await LocalStorage.setItem(KeyLS.user_json, jsonEncode(user));

        return resp.body.isNotEmpty;
      } else if (resp.statusCode == HttpStatusCode.BadRequest) {
        return resp.body.toString();
      }
    } catch (e) {
      log(e.toString());
      throw Exception('Lỗi! Không thể cập nhật thông tin');
    }
    return false;
  }

  Future<dynamic> updatePassword(UserModel model) async {
    try {
      var resp = await Fetch.PUT('$controllerUrl/Password', model.toJson());
      if (resp.statusCode == HttpStatusCode.OK) {
        return resp.body.isNotEmpty;
      } else if (resp.statusCode == HttpStatusCode.BadRequest) {
        return resp.body.toString();
      }
    } catch (e) {
      log(e.toString());
      throw Exception('Lỗi! Không thể đổi mật khẩu');
    }
    return false;
  }
}
