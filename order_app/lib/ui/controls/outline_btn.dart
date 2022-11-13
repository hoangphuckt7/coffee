import 'package:flutter/material.dart';
import 'package:orderr_app/utils/enum.dart';
import 'package:orderr_app/utils/function_common.dart';
import 'package:orderr_app/utils/ui_setting.dart';

class OutlineBtn extends StatelessWidget {
  final String label;
  final double? width;
  final double? height;
  final EColor? syncColor;
  final EColor textColor;
  final EColor borderColor;
  final void Function() onPressed;
  const OutlineBtn({
    super.key,
    required this.label,
    required this.onPressed,
    this.width,
    this.height = 30,
    this.syncColor,
    this.textColor = EColor.dark,
    this.borderColor = EColor.dark,
  });

  @override
  Widget build(BuildContext context) {
    return SizedBox(
      width: width,
      height: height,
      child: OutlinedButton(
        style: ButtonStyle(
          shape: MaterialStateProperty.all(
            RoundedRectangleBorder(
              borderRadius: BorderRadius.circular(BtnSetting.border_radius),
            ),
          ),
          side: MaterialStateProperty.all(
            BorderSide(
              color: Fn.getColor(syncColor ?? borderColor),
              width: BtnSetting.border_width,
            ),
          ),
          backgroundColor: MaterialStateProperty.all<Color>(MColor.white),
        ),
        onPressed: onPressed,
        child: Text(
          label,
          style: TextStyle(
            fontSize: 13,
            color: Fn.getColor(syncColor ?? textColor),
          ),
        ),
      ),
    );
  }
}
