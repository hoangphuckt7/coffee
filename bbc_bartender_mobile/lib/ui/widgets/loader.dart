import 'package:bbc_bartender_mobile/utils/ui_setting.dart';
import 'package:flutter/cupertino.dart';
import 'package:loading_animation_widget/loading_animation_widget.dart';

class Loader extends StatelessWidget {
  final double size;
  const Loader({super.key, this.size = 100.0});

  @override
  Widget build(BuildContext context) {
    return Center(
      child: LoadingAnimationWidget.staggeredDotsWave(
        color: MColor.primaryBlack,
        size: size,
      ),
    );
  }
}
