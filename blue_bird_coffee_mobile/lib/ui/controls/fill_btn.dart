import 'package:blue_bird_coffee_mobile/utils/ui_setting.dart';
import 'package:flutter/material.dart';

class FillBtn extends StatelessWidget {
  final String title;
  final void Function() onPressed;
  const FillBtn({super.key, required this.title, required this.onPressed});

  @override
  Widget build(BuildContext context) {
    return SizedBox(
      height: 35,
      child: ElevatedButton(
        style: ButtonStyle(
          shape: MaterialStateProperty.all(
            RoundedRectangleBorder(
              borderRadius: BorderRadius.circular(BtnSetting.border_radius),
            ),
          ),
          foregroundColor: MaterialStateProperty.all<Color>(MColor.white),
          backgroundColor:
              MaterialStateProperty.all<MaterialColor>(MColor.primary),
        ),
        onPressed: onPressed,
        child: Text(
          title,
          style: const TextStyle(fontSize: 15),
        ),
      ),
    );
  }
}
