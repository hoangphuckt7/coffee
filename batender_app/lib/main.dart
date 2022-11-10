import 'package:bartender_app/routes.dart';
import 'package:bartender_app/utils/ui_setting.dart';
import 'package:flutter/material.dart';

Future main() async {
  WidgetsFlutterBinding.ensureInitialized();
  runApp(const BartenderApp());
}

class BartenderApp extends StatelessWidget {
  const BartenderApp({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Bartender',
      theme: ThemeData(
        primarySwatch: MColor.primaryBlack,
        fontFamily: "Times New Roman",
      ),
      debugShowCheckedModeBanner: false,
      onGenerateRoute: Routes.onGenerateRoute,
      initialRoute: RouteName.splash,
    );
  }
}
