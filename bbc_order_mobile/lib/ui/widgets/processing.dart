import 'package:bbc_order_mobile/ui/widgets/loader.dart';
import 'package:bbc_order_mobile/utils/function_common.dart';
import 'package:bbc_order_mobile/utils/ui_setting.dart';
import 'package:flutter/material.dart';

class Processing extends StatelessWidget {
  final String msg;
  final bool show;
  const Processing({
    super.key,
    this.msg = "Đang xử lý...",
    this.show = false,
  });

  @override
  Widget build(BuildContext context) {
    return Visibility(
      visible: show,
      child: Container(
        color: Colors.black.withOpacity(.6),
        child: Center(
          child: SizedBox(
            width: Fn.getScreenWidth(context) * .3,
            height: Fn.getScreenHeight(context) * .3,
            child: Card(
              color: MColor.white,
              shape: RoundedRectangleBorder(
                borderRadius: BorderRadius.circular(CardSetting.border_radius),
              ),
              child: Padding(
                padding: const EdgeInsets.all(10),
                child: Column(
                  mainAxisAlignment: MainAxisAlignment.center,
                  children: [
                    const Loader(size: 50),
                    const SizedBox(height: 20),
                    Text(
                      msg,
                      style: const TextStyle(
                        fontSize: 20,
                        fontWeight: FontWeight.bold,
                      ),
                    ),
                  ],
                ),
              ),
            ),
          ),
        ),
      ),
    );
  }
}
