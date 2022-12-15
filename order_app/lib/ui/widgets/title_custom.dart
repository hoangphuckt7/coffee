import 'package:flutter/material.dart';
import 'package:orderr_app/utils/ui_setting.dart';

class TitleCustom extends StatelessWidget {
  final String title;
  const TitleCustom({
    super.key,
    this.title = '',
  });

  @override
  Widget build(BuildContext context) {
    return SizedBox(
      child: Text(
        title,
        style: const TextStyle(
          fontWeight: FontWeight.bold,
          fontSize: ScreenSetting.fontSize + 3,
        ),
      ),
    );
  }
}
