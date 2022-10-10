import 'dart:convert';
import 'dart:developer';

import 'package:blue_bird_coffee_mobile/api/fetch.dart';
import 'package:blue_bird_coffee_mobile/api/host.dart';
import 'package:blue_bird_coffee_mobile/api/status_code.dart';
import 'package:blue_bird_coffee_mobile/models/login/login_req_model.dart/login_req_model.dart';
import 'package:blue_bird_coffee_mobile/models/login/login_res_model/login_res_model.dart';
import 'package:blue_bird_coffee_mobile/utils/const.dart';
import 'package:blue_bird_coffee_mobile/utils/local_storage.dart';

class UserRepo {
  static const controllerUrl = '${Host.currentHost}/User';

  Future<dynamic> login(LoginReqModel model) async {
    var resp = await Fetch.POST('${controllerUrl}/Login', model.toJson());
    try {
      if (resp.statusCode == HttpStatusCode.OK) {
        var data = LoginResModel.fromJson(jsonDecode(resp.body));

        await LocalStorage.setItem(KeyLS.token, data.token.toString());
        await LocalStorage.setItem(KeyLS.login_info, jsonEncode(model));
        await LocalStorage.setItem(
          KeyLS.login_resp,
          jsonEncode(LoginResModel(data.fullName, null, data.role)),
        );

        return data;
      } else if (resp.statusCode == HttpStatusCode.BadRequest) {
        return resp.body.toString();
      }
    } catch (e) {
      log(e.toString());
    }
    return null;
  }

  Future<bool> checkLogin() async {
    await LocalStorage.removeItem(KeyLS.token);
    String? loginInfoJson = await LocalStorage.getItem(KeyLS.login_info);
    if (loginInfoJson != null && loginInfoJson.isNotEmpty) {
      return true;
      // LoginReqModel loReqModel =
      //     LoginReqModel.fromJson(jsonDecode(loginInfoJson));
      // var resp = await login(loReqModel);
      // if (!(resp is String)) {
      //   return true;
      // }
    }
    return false;
  }

  static Future logout() async {
    await LocalStorage.removeAll();
  }
}
