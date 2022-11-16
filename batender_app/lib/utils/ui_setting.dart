// ignore_for_file: constant_identifier_names

import 'package:bartender_app/utils/color_custom.dart';
import 'package:flutter/material.dart';

class MColor {
  static const MaterialColor primaryBlack = MCBlack;
  static const MaterialColor primaryGreen = MCGreen; //2360f
  static const Color white = Colors.white;
  static const Color black = Colors.black;
  static const MaterialColor danger = Colors.red;
  static const MaterialColor success = Colors.green;
  static const MaterialColor warning = Colors.yellow;
  static Color secondary = Colors.grey.shade600;
}

class MAColor {
  static const MaterialAccentColor primary = Colors.blueAccent;
  static const MaterialAccentColor danger = Colors.redAccent;
  static const MaterialAccentColor success = Colors.greenAccent;
  static const MaterialAccentColor warning = Colors.yellowAccent;
}

class HexColor {
  static const String primaryBlack = '#ff262525';
  static const String primaryGreen = '#ff23d60f';
  static const String white = '#ffffff';
  static const String black = '#000000';
  static const String danger = '#f44336';
  static const String success = '#4caf50';
  static const String warning = '#ffeb3b';
  static const String secondary = '#424242';
}

class CardSetting {
  static const double border_radius = 15;
}

class BtnSetting {
  static const double border_radius = 5;
  static const double border_width = 1.6;
}

class ScreenSetting {
  static const double padding_all = 10;
  static const double fontSize = 15;
}

class BorderSetting {
  static const double border_radius = 5;
  static const double focus_border_side_width = 1.5;
}
