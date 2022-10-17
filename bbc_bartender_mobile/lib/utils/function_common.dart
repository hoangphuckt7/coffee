import 'package:bbc_bartender_mobile/utils/enum.dart';
import 'package:bbc_bartender_mobile/utils/ui_setting.dart';
import 'package:flutter/material.dart';
import 'package:fluttertoast/fluttertoast.dart';
import 'package:intl/intl.dart';

class Fn {
  // var screenWidth = MediaQuery.of(context).size.width;
  // var screenHeight = MediaQuery.of(context).size.height;
  static getScreenWidth(BuildContext context) {
    return MediaQuery.of(context).size.width;
  }

  static getScreenHeight(BuildContext context) {
    return MediaQuery.of(context).size.height;
  }
  // static var vndFormat = NumberFormat.currency(locale: "vi_VN", symbol: "₫");
  // static formatCurrencyText(String currency) {
  //   return vndFormat.format(double.parse(currency));
  // }

  static showToast(EToast eToast, String msg) {
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
    );
  }

  static formatDate(DateTime? date, DateFormat format) {
    return format.format(date!);
  }

  static convertOrderNumber(input) {
    String inputStr = input.toString();
    if (inputStr.length == 1) {
      return '#00$inputStr';
    } else if (inputStr.length == 2) {
      return '#0$inputStr';
    } else {
      return '#$inputStr';
    }
  }

  static renderData(input) {
    if (input != null) {
      return input.toString();
    } else {
      return 'Không xác định';
    }
  }
}
