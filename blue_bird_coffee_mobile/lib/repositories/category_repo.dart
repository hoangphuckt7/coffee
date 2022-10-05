import 'dart:convert';

import 'package:blue_bird_coffee_mobile/api/fetch.dart';
import 'package:blue_bird_coffee_mobile/api/host.dart';
import 'package:blue_bird_coffee_mobile/api/status_code.dart';
import 'package:blue_bird_coffee_mobile/models/category/category_model.dart';

class CategoryRepo {
  static const controllerUrl = '${Host.currentHost}/Category';

  Future<List<CategoryModel>> getAll() async {
    var resp = await Fetch.get('${controllerUrl}');
    if (resp.statusCode == HttpStatusCode.OK) {
      return jsonDecode(resp.body)
          .map((dynamic item) => CategoryModel.fromJson(item))
          .toList();
    }
    return <CategoryModel>[];
  }

  Future<CategoryModel?> getById(String id) async {
    var resp = await Fetch.get('${controllerUrl}/${id}');
    if (resp.statusCode == HttpStatusCode.OK) {
      return CategoryModel.fromJson(jsonDecode(resp.body));
    }
    return null;
  }
}
