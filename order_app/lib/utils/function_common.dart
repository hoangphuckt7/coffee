// ignore_for_file: unnecessary_null_comparison, avoid_init_to_null

import 'dart:convert';
import 'dart:developer';

import 'package:orderr_app/utils/enum.dart';
import 'package:orderr_app/utils/ui_setting.dart';
import 'package:flutter/material.dart';
import 'package:fluttertoast/fluttertoast.dart';
import 'package:intl/intl.dart';

class Fn {
  static getScreenWidth(BuildContext context) {
    return MediaQuery.of(context).size.width;
  }

  static getScreenHeight(BuildContext context) {
    return MediaQuery.of(context).size.height;
  }

  static showToast({
    EToast? eToast,
    String msg = '',
    ToastGravity? index = ToastGravity.TOP,
  }) {
    dynamic toastColor;
    switch (eToast) {
      case EToast.success:
        toastColor = MColor.success;
        break;
      case EToast.danger:
        toastColor = MColor.danger;
        break;
      case EToast.warning:
        toastColor = MColor.warning;
        break;
      default:
        toastColor = MColor.black;
        break;
    }
    Fluttertoast.showToast(
      msg: msg,
      backgroundColor: toastColor,
      gravity: index,
    );
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

  static renderData({input, errMsg = 'Không xác định'}) {
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
}
