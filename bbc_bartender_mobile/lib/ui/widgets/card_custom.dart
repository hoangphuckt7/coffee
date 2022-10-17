import 'package:bbc_bartender_mobile/utils/ui_setting.dart';
import 'package:flutter/material.dart';
import 'package:flutter/src/widgets/container.dart';
import 'package:flutter/src/widgets/framework.dart';

class CardCustom extends StatelessWidget {
  final double? shadow;
  final dynamic edgeInsets;
  final BorderSide? borderSide;
  final Widget child;
  const CardCustom({
    super.key,
    this.shadow = 80,
    this.edgeInsets = const EdgeInsets.all(0),
    this.borderSide = const BorderSide(color: MColor.white),
    required this.child,
  });

  @override
  Widget build(BuildContext context) {
    return Card(
      elevation: shadow,
      shape: RoundedRectangleBorder(
        borderRadius: BorderRadius.circular(CardSetting.border_radius),
        side: borderSide!,
      ),
      child: Padding(
        padding: edgeInsets,
        child: child,
      ),
    );
  }
}
