import 'package:bbc_order_mobile/models/order/order_create_model.dart';
import 'package:bbc_order_mobile/routes.dart';
import 'package:bbc_order_mobile/ui/widgets/frame_common.dart';
import 'package:bbc_order_mobile/utils/function_common.dart';
import 'package:flutter/cupertino.dart';

class ChangeTableScreen extends StatelessWidget {
  final OrderCreateModel? order;
  const ChangeTableScreen({
    super.key,
    this.order,
  });

  @override
  Widget build(BuildContext context) {
    return MainFrame(
      showBackBtn: true,
      showUserInfo: false,
      showLogoutBtn: false,
      title: 'Chuyển / Gộp bàn',
      onWillPop: _back(context),
      onClickBackBtn: _back(context),
      child: const SizedBox(
        child: Text('Change table screen'),
      ),
    );
  }

  _back(BuildContext context) =>
      Fn.pushScreen(context, RouteName.order, arguments: [order]);
}
