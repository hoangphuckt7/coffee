import 'package:bbc_order_mobile/ui/widgets/frame_common.dart';
import 'package:flutter/cupertino.dart';

class OrderScreen extends StatelessWidget {
  const OrderScreen({super.key});

  @override
  Widget build(BuildContext context) {
    return MainFrame(
        showBackBtn: true,
        showUserInfo: false,
        showLogoutBtn: false,
        child: SizedBox(
          child: Text('Order Screen'),
        ));
  }
}
