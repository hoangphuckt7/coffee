import 'package:bbc_bartender_mobile/utils/ui_setting.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/src/widgets/container.dart';
import 'package:flutter/src/widgets/framework.dart';

class TestScreen extends StatelessWidget {
  const TestScreen({super.key});

  @override
  Widget build(BuildContext context) {
    return Container(
      color: MColor.white,
      child: Center(
        child: Text(
          "TEST SCREEN 1",
        ),
      ),
    );
  }
}