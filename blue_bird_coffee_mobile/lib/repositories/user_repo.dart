import 'dart:convert';
import 'dart:developer';

import 'package:blue_bird_coffee_mobile/api/fetch.dart';
import 'package:blue_bird_coffee_mobile/api/host.dart';
import 'package:blue_bird_coffee_mobile/api/status_code.dart';
import 'package:blue_bird_coffee_mobile/models/login/login_req_model.dart/login_req_model.dart';
import 'package:blue_bird_coffee_mobile/models/login/login_res_model/login_res_model.dart';

class UserRepo {
  static const controllerUrl = '${Host.currentHost}/User';

  static Future<LoginResModel?> login(LoginReqModel model) async {
    var resp = await Fetch.POST('${controllerUrl}/Login', model.toJson());
    if (resp.statusCode == HttpStatusCode.OK) {
      if (resp.body is LoginReqModel) {
        return LoginResModel.fromJson(jsonDecode(resp.body));
      } else if (resp.body is String) {
        throw Exception(resp.body.toString());
      }
    }
    return null;
  }
}
