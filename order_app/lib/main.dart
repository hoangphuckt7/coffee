// ignore_for_file: library_prefixes

import 'package:orderr_app/routes.dart';
import 'package:orderr_app/utils/ui_setting.dart';
import 'package:flutter/material.dart';

void main() {
  WidgetsFlutterBinding.ensureInitialized();
  runApp(const OrderApp());
}

class OrderApp extends StatelessWidget {
  const OrderApp({super.key});

  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Order',
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
