import 'package:orderr_app/ui/controls/fill_btn.dart';
import 'package:orderr_app/ui/widgets/popup.dart';
import 'package:orderr_app/utils/enum.dart';
import 'package:flutter/material.dart';

class PopupConfirm extends StatelessWidget {
  final bool show;
  final String title;
  final String dangerTitle;
  final void Function()? onDangerPressed;
  final String primaryTitle;
  final void Function()? onPrimaryPressed;
  const PopupConfirm({
    super.key,
    this.show = false,
    required this.title,
    this.dangerTitle = 'Huỷ bỏ',
    this.onDangerPressed,
    this.primaryTitle = 'Ok',
    this.onPrimaryPressed,
  });

  @override
  Widget build(BuildContext context) {
    return Popup(
      show: show,
      children: [
        const Text(
          'Xác nhận đăng xuất',
          style: TextStyle(
            fontSize: 15,
            fontWeight: FontWeight.bold,
          ),
        ),
        Row(
          mainAxisAlignment: MainAxisAlignment.spaceEvenly,
          children: [
            FillBtn(
              title: dangerTitle,
              btnBgColor: EColor.danger,
              onPressed: onDangerPressed ?? () {},
            ),
            FillBtn(
              title: primaryTitle,
              onPressed: onPrimaryPressed ?? () {},
            ),
          ],
        ),
      ],
    );
  }
}
