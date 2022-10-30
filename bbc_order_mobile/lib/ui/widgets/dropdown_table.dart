import 'dart:developer';

import 'package:bbc_order_mobile/models/table/table_model.dart';
import 'package:bbc_order_mobile/utils/function_common.dart';
import 'package:bbc_order_mobile/utils/ui_setting.dart';
import 'package:flutter/material.dart';

class DropdownTable extends StatelessWidget {
  final List<TableModel> listTable;
  final TableModel? selectedTable;
  final void Function(TableModel?)? onChanged;
  const DropdownTable({
    super.key,
    required this.listTable,
    this.selectedTable,
    this.onChanged,
  });

  @override
  Widget build(BuildContext context) {
    return DropdownButton<TableModel>(
      isExpanded: true,
      menuMaxHeight: Fn.getScreenWidth(context),
      alignment: Alignment.center,
      borderRadius: const BorderRadius.all(
        Radius.circular(CardSetting.border_radius),
      ),
      hint: const Text('Chọn bàn'),
      value: selectedTable,
      items: listTable.map((TableModel model) {
        return DropdownMenuItem<TableModel>(
          alignment: Alignment.center,
          value: model,
          child: Text(model.description!),
        );
      }).toList(),
      onChanged: onChanged,
    );
  }
}
