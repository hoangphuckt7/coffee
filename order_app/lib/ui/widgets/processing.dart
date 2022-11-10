import 'package:orderr_app/ui/widgets/loader.dart';
import 'package:orderr_app/ui/widgets/popup.dart';
import 'package:orderr_app/utils/function_common.dart';
import 'package:orderr_app/utils/ui_setting.dart';
import 'package:flutter/material.dart';

class Processing extends StatelessWidget {
  final String msg;
  final bool show;
  const Processing({
    super.key,
    this.msg = "Đang xử lý...",
    this.show = false,
  });

  @override
  Widget build(BuildContext context) {
    return Popup(
      show: show,
      children: [
        const Loader(size: 30),
        const SizedBox(height: 20),
        Text(
          msg,
          style: const TextStyle(
            fontSize: 15,
            fontWeight: FontWeight.bold,
          ),
        ),
      ],
    );
  }
}
