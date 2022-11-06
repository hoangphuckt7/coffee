import 'package:bbc_order_mobile/ui/widgets/appbar_custom.dart';
import 'package:bbc_order_mobile/utils/ui_setting.dart';
import 'package:flutter/material.dart';

class MainFrame extends StatelessWidget {
  final bool showUserInfo;
  final bool showLogoutBtn;
  final bool showBackBtn;
  final String title;
  final Widget? bottomBar;
  final void Function()? onClickBackBtn;
  final Widget child;
  const MainFrame({
    super.key,
    this.showUserInfo = false,
    this.showLogoutBtn = false,
    this.showBackBtn = false,
    this.title = '',
    this.bottomBar,
    this.onClickBackBtn,
    required this.child,
  });

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: MColor.white,
      appBar: AppbarCustom(
        showUserInfo: showUserInfo,
        showLogoutBtn: showLogoutBtn,
        showBackBtn: showBackBtn,
        title: title,
        onClickBackBtn: onClickBackBtn,
      ),
      body: child,
      bottomNavigationBar: bottomBar,
    );
  }
}
