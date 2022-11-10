import 'package:orderr_app/utils/ui_setting.dart';
import 'package:flutter/material.dart';

class Empty extends StatelessWidget {
  final String msg;
  const Empty({super.key, this.msg = "Không có dữ liệu"});

  @override
  Widget build(BuildContext context) {
    return Container(
      color: MColor.danger,
      child: Center(
        child: Text(msg),
      ),
    );
  }
}
