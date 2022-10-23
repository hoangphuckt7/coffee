import 'package:bbc_order_mobile/utils/ui_setting.dart';
import 'package:flutter/material.dart';

class TestScreen extends StatelessWidget {
  const TestScreen({super.key});

  @override
  Widget build(BuildContext context) {
    return Container(
      color: MColor.white,
      child: const Center(
        child: Text(
          "TEST SCREEN 1",
        ),
      ),
    );
  }
}
