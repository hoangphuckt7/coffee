// ignore_for_file: must_be_immutable

import 'package:bbc_order_mobile/blocs/pick_tabel/pick_table_bloc.dart';
import 'package:bbc_order_mobile/repositories/category_repo.dart';
import 'package:bbc_order_mobile/repositories/item_repo.dart';
import 'package:bbc_order_mobile/repositories/order_repo.dart';
import 'package:bbc_order_mobile/ui/widgets/processing.dart';
import 'package:bbc_order_mobile/utils/enum.dart';
import 'package:bbc_order_mobile/utils/function_common.dart';
import 'package:bbc_order_mobile/utils/ui_setting.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

class PickTableScreen extends StatelessWidget {
  PickTableScreen({super.key});
  bool isLoading = false;

  @override
  Widget build(BuildContext context) {
    return Container(
      color: MColor.white,
      child: BlocProvider(
        create: (context) => PickTableBloc(
          RepositoryProvider.of<CategoryRepo>(context),
          RepositoryProvider.of<ItemRepo>(context),
          RepositoryProvider.of<OrderRepo>(context),
        )..add(LoadDataEvent()),
        child: Stack(
          children: [
            _processState(context),
          ],
        ),
      ),
    );
  }

  Widget _processState(BuildContext context) {
    return BlocBuilder<PickTableBloc, PickTableState>(
      builder: (context, state) {
        bool isLoading = false;

        String loadingMsg = "";
        if (state is ErrorState) {
          Fn.showToast(EToast.danger, state.errMsg.toString());
        }
        return Processing(msg: loadingMsg, show: isLoading);
      },
    );
  }
}
