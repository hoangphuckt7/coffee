import 'dart:convert';
import 'dart:developer';
import 'package:orderr_app/api/fetch.dart';
import 'package:orderr_app/api/host.dart';
import 'package:orderr_app/api/status_code.dart';
import 'package:orderr_app/models/common/base_model.dart';

class CategoryRepo {
  static const controllerUrl = '${Host.currentHostApi}/Category';

  Future<List<BaseModel>> getAll() async {
    var lstCateModel = <BaseModel>[];
    try {
      var resp = await Fetch.GET(controllerUrl);
      if (resp.statusCode == HttpStatusCode.OK) {
        Iterable lstClone = jsonDecode(resp.body);
        lstCateModel = List<BaseModel>.from(
          lstClone.map((model) => BaseModel.fromJson(model)),
        );
      }
    } catch (e) {
      log('lỗi');
      log(e.toString());
    }
    return lstCateModel;
  }

  Future<BaseModel?> getById(String id) async {
    var resp = await Fetch.GET('$controllerUrl/$id');
    if (resp.statusCode == HttpStatusCode.OK) {
      return BaseModel.fromJson(jsonDecode(resp.body));
    }
    return null;
  }
}
