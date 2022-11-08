import 'package:bbc_order_mobile/utils/function_common.dart';
import 'package:bbc_order_mobile/utils/ui_setting.dart';
import 'package:flutter/material.dart';
import 'package:flutter/src/widgets/container.dart';
import 'package:flutter/src/widgets/framework.dart';

class Popup extends StatelessWidget {
  final bool show;
  final List<Widget> children;
  const Popup({
    super.key,
    this.show = false,
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
            width: Fn.getScreenWidth(context) * .8,
            height: Fn.getScreenHeight(context) * .3,
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
