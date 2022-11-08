// ignore_for_file: must_be_immutable

import 'package:bbc_order_mobile/blocs/auth/auth_bloc.dart';
import 'package:bbc_order_mobile/routes.dart';
import 'package:bbc_order_mobile/utils/function_common.dart';
import 'package:bbc_order_mobile/utils/ui_setting.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

class AppbarCustom extends StatelessWidget implements PreferredSizeWidget {
  final bool showUserInfo;
  final bool showLogoutBtn;
  final bool showBackBtn;
  final String title;
  final void Function()? onClickBackBtn;
  AppbarCustom({
    super.key,
    this.showUserInfo = false,
    this.showLogoutBtn = false,
    this.showBackBtn = false,
    this.title = '',
    this.onClickBackBtn,
  });

  @override
  Size get preferredSize => const Size.fromHeight(50);
  String fullName = '';
  @override
  Widget build(BuildContext context) {
    return AppBar(
      foregroundColor: MColor.white,
      backgroundColor: MColor.primaryBlack,
      automaticallyImplyLeading: false,
      titleTextStyle: const TextStyle(fontSize: 15),
      title: Row(
        mainAxisAlignment: MainAxisAlignment.end,
        children: [
          Visibility(
            visible: showBackBtn,
            child: Expanded(
              child: Row(
                children: [
                  InkWell(
                    onTap: onClickBackBtn,
                    child: const Icon(
                      Icons.arrow_back_rounded,
                      color: MColor.primaryGreen,
                      size: 25,
                    ),
                  ),
                  Visibility(
                    visible: title.isNotEmpty,
                    child: const SizedBox(width: 10),
                  ),
                  Visibility(
                    visible: title.isNotEmpty,
                    child: Text(
                      title,
                      style: const TextStyle(
                        fontSize: 18,
                        fontStyle: FontStyle.italic,
                      ),
                    ),
                  ),
                ],
              ),
            ),
          ),
          Visibility(
            visible: showUserInfo,
            child: BlocBuilder<AuthBloc, AuthState>(
              builder: (context, state) {
                if (state is LoadedUserInfoState) {
                  fullName = state.fullName;
                }
                return SizedBox(child: Text('Xin chào, $fullName'));
              },
            ),
          ),
          const SizedBox(width: 20),
          Visibility(
            visible: showLogoutBtn,
            child: BlocListener<AuthBloc, AuthState>(
              listener: (context, state) {
                if (state is LogoutState) {
                  Fn.pushScreen(context, RouteName.login);
                }
              },
              child: InkWell(
                onTap: (() {
                  BlocProvider.of<AuthBloc>(context).add(LogoutEvent());
                }),
                child: const Icon(
                  Icons.logout_outlined,
                  color: MColor.danger,
                  size: 25,
                ),
              ),
            ),
          ),
        ],
      ),
    );
  }
}
