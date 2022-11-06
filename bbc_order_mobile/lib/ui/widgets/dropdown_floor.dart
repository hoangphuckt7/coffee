import 'package:bbc_order_mobile/models/common/base_model.dart';
import 'package:bbc_order_mobile/utils/function_common.dart';
import 'package:bbc_order_mobile/utils/ui_setting.dart';
import 'package:flutter/material.dart';

class DropdownFloor extends StatelessWidget {
  final List<BaseModel> listFloor;
  final BaseModel? selectedFloor;
  final void Function(BaseModel?)? onChanged;
  const DropdownFloor({
    super.key,
    required this.listFloor,
    this.selectedFloor,
    this.onChanged,
  });

  final TextStyle _textStyle =
      const TextStyle(fontSize: ScreenSetting.fontSize);

  @override
  Widget build(BuildContext context) {
    return DropdownButton<BaseModel>(
      isExpanded: true,
      alignment: Alignment.center,
      menuMaxHeight: Fn.getScreenWidth(context),
      borderRadius: const BorderRadius.all(
        Radius.circular(CardSetting.border_radius),
      ),
      hint: Text('Chọn khu vực', style: _textStyle),
      value: selectedFloor,
      items: listFloor.map((BaseModel model) {
        return DropdownMenuItem<BaseModel>(
          alignment: Alignment.center,
          value: model,
          child: Text(model.description!, style: _textStyle),
        );
      }).toList(),
      onChanged: onChanged,
    );
  }
}
