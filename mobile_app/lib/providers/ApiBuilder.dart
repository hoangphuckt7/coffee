// ignore: file_names
import 'dart:async';
import 'dart:convert';
// ignore: depend_on_referenced_packages
import 'package:http/http.dart' as http;
// ignore: depend_on_referenced_packages
import 'package:flutter_dotenv/flutter_dotenv.dart';
import 'package:mobile_app/utilities/AppException.dart';

Future fetch(path, data) async {
  // ignore: unnecessary_brace_in_string_interps
  var uri = '${dotenv.env['HOST']}${path}';
  final response = await http.post(
    Uri.parse(uri),
    headers: <String, String>{
      'content-type': 'application/json',
    },
    body: jsonEncode(data.toJson()),
  );
  if (response.statusCode == 200) {
    // return LoginModel.fromJson(jsonDecode(response.body));
  } else {
    throw AppException(response.body.toString());
  }
}
