import 'package:bbc_bartender_mobile/api/status_code.dart';
import 'package:http/http.dart';

class CheckApi {
  static dynamic check(
      Response resp, bool showToastSuccess, bool showToastError) {
    if (resp.statusCode == HttpStatusCode.OK) {
      return resp.body;
    }
    return "";
  }
}