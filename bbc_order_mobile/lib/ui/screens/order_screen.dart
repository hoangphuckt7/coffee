// ignore_for_file: must_be_immutable

import 'package:bbc_order_mobile/blocs/order/order_bloc.dart';
import 'package:bbc_order_mobile/models/common/base_model.dart';
import 'package:bbc_order_mobile/models/item/item_model.dart';
import 'package:bbc_order_mobile/models/table/table_model.dart';
import 'package:bbc_order_mobile/routes.dart';
import 'package:bbc_order_mobile/ui/widgets/dropdown_cate.dart';
import 'package:bbc_order_mobile/ui/widgets/frame_common.dart';
import 'package:bbc_order_mobile/ui/widgets/processing.dart';
import 'package:bbc_order_mobile/utils/ui_setting.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

class OrderScreen extends StatelessWidget {
  final BaseModel floor;
  final TableModel table;
  OrderScreen({
    super.key,
    required this.floor,
    required this.table,
  });

  List<ItemModel> lstItem = <ItemModel>[];
  List<BaseModel> lstCate = <BaseModel>[];
  BaseModel? selectedCate;
  String? search;
  @override
  Widget build(BuildContext context) {
    return MainFrame(
      showBackBtn: true,
      showUserInfo: false,
      showLogoutBtn: false,
      onClickBackBtn: () {
        Navigator.pushNamed(context, RouteName.pickTable);
      },
      child: Stack(children: [
        _main(context),
        _processState(context),
      ]),
    );
  }

  Widget _processState(BuildContext context) {
    return BlocBuilder<OrderBloc, OrderState>(
      builder: (context, state) {
        bool isLoading = false;
        String loadingMsg = "";
        // if (state is ErrorState) {
        //   Fn.showToast(EToast.danger, state.errMsg.toString());
        // } else if (state is UpdatedLoadingState) {
        //   isLoading = state.isLoading;
        //   loadingMsg = state.labelLoading;
        // }
        return Processing(msg: loadingMsg, show: isLoading);
      },
    );
  }

  Widget _main(BuildContext context) {
    return SingleChildScrollView(
      padding: const EdgeInsets.all(ScreenSetting.padding_all),
      child: Column(
        children: [
          _firstInfo(context),
        ],
      ),
    );
  }

  Widget _firstInfo(BuildContext context) {
    return Row(
      children: [
        const SizedBox(
          child: Text('Khu vực: '),
        ),
        SizedBox(
            child: Text(
          floor.description!,
          style: const TextStyle(fontWeight: FontWeight.bold),
        )),
        const SizedBox(child: Text(' - ')),
        const SizedBox(
          child: Text('Bàn: '),
        ),
        SizedBox(
            child: Text(
          table.description!,
          style: const TextStyle(fontWeight: FontWeight.bold),
        )),
      ],
    );
  }

  Widget _filter(BuildContext context) {
    return BlocBuilder<OrderBloc, OrderState>(
      builder: (context, state) {
        return Row(
          children: [
            DropdownCategory(
              listCategory: lstCate,
              selectedCategory: selectedCate,
              onChanged: (value) {
                BlocProvider.of<OrderBloc>(context)
                    .add(FilterEvent(value, search));
              },
            )
          ],
        );
      },
    );
  }
}
