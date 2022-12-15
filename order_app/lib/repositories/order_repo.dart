import 'dart:convert';
import 'dart:developer';

import 'package:orderr_app/api/fetch.dart';
import 'package:orderr_app/api/host.dart';
import 'package:orderr_app/api/status_code.dart';
import 'package:orderr_app/models/order/order_create_model.dart';
import 'package:orderr_app/models/order/order_model.dart';

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

  Future<List<OrderModel>> getNewOrdersByTable(String tableId) async {
    var lstOrderModel = <OrderModel>[];
    try {
      var resp = await Fetch.GET('$controllerUrl/Table/$tableId');
      if (resp.statusCode == HttpStatusCode.OK) {
        Iterable lstClone = jsonDecode(resp.body);
        lstOrderModel = List<OrderModel>.from(
          lstClone.map((model) => OrderModel.fromJson(model)),
        );
      }
    } catch (e) {
      log(e.toString());
      throw Exception('Lỗi! Không thể tải Order theo bàn');
    }
    return lstOrderModel;
  }
}
