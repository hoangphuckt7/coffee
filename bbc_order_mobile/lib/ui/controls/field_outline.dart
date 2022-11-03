import 'package:bbc_order_mobile/utils/enum.dart';
import 'package:bbc_order_mobile/utils/ui_setting.dart';
import 'package:flutter/material.dart';

// ignore: must_be_immutable
class FieldOutnine extends StatelessWidget {
  final String labelText;
  final TextEditingController controller;
  final String? errorText;
  final EFieldType? eFieldType;
  final Function(String)? onChanged;
  final Function()? onEditingComplete;
  const FieldOutnine({
    super.key,
    required this.labelText,
    required this.controller,
    required this.errorText,
    this.eFieldType = EFieldType.text,
    this.onChanged,
    this.onEditingComplete,
  });

  final TextStyle _textStyle =
      const TextStyle(fontSize: ScreenSetting.fontSize);

  @override
  Widget build(BuildContext context) {
    return SizedBox(
      height: 55,
      child: TextFormField(
        controller: controller,
        obscureText: eFieldType == EFieldType.password,
        decoration: InputDecoration(
          border: const UnderlineInputBorder(),
          labelStyle: _textStyle,
          labelText: labelText,
          // labelStyle: TextStyle(fontWeight: FontWeight.bold),
          errorText: errorText,
        ),
        onChanged: onChanged,
        onEditingComplete: onEditingComplete,
      ),
    );
  }
}
