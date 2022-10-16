import 'package:bbc_bartender_mobile/utils/ui_setting.dart';
import 'package:flutter/material.dart';

import 'routes.dart';

Future main() async {
  WidgetsFlutterBinding.ensureInitialized();
  runApp(const BBCBartender());
}

class BBCBartender extends StatelessWidget {
  const BBCBartender({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'BBC Bartender',
      theme: ThemeData(
        primarySwatch: MColor.primaryBlack,
        fontFamily: "Montserrat",
      ),
      // home: const Scaffold(body: LoginScreen()),
      debugShowCheckedModeBanner: false,
      onGenerateRoute: Routes.onGenerateRoute,
      initialRoute: RouteName.splash,
    );
  }
}
