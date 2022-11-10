import 'dart:convert';
import 'dart:developer';

import 'package:bartender_app/api/fetch.dart';
import 'package:bartender_app/api/host.dart';
import 'package:bartender_app/api/status_code.dart';
import 'package:bartender_app/models/order/bartender_order_model.dart';

class OrderRepo {
  static const controllerUrl = '${Host.currentHostApi}/Order';

  Future<BartenderOrderModel?> getBartenderOrders() async {
    try {
      var resp = await Fetch.GET('$controllerUrl/BartenderOrders');
      if (resp.statusCode == HttpStatusCode.OK) {
        // log('resp: ${resp.body}');
        return BartenderOrderModel.fromJson(jsonDecode(resp.body));
      }
    } catch (e) {
      log(e.toString());
      throw Exception('Lỗi! Không thể tải Order');
    }
    return null;
  }

  Future<String?> complete(String? id) async {
    try {
      var resp = await Fetch.PUT('$controllerUrl/Complete/$id', null);
      if (resp.statusCode == HttpStatusCode.OK) {
        return resp.body.toString();
      }
    } catch (e) {
      log(e.toString());
      throw Exception('Lỗi! Không thể hoàn thành Order');
    }
    return null;
  }

  Future<String?> uncomplete(String? id) async {
    try {
      var resp = await Fetch.PUT('$controllerUrl/UnComplete/$id', null);
      if (resp.statusCode == HttpStatusCode.OK) {
        return resp.body.toString();
      }
    } catch (e) {
      log(e.toString());
      throw Exception('Lỗi! Không thể hoàn tác Order');
    }
    return null;
  }
}
