import 'package:bbc_order_mobile/routes.dart';
import 'package:bbc_order_mobile/utils/ui_setting.dart';
import 'package:flutter/material.dart';

void main() {
  WidgetsFlutterBinding.ensureInitialized();
  runApp(const BBCOrder());
}

class BBCOrder extends StatelessWidget {
  const BBCOrder({super.key});

  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'BBC Order',
      theme: ThemeData(
        primarySwatch: MColor.primaryBlack,
        fontFamily: "Times New Roman",
      ),
      debugShowCheckedModeBanner: false,
      onGenerateRoute: Routes.onGenerateRoute,
      initialRoute: RouteName.pickTable,
    );
  }
}
