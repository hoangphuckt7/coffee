import 'dart:convert';
import 'dart:developer';

import 'package:bbc_bartender_mobile/api/fetch.dart';
import 'package:bbc_bartender_mobile/api/host.dart';
import 'package:bbc_bartender_mobile/api/status_code.dart';
import 'package:bbc_bartender_mobile/models/Item/Item_model.dart';

class ItemRepo {
  static const controllerUrl = '${Host.currentHost}/Item';

  Future<List<ItemModel>> getAll() async {
    var lstItemModel = <ItemModel>[];
    try {
      var resp = await Fetch.GET('${controllerUrl}');
      if (resp.statusCode == HttpStatusCode.OK) {
        Iterable lstClone = jsonDecode(resp.body);
        lstItemModel = List<ItemModel>.from(
          lstClone.map((model) => ItemModel.fromJson(model)),
        );
      }
    } catch (e) {
      log('lỗi');
      log(e.toString());
    }
    return lstItemModel;
  }
}
