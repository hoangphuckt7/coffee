import 'dart:convert';
import 'dart:developer';

import 'package:bbc_bartender_mobile/api/fetch.dart';
import 'package:bbc_bartender_mobile/api/host.dart';
import 'package:bbc_bartender_mobile/api/status_code.dart';
import 'package:bbc_bartender_mobile/models/common/base_model.dart';

class FloorRepo {
  static const controllerUrl = '${Host.currentHostApi}/Floor';

  Future<List<BaseModel>> getAll() async {
    var lstFloorModel = <BaseModel>[];
    try {
      var resp = await Fetch.GET(controllerUrl);
      if (resp.statusCode == HttpStatusCode.OK) {
        Iterable lstClone = jsonDecode(resp.body);
        lstFloorModel = List<BaseModel>.from(
          lstClone.map((model) => BaseModel.fromJson(model)),
        );
      }
    } catch (e) {
      log('lỗi');
      log(e.toString());
    }
    return lstFloorModel;
  }
}
