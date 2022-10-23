import 'dart:convert';
import 'dart:developer';

import 'package:bbc_bartender_mobile/api/fetch.dart';
import 'package:bbc_bartender_mobile/api/host.dart';
import 'package:bbc_bartender_mobile/api/status_code.dart';
import 'package:bbc_bartender_mobile/models/item/item_model.dart';
import 'package:bbc_bartender_mobile/utils/const.dart';
import 'package:bbc_bartender_mobile/utils/local_storage.dart';

class ItemRepo {
  static const controllerUrl = '${Host.currentHostApi}/Item';

  static getImg(id) {
    log('$controllerUrl/Image/$id');
    return '$controllerUrl/Image/$id';
  }

  Future<List<ItemModel>> getAll() async {
    var lstItemModel = <ItemModel>[];
    try {
      var resp = await Fetch.GET(controllerUrl);
      if (resp.statusCode == HttpStatusCode.OK) {
        Iterable lstClone = jsonDecode(resp.body);
        lstItemModel = List<ItemModel>.from(
          lstClone.map((model) => ItemModel.fromJson(model)),
        );
        if (lstItemModel.isNotEmpty) {
          await LocalStorage.setItem(KeyLS.items, resp.body);
        }
      }
    } catch (e) {
      log(e.toString());
      throw Exception('Lỗi! Không thể tải Menu');
    }
    return lstItemModel;
  }

  Future<bool> fetchAllToLocalStorage() async {
    var result = false;
    try {
      var resp = await Fetch.GET(controllerUrl);
      if (resp.statusCode == HttpStatusCode.OK) {
        if (resp.body.isNotEmpty) {
          await LocalStorage.setItem(KeyLS.items, resp.body);
          result = true;
        }
      }
    } catch (e) {
      log(e.toString());
      throw Exception('Lỗi! Không thể tải Menu');
    }
    return result;
  }
}
