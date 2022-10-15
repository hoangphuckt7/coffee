// ignore_for_file: must_be_immutable

import 'package:bbc_bartender_mobile/ui/widgets/loader.dart';
import 'package:bbc_bartender_mobile/utils/ui_setting.dart';
import 'package:flutter/material.dart';
import 'package:flutter/widgets.dart';

class Processing extends StatelessWidget {
  bool show = false;
  Processing({super.key, this.show = false});

  @override
  Widget build(BuildContext context) {
    return Visibility(
      visible: show,
      child: Container(
        color: Colors.black.withOpacity(.6),
        child: Center(
          child: SizedBox(
            width: 200,
            height: 200,
            child: Card(
              color: MColor.white,
              shape: RoundedRectangleBorder(
                borderRadius: BorderRadius.circular(CardSetting.border_radius),
              ),
              child: Column(
                mainAxisAlignment: MainAxisAlignment.center,
                children: [
                  Loader(size: 50),
                  SizedBox(height: 20),
                  Text(
                    "Đang xử lý...",
                    style: TextStyle(fontSize: 20, fontWeight: FontWeight.bold),
                  ),
                  // SizedBox(
                  //   child:
                  // ),
                ],
              ),
            ),
          ),
        ),
      ),
    );
  }
}
