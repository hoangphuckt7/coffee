import 'package:flutter/material.dart';
import 'package:orderr_app/models/order/order_create_model.dart';
import 'package:orderr_app/routes.dart';
import 'package:orderr_app/ui/widgets/frame_common.dart';
import 'package:orderr_app/utils/function_common.dart';

class OrderInfoScreen extends StatelessWidget {
  final OrderCreateModel? order;
  const OrderInfoScreen({
    super.key,
    this.order,
  });

  @override
  Widget build(BuildContext context) {
    return MainFrame(
      showBackBtn: true,
      showUserInfo: false,
      showLogoutBtn: false,
      title: 'Thông tin Order',
      onWillPop: () => _back(context),
      onClickBackBtn: () => _back(context),
      child: Stack(children: [
        // _main(context),
        // _processState(context),
      ]),
    );
    ;
  }

  _back(BuildContext context) =>
      Fn.pushScreen(context, RouteName.pickTable, arguments: [order]);
}
