import 'dart:developer';

import 'package:bbc_order_mobile/models/common/base_model.dart';
import 'package:bbc_order_mobile/utils/function_common.dart';
import 'package:bbc_order_mobile/utils/ui_setting.dart';
import 'package:flutter/material.dart';

class DropdownCategory extends StatelessWidget {
  final List<BaseModel> listCategory;
  final BaseModel? selectedCategory;
  final void Function(BaseModel?)? onChanged;
  const DropdownCategory({
    super.key,
    required this.listCategory,
    this.selectedCategory,
    this.onChanged,
  });

  @override
  Widget build(BuildContext context) {
    return DropdownButton<BaseModel>(
      isExpanded: true,
      alignment: Alignment.center,
      menuMaxHeight: Fn.getScreenWidth(context),
      borderRadius: const BorderRadius.all(
        Radius.circular(CardSetting.border_radius),
      ),
      hint: const Text('Lọc theo loại'),
      value: selectedCategory,
      items: listCategory.map((BaseModel model) {
        return DropdownMenuItem<BaseModel>(
          alignment: Alignment.center,
          value: model,
          child: Text(model.description!),
        );
      }).toList(),
      onChanged: onChanged,
    );
  }
}
