import 'package:http/http.dart';

class CheckApi {
  static dynamic check(Response resp, bool toastSuccess, toastError) {
    if (resp.statusCode == 200) {
      return resp.body;
    }
    return "";
  }
}
