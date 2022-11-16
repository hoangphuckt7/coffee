// ignore_for_file: must_be_immutable

import 'package:bartender_app/utils/enum.dart';
import 'package:bartender_app/utils/function_common.dart';
import 'package:bartender_app/utils/ui_setting.dart';
import 'package:flutter/material.dart';

class FillBtn extends StatelessWidget {
  final String label;
  final EColor btnBgColor;
  final EColor? labelColor;
  final double? width;
  final double? height;
  final void Function() onPressed;
  const FillBtn({
    super.key,
    required this.label,
    required this.onPressed,
    this.width,
    this.height = 30,
    this.btnBgColor = EColor.primary,
    this.labelColor = EColor.white,
  });

  @override
  Widget build(BuildContext context) {
    return SizedBox(
      width: width,
      height: height,
      child: ElevatedButton(
        style: ButtonStyle(
          shape: MaterialStateProperty.all(
            RoundedRectangleBorder(
              borderRadius: BorderRadius.circular(BtnSetting.border_radius),
            ),
          ),
          backgroundColor: MaterialStateProperty.all<Color>(
            Fn.getColor(btnBgColor),
          ),
        ),
        onPressed: onPressed,
        child: Text(
          label,
          style: TextStyle(
            fontSize: 15,
            color: Fn.getColor(labelColor),
          ),
        ),
      ),
    );
  }
}
