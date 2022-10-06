import 'dart:convert';
import 'dart:developer';
import 'package:blue_bird_coffee_mobile/utils/local_storage.dart';
import 'package:http/http.dart' as http;

class Fetch {
  static const String FORMBODY = "FormBody";
  static const String FORMDATA = "FormData";
  // static Dio dio = Dio();
  static Future<Map<String, String>> addHeader(
      {bool isFormData = false}) async {
    String token = await LocalStorage.getItem("token");
    return {
      'Accept': '*/*',
      'Content-Type': !isFormData ? 'application/json;' : '',
      'Accept-Encoding': 'gzip, deflate, br',
      'Authorization': 'Bearer ' + token,
    };
  }

  static Future<http.Response> get(url) async {
    log(url);
    var resp = await http.get(Uri.parse(url)
        // headers: await addHeader(),
        );
    return resp;
  }

  static Future<http.Response> post(url, data) async {
    var resp = await http.post(
      Uri.parse(url),
      headers: await addHeader(),
      body: jsonEncode(data),
    );
    return resp;
  }
}
