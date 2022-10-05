import 'package:blue_bird_coffee_mobile/ui/screens/login_screen.dart';
import 'package:blue_bird_coffee_mobile/utils/ui_setting.dart';
import 'package:flutter/material.dart';

Future main() async {
  runApp(const BlueBirdCoffee());
}

class BlueBirdCoffee extends StatelessWidget {
  const BlueBirdCoffee({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Blue Bird Coffee',
      theme: ThemeData(
        primarySwatch: MColor.primary,
      ),
      home: const Scaffold(body: LoginScreen()),
    );
  }
}
