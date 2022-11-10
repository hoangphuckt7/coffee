// ignore_for_file: constant_identifier_names

import 'package:bbc_order_mobile/utils/color_custom.dart';
import 'package:flutter/material.dart';

class MColor {
  static const MaterialColor primaryBlack = MCBlack;
  static const MaterialColor primaryGreen = MCGreen; //2360f
  static const Color white = Colors.white;
  static const Color black = Colors.black;
  static const MaterialColor danger = Colors.red;
  static const MaterialColor success = Colors.green;
  static const MaterialColor warning = Colors.yellow;
  static Color secondary = Colors.grey.shade800;
}

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
  static const double border_radius = 5;
}

class ScreenSetting {
  static const double padding_all = 10;
  static const double fontSize = 15;
}

class BorderSetting {
  static const double border_radius = 5;
  static const double focus_border_side_width = 1.5;
}
