import 'dart:convert';
import 'dart:developer';

import 'package:bbc_bartender_mobile/api/fetch.dart';
import 'package:bbc_bartender_mobile/api/host.dart';
import 'package:bbc_bartender_mobile/api/status_code.dart';
import 'package:bbc_bartender_mobile/models/login/login_req_model.dart/login_req_model.dart';
import 'package:bbc_bartender_mobile/models/login/login_res_model/login_res_model.dart';
import 'package:bbc_bartender_mobile/utils/const.dart';
import 'package:bbc_bartender_mobile/utils/local_storage.dart';

class UserRepo {
  static const controllerUrl = '${Host.currentHost}/User';

  Future<dynamic> login(LoginReqModel model) async {
    var resp = await Fetch.POST('${controllerUrl}/Login', model.toJson());
    print(resp);
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
    try {
      await LocalStorage.removeItem(KeyLS.token);
      String? loginInfoJson = await LocalStorage.getItem(KeyLS.login_info);
      if (loginInfoJson != null && loginInfoJson.isNotEmpty) {
        log('alo - ' + loginInfoJson);
        var loReqModel = LoginReqModel.fromJson(jsonDecode(loginInfoJson));
        var resp =
            await Fetch.POST('${controllerUrl}/Login', loReqModel.toJson());
        log(resp.statusCode.toString());
        log('message');
        if (resp.statusCode == HttpStatusCode.OK) {
          var data = LoginResModel.fromJson(jsonDecode(resp.body));

          await LocalStorage.setItem(KeyLS.token, data.token.toString());
          await LocalStorage.setItem(
            KeyLS.login_resp,
            jsonEncode(LoginResModel(data.fullName, null, data.role)),
          );

          return true;
        } else if (resp.statusCode == HttpStatusCode.BadRequest) {
          return false;
        }
      }
    } catch (e) {
      log(e.toString());
    }
    return false;
  }

  static Future logout() async {
    await LocalStorage.removeAll();
  }
}
