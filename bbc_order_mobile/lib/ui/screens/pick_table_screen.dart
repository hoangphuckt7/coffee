// ignore_for_file: must_be_immutable

import 'package:bbc_order_mobile/blocs/pick_tabel/pick_table_bloc.dart';
import 'package:bbc_order_mobile/repositories/category_repo.dart';
import 'package:bbc_order_mobile/repositories/item_repo.dart';
import 'package:bbc_order_mobile/repositories/order_repo.dart';
import 'package:bbc_order_mobile/ui/controls/fill_btn.dart';
import 'package:bbc_order_mobile/ui/widgets/appbar_custom.dart';
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
    return Scaffold(
      appBar: const AppbarCustom(
        showBackBtn: false,
      ),
      body: Padding(
        padding: const EdgeInsets.all(10),
        child: Container(
          alignment: Alignment.center,
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
                _main(context),
              ],
            ),
          ),
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

  Widget _main(BuildContext context) {
    return Column(
      children: [
        const SizedBox(height: 10),
        FillBtn(title: 'Chuyển / Gộp bàn', onPressed: () {}),
        const SizedBox(height: 20),
        const Divider(
          color: MColor.primaryBlack,
          thickness: 2,
          indent: 50,
          endIndent: 50,
        ),
        const SizedBox(height: 20),
        const SizedBox(
          child: Text(
            'Chọn bàn order',
            style: TextStyle(
              fontSize: 20,
              fontWeight: FontWeight.bold,
              color: MColor.primaryBlack,
            ),
          ),
        ),
        const SizedBox(height: 20),
        SizedBox(
          width: Fn.getScreenWidth(context) * .6,
          child: Row(
            children: const [
              Text("Khu vực:"),
            ],
          ),
        ),
        const SizedBox(height: 20),
        FillBtn(title: 'Tiếp theo', onPressed: () {}),
      ],
    );
  }
}
