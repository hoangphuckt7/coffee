import 'dart:convert';
import 'dart:developer';

import 'package:bbc_order_mobile/api/fetch.dart';
import 'package:bbc_order_mobile/api/host.dart';
import 'package:bbc_order_mobile/api/status_code.dart';
import 'package:bbc_order_mobile/models/order/bartender_order_model.dart';
import 'package:bbc_order_mobile/models/order/order_model.dart';

class OrderRepo {
  static const controllerUrl = '${Host.currentHostApi}/Order';

  Future<List<OrderModel>> getCurrentOrders() async {
    var lstOrderModel = <OrderModel>[];
    try {
      var resp = await Fetch.GET('$controllerUrl/CurrentOrders');
      if (resp.statusCode == HttpStatusCode.OK) {
        Iterable lstClone = jsonDecode(resp.body);
        lstOrderModel = List<OrderModel>.from(
          lstClone.map((model) => OrderModel.fromJson(model)),
        );
      }
    } catch (e) {
      log(e.toString());
      throw Exception('Lỗi! Không thể tải Order');
    }
    return lstOrderModel;
  }

  Future<List<OrderModel>> getTodayCompleteOrders() async {
    var lstOrderModel = <OrderModel>[];
    try {
      var resp = await Fetch.GET('$controllerUrl/TodayCompletedOrders');
      if (resp.statusCode == HttpStatusCode.OK) {
        Iterable lstClone = jsonDecode(resp.body);
        lstOrderModel = List<OrderModel>.from(
          lstClone.map((model) => OrderModel.fromJson(model)),
        );
      }
    } catch (e) {
      log(e.toString());
      throw Exception('Lỗi! Không thể tải Order');
    }
    return lstOrderModel;
  }

  Future<BartenderOrderModel?> getBartenderOrders() async {
    try {
      var resp = await Fetch.GET('$controllerUrl/BartenderOrders');
      if (resp.statusCode == HttpStatusCode.OK) {
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
