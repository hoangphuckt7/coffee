// ignore_for_file: must_be_immutable

import 'package:orderr_app/ui/widgets/appbar_custom.dart';
import 'package:orderr_app/utils/ui_setting.dart';
import 'package:flutter/material.dart';

class MainFrame extends StatelessWidget {
  final bool showUserInfo;
  final bool showLogoutBtn;
  final bool showBackBtn;
  final String title;
  final Widget? bottomBar;
  final void Function()? onClickBackBtn;
  final void Function()? onClickEditUserBtn;
  final Widget child;
  Future<bool> Function()? onWillPop;
  MainFrame({
    super.key,
    required this.child,
    this.showUserInfo = false,
    this.showLogoutBtn = false,
    this.showBackBtn = false,
    this.title = '',
    this.bottomBar,
    this.onWillPop,
    this.onClickBackBtn,
    this.onClickEditUserBtn,
  });

  @override
  Widget build(BuildContext context) {
    return WillPopScope(
      onWillPop: onWillPop ?? () async => false,
      child: Scaffold(
        backgroundColor: MColor.white,
        appBar: AppbarCustom(
          showUserInfo: showUserInfo,
          showLogoutBtn: showLogoutBtn,
          showBackBtn: showBackBtn,
          title: title,
          onClickBackBtn: onClickBackBtn,
          onClickEditUserBtn: onClickEditUserBtn,
        ),
        body: child,
        bottomNavigationBar: bottomBar,
      ),
    );
  }
}
