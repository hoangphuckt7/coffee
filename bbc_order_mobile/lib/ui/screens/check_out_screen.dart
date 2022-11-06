import 'package:bbc_order_mobile/ui/widgets/frame_common.dart';
import 'package:flutter/material.dart';

class CheckOutScreen extends StatelessWidget {
  const CheckOutScreen({super.key});

  @override
  Widget build(BuildContext context) {
    return const MainFrame(
      showBackBtn: true,
      showUserInfo: false,
      showLogoutBtn: false,
      child: SizedBox(
        child: Text('check out screen'),
      ),
    );
  }
}
