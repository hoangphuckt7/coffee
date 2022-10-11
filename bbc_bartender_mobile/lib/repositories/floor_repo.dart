import 'dart:convert';
import 'dart:developer';

import 'package:bbc_bartender_mobile/api/fetch.dart';
import 'package:bbc_bartender_mobile/api/host.dart';
import 'package:bbc_bartender_mobile/api/status_code.dart';
import 'package:bbc_bartender_mobile/models/floor/floor_model.dart';

class FloorRepo {
  static const controllerUrl = '${Host.currentHost}/Floor';

  Future<List<FloorModel>> getAll() async {
    var lstFloorModel = <FloorModel>[];
    try {
      var resp = await Fetch.GET('${controllerUrl}');
      if (resp.statusCode == HttpStatusCode.OK) {
        Iterable lstClone = jsonDecode(resp.body);
        lstFloorModel = List<FloorModel>.from(
          lstClone.map((model) => FloorModel.fromJson(model)),
        );
      }
    } catch (e) {
      log('lỗi');
      log(e.toString());
    }
    return lstFloorModel;
  }
}
