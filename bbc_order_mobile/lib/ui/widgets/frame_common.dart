import 'package:bbc_order_mobile/ui/widgets/appbar_custom.dart';
import 'package:bbc_order_mobile/utils/ui_setting.dart';
import 'package:flutter/material.dart';

class MainFrame extends StatelessWidget {
  final Widget child;
  const MainFrame({super.key, required this.child});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: const AppbarCustom(
        showBackBtn: false,
      ),
      body: Padding(
        padding: const EdgeInsets.all(10),
        child: Container(
          alignment: Alignment.center,
          color: MColor.white,
          child: child,
        ),
      ),
    );
  }
}
