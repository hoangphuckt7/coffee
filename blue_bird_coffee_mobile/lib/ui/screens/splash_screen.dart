import 'package:blue_bird_coffee_mobile/ui/widgets/loader.dart';
import 'package:blue_bird_coffee_mobile/utils/ui_setting.dart';
import 'package:flutter/cupertino.dart';

class SplashScreen extends StatelessWidget {
  const SplashScreen({super.key});

  @override
  Widget build(BuildContext context) {
    return Container(
      color: MColor.white,
      child: Loader(),
    );
  }
}
