// ignore_for_file: library_prefixes

import 'dart:developer';

import 'package:orderr_app/routes.dart';
import 'package:orderr_app/utils/ui_setting.dart';
import 'package:flutter/material.dart';
import "package:os_detect/os_detect.dart" as Platform;

void main() {
  WidgetsFlutterBinding.ensureInitialized();
  runApp(const OrderApp());
}

class OrderApp extends StatelessWidget {
  const OrderApp({super.key});

  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    log('isAndroid: ${Platform.isAndroid}');
    log('isBrowser: ${Platform.isBrowser}');
    log('isFuchsia: ${Platform.isFuchsia}');
    log('isIOS: ${Platform.isIOS}');
    log('isLinux: ${Platform.isLinux}');
    log('isMacOS: ${Platform.isMacOS}');
    log('isWindows: ${Platform.isWindows}');
    log('operatingSystem: ${Platform.operatingSystem}');
    log('operatingSystemVersion: ${Platform.operatingSystemVersion}');
    log('alo: ${bool.hasEnvironment('ApiHost')}');
    log('alo2: ${String.fromEnvironment('ApiHost', defaultValue: '123')}');
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
