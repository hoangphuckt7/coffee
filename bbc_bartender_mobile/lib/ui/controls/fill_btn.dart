// ignore_for_file: must_be_immutable

import 'package:bbc_bartender_mobile/utils/enum.dart';
import 'package:bbc_bartender_mobile/utils/ui_setting.dart';
import 'package:flutter/material.dart';

class FillBtn extends StatelessWidget {
  final String title;
  final EColor btnBgColor;
  final void Function() onPressed;
  const FillBtn({
    super.key,
    required this.title,
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
      height: 35,
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
          style: const TextStyle(fontSize: 15),
        ),
      ),
    );
  }
}
