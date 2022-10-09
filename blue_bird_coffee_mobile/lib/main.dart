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
      // title: 'Blue Bird Coffee',
      // theme: ThemeData(
      //   primarySwatch: MColor.primary,
      // ),
      // home: const Scaffold(body: LoginScreen()),
      debugShowCheckedModeBanner: false,
      onGenerateRoute: Routes.onGenerateRoute,
      initialRoute: RouteName.Login,
    );
  }
}
