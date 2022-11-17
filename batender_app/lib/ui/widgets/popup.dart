// ignore_for_file: must_be_immutable

import 'package:bartender_app/utils/function_common.dart';
import 'package:bartender_app/utils/ui_setting.dart';
import 'package:flutter/material.dart';

class Popup extends StatelessWidget {
  final bool show;
  final List<Widget> children;
  double? width;
  double? height;
  Popup({
    super.key,
    this.show = false,
    this.width,
    this.height,
    required this.children,
  });

  @override
  Widget build(BuildContext context) {
    return Visibility(
      visible: show,
      child: Container(
        color: Colors.black.withOpacity(.6),
        child: Center(
          child: SizedBox(
            width: width ??= Fn.getScreenWidth(context) * .8,
            height: height ??= Fn.getScreenHeight(context) * .3,
            child: Card(
              color: MColor.white,
              shape: RoundedRectangleBorder(
                borderRadius: BorderRadius.circular(CardSetting.border_radius),
              ),
              child: Padding(
                padding: const EdgeInsets.all(10),
                child: Column(
                  mainAxisAlignment: MainAxisAlignment.center,
                  children: children,
                ),
              ),
            ),
          ),
        ),
      ),
    );
  }
}
