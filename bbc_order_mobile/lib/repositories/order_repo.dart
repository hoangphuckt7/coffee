import 'dart:convert';
import 'dart:developer';

import 'package:bbc_order_mobile/api/fetch.dart';
import 'package:bbc_order_mobile/api/host.dart';
import 'package:bbc_order_mobile/api/status_code.dart';
import 'package:bbc_order_mobile/models/order/order_create_model.dart';

class OrderRepo {
  static const controllerUrl = '${Host.currentHostApi}/Order';

  Future<dynamic> create(OrderCreateModel order) async {
    try {
      var resp = await Fetch.POST(controllerUrl, order);
      if (resp.statusCode == HttpStatusCode.OK) {
        return resp.body.isNotEmpty;
      } else if (resp.statusCode == HttpStatusCode.BadRequest) {
        return resp.body.toString();
      }
    } catch (e) {
      log(e.toString());
      throw Exception('Lỗi! Order thất bại');
    }
    return false;
  }
}
