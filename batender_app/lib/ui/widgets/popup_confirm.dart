import 'package:bartender_app/ui/controls/fill_btn.dart';
import 'package:bartender_app/ui/widgets/popup.dart';
import 'package:bartender_app/utils/enum.dart';
import 'package:flutter/material.dart';
import 'package:bartender_app/utils/function_common.dart';

class PopupConfirm extends StatelessWidget {
  final bool visible;
  final String title;
  final double? width;
  final double? height;
  final String leftTitle;
  final EColor leftBtnColor;
  final void Function()? onLeftBtnPressed;
  final String rightTitle;
  final EColor rightBtnColor;
  final void Function()? onRightBtnPressed;
  const PopupConfirm({
    super.key,
    this.visible = false,
    required this.title,
    this.width,
    this.height,
    this.leftTitle = 'Huỷ bỏ',
    this.leftBtnColor = EColor.danger,
    this.onLeftBtnPressed,
    this.rightTitle = 'Ok',
    this.rightBtnColor = EColor.primary,
    this.onRightBtnPressed,
  });

  @override
  Widget build(BuildContext context) {
    return Popup(
      show: visible,
      height: height ?? Fn.getScreenHeight(context) * .2,
      children: [
        Expanded(
          child: Column(
            mainAxisAlignment: MainAxisAlignment.center,
            children: [
              Text(
                '$title?',
                style: const TextStyle(
                  fontSize: 15,
                  fontWeight: FontWeight.bold,
                ),
              ),
            ],
          ),
        ),
        Expanded(
          child: Column(
            mainAxisAlignment: MainAxisAlignment.center,
            children: [
              Row(
                mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                children: [
                  FillBtn(
                    label: leftTitle,
                    btnBgColor: leftBtnColor,
                    onPressed: onLeftBtnPressed ?? () {},
                  ),
                  FillBtn(
                    label: rightTitle,
                    onPressed: onRightBtnPressed ?? () {},
                  ),
                ],
              ),
            ],
          ),
        ),
      ],
    );
  }
}
