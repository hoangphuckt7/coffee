// ignore_for_file: must_be_immutable

import 'package:bartender_app/utils/enum.dart';
import 'package:bartender_app/utils/function_common.dart';
import 'package:bartender_app/utils/ui_setting.dart';
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

  @override
  Widget build(BuildContext context) {
    return SizedBox(
      child: InkWell(
        onTap: onPressed,
        child: Icon(
          icons,
          size: size,
          color: Fn.getColor(btnBgColor),
        ),
      ),
    );
  }
}
