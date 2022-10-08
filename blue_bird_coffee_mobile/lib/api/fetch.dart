import 'dart:convert';
import 'dart:developer';
import 'package:blue_bird_coffee_mobile/utils/local_storage.dart';
import 'package:http/http.dart';

class Fetch {
  // static const String FORMBODY = "FormBody";
  // static const String FORMDATA = "FormData";

  static Future<Map<String, String>> initHeader() async {
    Map<String, String> headers = {
      'accept': '*/*',
      'content-type': 'application/json',
      'accept-encoding': 'gzip, deflate, br',
    };
    String? token = await LocalStorage.getItem("token");
    if (token != null && token.isNotEmpty) {
      headers['authorization'] = 'Bearer ' + token;
    }
    return headers;
  }

  static Future<Response> GET(url) async {
    return await get(
      Uri.parse(url),
      headers: await initHeader(),
    );
  }

  static Future<Response> POST(url, jsonData) async {
    return await post(
      Uri.parse(url),
      headers: await initHeader(),
      body: jsonEncode(jsonData),
    );
  }

  static Future<Response> PUT(url, jsonData) async {
    return await put(
      Uri.parse(url),
      headers: await initHeader(),
      body: jsonEncode(jsonData),
    );
  }
}
