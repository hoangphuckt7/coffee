import 'package:orderr_app/blocs/change_table/change_table_bloc.dart';
import 'package:orderr_app/models/order/order_create_model.dart';
import 'package:orderr_app/routes.dart';
import 'package:orderr_app/ui/widgets/frame_common.dart';
import 'package:orderr_app/ui/widgets/processing.dart';
import 'package:orderr_app/utils/enum.dart';
import 'package:orderr_app/utils/function_common.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

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
      showUserInfo: true,
      showLogoutBtn: true,
      onWillPop: () => _back(context),
      onClickBackBtn: () => _back(context),
      child: Stack(
        children: [
          // _main(context),
          _processState(context),
        ],
      ),
    );
  }

  Widget _processState(BuildContext context) {
    return BlocBuilder<ChangeTableBloc, ChangeTableState>(
      builder: (context, state) {
        bool isLoading = false;
        String loadingMsg = "";
        if (state is CTErrorState) {
          Fn.showToast(eToast: EToast.danger, msg: state.errMsg.toString());
        } else if (state is CTUpdatedLoadingState) {
          isLoading = state.isLoading;
          loadingMsg = state.labelLoading;
        }
        return Processing(msg: loadingMsg, show: isLoading);
      },
    );
  }

  _back(BuildContext context) =>
      Fn.pushScreen(context, RouteName.pickTable, arguments: [order]);
}
