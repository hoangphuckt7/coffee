import 'dart:convert';
import 'dart:developer';

import 'package:orderr_app/api/fetch.dart';
import 'package:orderr_app/api/host.dart';
import 'package:orderr_app/api/status_code.dart';
import 'package:orderr_app/models/common/base_model.dart';

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
      log('FloorRepo - lỗi');
      log(e.toString());
    }
    return lstFloorModel;
  }
}
