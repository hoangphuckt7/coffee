import 'package:bbc_order_mobile/ui/widgets/frame_common.dart';
import 'package:flutter/cupertino.dart';

class ChangeTableScreen extends StatelessWidget {
  const ChangeTableScreen({super.key});

  @override
  Widget build(BuildContext context) {
    return const MainFrame(
      showBackBtn: true,
      showUserInfo: false,
      showLogoutBtn: false,
      child: SizedBox(
        child: Text('Change table screen'),
      ),
    );
  }
}
