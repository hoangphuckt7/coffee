// ignore_for_file: constant_identifier_names

import 'package:flutter/material.dart';

class MColor {
  static const Color primaryBlack = Color.fromARGB(255, 38, 37, 37);
  static const Color menu = Color.fromARGB(255, 38, 37, 37); //#262525
  static const Color primaryGreen = Color.fromARGB(255, 35, 214, 15); //23d60f
  static const Color white = Colors.white;
  static const MaterialColor black = _MCBlack;
  static const MaterialColor danger = Colors.red;
  static const MaterialColor success = Colors.green;
  static const MaterialColor warning = Colors.yellow;
}

const MaterialColor _MCBlack = const MaterialColor(
  0xff262525,
  const <int, Color>{
    50: const Color(0xff262525),
    100: const Color(0xff262525),
    200: const Color(0xff262525),
    300: const Color(0xff262525),
    400: const Color(0xff262525),
    500: const Color(0xff262525),
    600: const Color(0xff262525),
    700: const Color(0xff262525),
    800: const Color(0xff262525),
    900: const Color(0xff262525),
  },
);
// const MaterialColor MCGreen = const MaterialColor(
//   0xff23d60f,
//   const <int, Color>{
//     50: const Color(0xff23d60f),
//     100: const Color(0xff23d60f),
//     200: const Color(0xff23d60f),
//     300: const Color(0xff23d60f),
//     400: const Color(0xff23d60f),
//     500: const Color(0xff23d60f),
//     600: const Color(0xff23d60f),
//     700: const Color(0xff23d60f),
//     800: const Color(0xff23d60f),
//     900: const Color(0xff23d60f),
//   },
// );

class MAColor {
  static const MaterialAccentColor primary = Colors.blueAccent;
  static const MaterialAccentColor danger = Colors.redAccent;
  static const MaterialAccentColor success = Colors.greenAccent;
  static const MaterialAccentColor warning = Colors.yellowAccent;
}

class CardSetting {
  static const double border_radius = 15;
}

class BtnSetting {
  static const double border_radius = 10;
}
