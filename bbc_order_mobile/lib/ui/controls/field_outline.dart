import 'package:bbc_order_mobile/utils/enum.dart';
import 'package:bbc_order_mobile/utils/ui_setting.dart';
import 'package:flutter/material.dart';

// ignore: must_be_immutable
class FieldOutline extends StatelessWidget {
  final Key? fieldKey;
  final String? labelText;
  final TextEditingController controller;
  final String? errorText;
  final EFieldType? eFieldType;
  final EBorder? eBorder;
  final double? height;
  final BorderRadius borderRadius;
  final Color focusBorderSideColor;
  final double? fontSize;
  final Function(String)? onChanged;
  final Function()? onEditingComplete;
  const FieldOutline({
    super.key,
    this.fieldKey,
    this.labelText,
    required this.controller,
    this.errorText,
    this.eFieldType = EFieldType.text,
    this.eBorder = EBorder.underline,
    this.borderRadius = const BorderRadius.all(
      Radius.circular(BtnSetting.border_radius),
    ),
    this.height = 55,
    this.fontSize = ScreenSetting.fontSize,
    this.focusBorderSideColor = MColor.primaryBlack,
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
    return SizedBox(
      height: height,
      child: TextFormField(
        key: fieldKey,
        controller: controller,
        obscureText: eFieldType == EFieldType.password,
        decoration: InputDecoration(
          contentPadding: const EdgeInsets.symmetric(
            vertical: 5,
            horizontal: 10,
          ),
          border: _getBorder(),
          labelStyle: TextStyle(fontSize: fontSize),
          labelText: labelText,
          errorText: errorText,
          focusedBorder: _getFocusBorder(),
        ),
        onChanged: onChanged,
        onEditingComplete: onEditingComplete,
      ),
    );
  }
}
