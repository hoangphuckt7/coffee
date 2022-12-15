// ignore_for_file: must_be_immutable

import 'package:orderr_app/utils/function_common.dart';
import 'package:orderr_app/utils/ui_setting.dart';
import 'package:flutter/material.dart';

class Popup extends StatelessWidget {
  final bool show;
  final List<Widget> children;
  final EdgeInsets padding;
  final bool applyConstraints;
  double? width;
  double? height;
  Popup({
    super.key,
    this.show = false,
    this.width,
    this.height,
    required this.children,
    this.padding = const EdgeInsets.all(10),
    this.applyConstraints = false,
  });

  @override
  Widget build(BuildContext context) {
    var screenWidth = Fn.getScreenWidth(context);
    var screenHeight = Fn.getScreenHeight(context);
    return Visibility(
      visible: show,
      child: Container(
        color: Colors.black.withOpacity(.6),
        child: Center(
          child: SizedBox(
            width: !applyConstraints ? (width ?? screenWidth * .8) : null,
            height: !applyConstraints ? (height ?? screenHeight * .3) : null,
            child: Container(
              constraints: applyConstraints
                  ? BoxConstraints(
                      minWidth: 200,
                      maxWidth: screenWidth * .8,
                      minHeight: 300,
                      maxHeight: screenHeight * .6,
                    )
                  : null,
              child: Card(
                color: MColor.white,
                shape: RoundedRectangleBorder(
                  borderRadius:
                      BorderRadius.circular(CardSetting.border_radius),
                ),
                child: Padding(
                  padding: padding,
                  child: Column(
                    mainAxisAlignment: MainAxisAlignment.center,
                    children: children,
                  ),
                ),
              ),
            ),
          ),
        ),
      ),
    );
  }
}
