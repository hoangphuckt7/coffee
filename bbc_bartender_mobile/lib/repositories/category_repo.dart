import 'dart:convert';
import 'dart:developer';
import 'package:bbc_bartender_mobile/api/fetch.dart';
import 'package:bbc_bartender_mobile/api/host.dart';
import 'package:bbc_bartender_mobile/api/status_code.dart';
import 'package:bbc_bartender_mobile/models/category/category_model.dart';

class CategoryRepo {
  static const controllerUrl = '${Host.currentHost}/Category';

  Future<List<CategoryModel>> getAll() async {
    var lstCateModel = <CategoryModel>[];
    try {
      var resp = await Fetch.GET('${controllerUrl}');
      if (resp.statusCode == HttpStatusCode.OK) {
        Iterable lstClone = jsonDecode(resp.body);
        lstCateModel = List<CategoryModel>.from(
          lstClone.map((model) => CategoryModel.fromJson(model)),
        );
      }
    } catch (e) {
      log('lỗi');
      log(e.toString());
    }
    return lstCateModel;
  }

  Future<CategoryModel?> getById(String id) async {
    var resp = await Fetch.GET('${controllerUrl}/${id}');
    if (resp.statusCode == HttpStatusCode.OK) {
      return CategoryModel.fromJson(jsonDecode(resp.body));
    }
    return null;
  }
}
