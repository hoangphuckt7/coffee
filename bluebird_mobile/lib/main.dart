import 'dart:io';

import 'package:bluebird_mobile/utils/const.dart';
import 'package:flutter/material.dart';

// import 'package:flutter_dotenv/flutter_dotenv.dart';
import 'screens/Splash/splash_screen.dart';
import 'screens/login/login_screen.dart';

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
