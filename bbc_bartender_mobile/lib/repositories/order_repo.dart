import 'dart:convert';
import 'dart:developer';

import 'package:bbc_bartender_mobile/api/fetch.dart';
import 'package:bbc_bartender_mobile/api/host.dart';
import 'package:bbc_bartender_mobile/api/status_code.dart';
import 'package:bbc_bartender_mobile/models/order/order_model.dart';

class OrderRepo {
  static const controllerUrl = '${Host.currentHost}/Order';

  Future<List<OrderModel>> getCurrentOrders() async {
    var lstOrderModel = <OrderModel>[];
    try {
      var resp = await Fetch.GET('${controllerUrl}/CurrentOrders');
      if (resp.statusCode == HttpStatusCode.OK) {
        Iterable lstClone = jsonDecode(resp.body);
        lstOrderModel = List<OrderModel>.from(
          lstClone.map((model) => OrderModel.fromJson(model)),
        );
      }
    } catch (e) {
      log('lỗi');
      log(e.toString());
    }
    return lstOrderModel;
  }

  Future<String?> complete(String? id) async {
    try {
      var resp = await Fetch.PUT('${controllerUrl}/Complete/${id}', null);
      if (resp.statusCode == HttpStatusCode.OK) {
        return resp.body.toString();
      }
    } catch (e) {
      log('lỗi');
      log(e.toString());
    }
    return null;
  }

  Future<String?> uncomplete(String? id) async {
    try {
      var resp = await Fetch.PUT('${controllerUrl}/UnComplete/${id}', null);
      if (resp.statusCode == HttpStatusCode.OK) {
        return resp.body.toString();
      }
    } catch (e) {
      log('lỗi');
      log(e.toString());
    }
    return null;
  }
}
