import 'package:bbc_order_mobile/utils/ui_setting.dart';
import 'package:flutter/material.dart';

class AppbarCustom extends StatelessWidget implements PreferredSizeWidget {
  final bool showBackBtn;
  final void Function()? onClickBackBtn;
  const AppbarCustom({
    super.key,
    this.showBackBtn = true,
    this.onClickBackBtn,
  });

  @override
  Size get preferredSize => const Size.fromHeight(50);

  @override
  Widget build(BuildContext context) {
    return AppBar(
      foregroundColor: MColor.white,
      backgroundColor: MColor.primaryBlack,
      automaticallyImplyLeading: showBackBtn,
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
                ],
              ),
            ),
          ),
          const SizedBox(child: Text('Xin chào!')),
          const SizedBox(width: 20),
          InkWell(
            onTap: (() {}),
            child: const Icon(
              Icons.logout_outlined,
              color: MColor.danger,
              size: 25,
            ),
          ),
        ],
      ),
    );
  }
}
