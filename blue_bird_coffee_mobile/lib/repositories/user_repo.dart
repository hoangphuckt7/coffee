import 'dart:convert';

import 'package:blue_bird_coffee_mobile/api/fetch.dart';
import 'package:blue_bird_coffee_mobile/api/status_code.dart';
import 'package:blue_bird_coffee_mobile/models/login_res_model/login_res_model.dart';

class UserRepo {
  static Future<LoginResModel?> login({username, password}) async {
    var resp = await Fetch.post('/login', {username, password});
    if (resp.statusCode == HttpStatusCode.OK) {
      return LoginResModel.fromJson(jsonDecode(resp.body));
    }
    return null;
  }
}
