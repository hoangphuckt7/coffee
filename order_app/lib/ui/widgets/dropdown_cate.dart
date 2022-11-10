import 'package:orderr_app/models/common/base_model.dart';
import 'package:orderr_app/utils/function_common.dart';
import 'package:orderr_app/utils/ui_setting.dart';
import 'package:flutter/material.dart';

class DropdownCategory extends StatelessWidget {
  final List<BaseModel> listCategory;
  final BaseModel? selectedCategory;
  final double? height;
  final double? fontSize;
  final Color? focusColor;
  final void Function(BaseModel?)? onChanged;
  const DropdownCategory({
    super.key,
    required this.listCategory,
    this.selectedCategory,
    this.height = 55,
    this.fontSize = ScreenSetting.fontSize,
    this.focusColor = MColor.primaryBlack,
    this.onChanged,
  });

  @override
  Widget build(BuildContext context) {
    return SizedBox(
      height: height,
      child: Padding(
        padding: const EdgeInsets.all(5),
        child: DropdownButton<BaseModel>(
          isExpanded: true,
          alignment: Alignment.center,
          menuMaxHeight: Fn.getScreenWidth(context),
          borderRadius: const BorderRadius.all(
            Radius.circular(CardSetting.border_radius),
          ),
          hint: Text(
            'Lọc theo loại',
            style: TextStyle(fontSize: fontSize),
          ),
          value: selectedCategory,
          focusColor: focusColor,
          items: listCategory.map((BaseModel model) {
            return DropdownMenuItem<BaseModel>(
              alignment: Alignment.center,
              value: model,
              child: Text(
                model.description!,
                style: TextStyle(fontSize: fontSize),
              ),
            );
          }).toList(),
          onChanged: onChanged,
        ),
      ),
    );
  }
}
