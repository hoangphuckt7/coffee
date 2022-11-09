import 'dart:convert';
import 'dart:developer';
import 'package:bbc_order_mobile/api/fetch.dart';
import 'package:bbc_order_mobile/api/host.dart';
import 'package:bbc_order_mobile/api/status_code.dart';
import 'package:bbc_order_mobile/models/table/table_model.dart';

class TableRepo {
  static const controllerUrl = '${Host.currentHostApi}/Table';

  Future<List<TableModel>> getAll() async {
    var lstTableModel = <TableModel>[];
    try {
      var resp = await Fetch.GET(controllerUrl);
      if (resp.statusCode == HttpStatusCode.OK) {
        Iterable lstClone = jsonDecode(resp.body);
        lstTableModel = List<TableModel>.from(
          lstClone.map((model) => TableModel.fromJson(model)),
        );
      }
    } catch (e) {
      log('TableRepo - lỗi - ${e.toString()}');
    }
    return lstTableModel;
  }

  Future<dynamic> changeTable(String tableIdOld, String tableIdNew) async {
    try {
      var resp = await Fetch.POST(controllerUrl, null);
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
