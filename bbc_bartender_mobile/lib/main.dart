import 'package:bbc_bartender_mobile/utils/ui_setting.dart';
import 'package:flutter/material.dart';

import 'routes.dart';

Future main() async {
  WidgetsFlutterBinding.ensureInitialized();
  runApp(const BlueBirdCoffee());
}

class BlueBirdCoffee extends StatelessWidget {
  const BlueBirdCoffee({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'BBC Bartender',
      theme: ThemeData(
        // primarySwatch: MColor.primaryGreen,
        primarySwatch: MColor.black,
      ),
      // home: const Scaffold(body: LoginScreen()),
      debugShowCheckedModeBanner: false,
      onGenerateRoute: Routes.onGenerateRoute,
      initialRoute: RouteName.Login,
    );
  }
}
