// ignore_for_file: must_be_immutable

import 'package:orderr_app/utils/enum.dart';
import 'package:orderr_app/utils/ui_setting.dart';
import 'package:flutter/material.dart';

class FillBtn extends StatelessWidget {
  final String title;
  final EColor btnBgColor;
  final double? height;
  final void Function() onPressed;
  const FillBtn({
    super.key,
    required this.title,
    this.height = 30,
    this.btnBgColor = EColor.primary,
    required this.onPressed,
  });

  _getBgColor(EColor eColor) {
    switch (eColor) {
      case EColor.primary:
        return MaterialStateProperty.all<Color>(MColor.primaryGreen);
      case EColor.danger:
        return MaterialStateProperty.all<Color>(MColor.danger);
      default:
        MaterialStateProperty.all<Color>(MColor.primaryBlack);
    }
  }

  @override
  Widget build(BuildContext context) {
    return SizedBox(
      height: height,
      child: ElevatedButton(
        style: ButtonStyle(
          shape: MaterialStateProperty.all(
            RoundedRectangleBorder(
              borderRadius: BorderRadius.circular(BtnSetting.border_radius),
            ),
          ),
          foregroundColor: MaterialStateProperty.all<Color>(MColor.white),
          backgroundColor: _getBgColor(btnBgColor),
        ),
        onPressed: onPressed,
        child: Text(
          title,
          style: const TextStyle(fontSize: 13),
        ),
      ),
    );
  }
}
