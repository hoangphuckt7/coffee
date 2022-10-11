import 'package:bbc_bartender_mobile/utils/enum.dart';
import 'package:bbc_bartender_mobile/utils/ui_setting.dart';
import 'package:fluttertoast/fluttertoast.dart';

class FunctionCommon {
  // static var vndFormat = NumberFormat.currency(locale: "vi_VN", symbol: "₫");
  // static formatCurrencyText(String currency) {
  //   return vndFormat.format(double.parse(currency));
  // }

  static showToast(EToast eToast, String msg) {
    dynamic toastColor = null;
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
}
