// ignore_for_file: must_be_immutable

import 'package:bbc_order_mobile/utils/enum.dart';
import 'package:bbc_order_mobile/utils/ui_setting.dart';
import 'package:flutter/material.dart';

class IconBtn extends StatelessWidget {
  final EColor btnBgColor;
  final double? size;
  final IconData? icons;
  final void Function() onPressed;
  const IconBtn({
    super.key,
    required this.icons,
    this.size = 30,
    this.btnBgColor = EColor.primary,
    required this.onPressed,
  });

  _getBgColor(EColor eColor) {
    switch (eColor) {
      case EColor.primary:
        return MColor.primaryGreen;
      case EColor.danger:
        return MColor.danger;
      case EColor.dark:
        return MColor.primaryBlack;
      case EColor.secondary:
        return MColor.secondary;
      default:
        return MColor.primaryBlack;
    }
  }

  @override
  Widget build(BuildContext context) {
    return SizedBox(
      child: InkWell(
        onTap: onPressed,
        child: Icon(
          icons,
          size: size,
          color: _getBgColor(btnBgColor),
        ),
      ),
    );
  }
}
