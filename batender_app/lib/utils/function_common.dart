// ignore_for_file: avoid_init_to_null

import 'dart:convert';
import 'dart:developer';

import 'package:bartender_app/utils/enum.dart';
import 'package:bartender_app/utils/ui_setting.dart';
import 'package:flutter/material.dart';
import 'package:fluttertoast/fluttertoast.dart';
import 'package:intl/intl.dart';
import 'package:audioplayers/audioplayers.dart';

class Fn {
  static getScreenWidth(BuildContext context) {
    return MediaQuery.of(context).size.width;
  }

  static getScreenHeight(BuildContext context) {
    return MediaQuery.of(context).size.height;
  }

  static getColor(EColor? eColor) {
    switch (eColor) {
      case EColor.primary:
        return MColor.primaryGreen;
      case EColor.danger:
        return MColor.danger;
      case EColor.dark:
        return MColor.primaryBlack;
      case EColor.black:
        return MColor.black;
      case EColor.white:
        return MColor.white;
      case EColor.secondary:
        return MColor.secondary;
      case EColor.success:
        return MColor.success;
      case EColor.warning:
        return MColor.warning;
      default:
        return MColor.primaryBlack;
    }
  }

  static showToast({
    EToast? eToast,
    String msg = '',
    ToastGravity? index = ToastGravity.TOP,
    bool soundEnable = false,
    String soundUrl = 'assets/audios/new_order.mp3',
  }) {
    dynamic toastColor;
    dynamic hexColor;
    switch (eToast) {
      case EToast.success:
        toastColor = MColor.success;
        hexColor = HexColor.success;
        break;
      case EToast.danger:
        toastColor = MColor.danger;
        hexColor = HexColor.danger;
        break;
      case EToast.warning:
        toastColor = MColor.warning;
        hexColor = HexColor.warning;
        break;
      default:
        toastColor = MColor.black;
        hexColor = HexColor.black;
        break;
    }
    playNotiSound(enable: true);
    Fluttertoast.showToast(
      msg: msg,
      backgroundColor: toastColor,
      gravity: index,
      webBgColor: hexColor,
      webPosition: 'center', //	String (left, center or right)
      timeInSecForIosWeb: 3,
    );
  }

  static playNotiSound({
    bool enable = false,
    String srcUrl = 'assets/audios/new_order.mp3',
  }) {
    if (enable) {
      final audio = AudioPlayer();
      audio.play(UrlSource(srcUrl));
    }
  }

  static formatDate(DateTime? date, DateFormat format) {
    return format.format(date!);
  }

  static convertOrderNumber(input) {
    String inputStr = input.toString();
    switch (inputStr.length) {
      case 1:
        return '#00$inputStr';
      case 2:
        return '#0$inputStr';
      default:
        return '#$inputStr';
    }
  }

  static renderData(input, errMsg) {
    if (input == null || (input is String && input.isEmpty)) {
      return errMsg;
    }
    return input.toString();
  }

  static logObj(title, obj) {
    log('$title: ${jsonEncode(obj)}');
  }

  static pushScreen(
    BuildContext context,
    String route, {
    Object? arguments = null,
  }) {
    return Navigator.pushNamedAndRemoveUntil(
      context,
      route,
      (Route<dynamic> route) => false,
      arguments: arguments,
    );
  }

  // valid
  static bool validHumanName(input) {
    return RegExp(r'^[a-z\s]+$').hasMatch(input);
  }
}
