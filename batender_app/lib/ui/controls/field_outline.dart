import 'package:bartender_app/utils/enum.dart';
import 'package:flutter/material.dart';

import '../../utils/ui_setting.dart';

// ignore: must_be_immutable
class FieldOutline extends StatelessWidget {
  final Key? fieldKey;
  final String? labelText;
  final String? hintText;
  final TextEditingController controller;
  final String? errorText;
  final EFieldType? eFieldType;
  final EBorder? eBorder;
  final double? width;
  final double? height;
  final BorderRadius borderRadius;
  final Color focusBorderSideColor;
  final double? fontSize;
  final double paddingVertical;
  final double paddingHorizontal;
  final Function(String)? onChanged;
  final Function()? onEditingComplete;
  const FieldOutline({
    super.key,
    this.fieldKey,
    this.labelText,
    this.hintText,
    required this.controller,
    this.errorText,
    this.eFieldType = EFieldType.text,
    this.eBorder = EBorder.underline,
    this.borderRadius = const BorderRadius.all(
      Radius.circular(BtnSetting.border_radius),
    ),
    this.width,
    this.height = 55,
    this.fontSize = ScreenSetting.fontSize,
    this.focusBorderSideColor = MColor.primaryBlack,
    this.paddingVertical = 5,
    this.paddingHorizontal = 10,
    this.onChanged,
    this.onEditingComplete,
  });

  InputBorder? _getBorder() {
    switch (eBorder) {
      case EBorder.all:
        return OutlineInputBorder(
          borderRadius: borderRadius,
        );
      case EBorder.underline:
        return const UnderlineInputBorder();
      default:
        return const UnderlineInputBorder();
    }
  }

  InputBorder? _getFocusBorder() {
    switch (eBorder) {
      case EBorder.all:
        return OutlineInputBorder(
          borderRadius: borderRadius,
          borderSide: BorderSide(
            color: focusBorderSideColor,
            width: BorderSetting.focus_border_side_width,
          ),
        );
      case EBorder.underline:
        return const UnderlineInputBorder();
      default:
        return const UnderlineInputBorder();
    }
  }

  @override
  Widget build(BuildContext context) {
    controller.selection = TextSelection.fromPosition(
      TextPosition(offset: controller.text.length),
    );
    return SizedBox(
      child: TextFormField(
        key: fieldKey,
        controller: controller,
        obscureText: eFieldType == EFieldType.password,
        decoration: InputDecoration(
          contentPadding: EdgeInsets.symmetric(
            vertical: paddingVertical,
            horizontal: paddingHorizontal,
          ),
          border: _getBorder(),
          labelStyle: TextStyle(fontSize: fontSize),
          labelText: labelText,
          errorText: errorText,
          focusedBorder: _getFocusBorder(),
          hintText: hintText,
        ),
        onChanged: onChanged,
      ),
    );
  }
}
