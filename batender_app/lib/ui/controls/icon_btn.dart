// ignore_for_file: must_be_immutable

import 'package:bartender_app/utils/enum.dart';
import 'package:bartender_app/utils/function_common.dart';
import 'package:flutter/material.dart';

class IconBtn extends StatelessWidget {
  String label;
  double? fontSize;
  final EColor btnBgColor;
  final double? size;
  final IconData? icons;
  final void Function() onPressed;
  IconBtn({
    super.key,
    this.label = '',
    this.fontSize,
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
        child: Row(
          children: [
            Icon(
              icons,
              size: size,
              color: Fn.getColor(btnBgColor),
            ),
            Visibility(
              visible: (label.isNotEmpty),
              child: SizedBox(
                child: Text(
                  label,
                  style: TextStyle(
                    fontSize: fontSize,
                    fontWeight: FontWeight.bold,
                  ),
                ),
              ),
            ),
          ],
        ),
      ),
    );
  }
}
