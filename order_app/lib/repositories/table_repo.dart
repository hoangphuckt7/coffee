import 'dart:convert';
import 'dart:developer';
import 'package:orderr_app/api/fetch.dart';
import 'package:orderr_app/api/host.dart';
import 'package:orderr_app/api/status_code.dart';
import 'package:orderr_app/models/table/table_model.dart';
import 'package:orderr_app/utils/const.dart';
import 'package:orderr_app/utils/local_storage.dart';

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
      var resp = await Fetch.PUT(
          '$controllerUrl/Change/$tableIdOld/$tableIdNew', null);
      if (resp.statusCode == HttpStatusCode.OK) {
        return resp.body.isNotEmpty;
      } else if (resp.statusCode == HttpStatusCode.BadRequest) {
        return resp.body.toString();
      }
    } catch (e) {
      log(e.toString());
      throw Exception('Lỗi! Chuyển / Gộp bàn thất bại');
    }
    return false;
  }

  Future<List<TableModel>> fetchListTable() async {
    bool isCallApi = true;
    List<TableModel> lstTable = <TableModel>[];

    String? tableJson = await LocalStorage.getItem(KeyLS.tables);
    if (tableJson != null && tableJson.isNotEmpty) {
      lstTable = List<TableModel>.from(
        jsonDecode(tableJson).map((model) => TableModel.fromJson(model)),
      );
      isCallApi = lstTable.isEmpty;
    }

    if (isCallApi) {
      lstTable = await getAll();
      await LocalStorage.setItem(KeyLS.tables, jsonEncode(lstTable));
    }

    return lstTable;
  }
}
