// ignore_for_file: non_constant_identifier_names

import 'dart:convert';
import 'dart:developer';
import 'package:bbc_order_mobile/utils/local_storage.dart';
import 'package:http/http.dart';

class Fetch {
  static Future<Map<String, String>> _initHeader() async {
    Map<String, String> headers = {
      'accept': '*/*',
      'content-type': 'application/json',
      'accept-encoding': 'gzip, deflate, br',
    };
    String? token = await LocalStorage.getItem("token");
    if (token != null && token.isNotEmpty) {
      headers['authorization'] = 'Bearer $token';
    }
    return headers;
  }

  static Future<Response> GET(url) async {
    log(url);
    return await get(
      Uri.parse(url),
      headers: await _initHeader(),
    );
  }

  static Future<Response> POST(url, jsonData) async {
    log(url);
    dynamic body;
    if (jsonData != null) {
      body = jsonEncode(jsonData);
    }
    log('body: $body');
    return await post(
      Uri.parse(url),
      headers: await _initHeader(),
      body: body,
    );
  }

  static Future<Response> PUT(url, jsonData) async {
    log(url);
    dynamic body;
    if (jsonData != null) {
      body = jsonEncode(jsonData);
    }
    log('body: $body');
    return await put(
      Uri.parse(url),
      headers: await _initHeader(),
      body: body,
    );
  }
}
