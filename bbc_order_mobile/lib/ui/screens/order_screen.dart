// ignore_for_file: must_be_immutable

import 'package:bbc_order_mobile/blocs/order/order_bloc.dart';
import 'package:bbc_order_mobile/models/common/base_model.dart';
import 'package:bbc_order_mobile/models/item/item_model.dart';
import 'package:bbc_order_mobile/models/table/table_model.dart';
import 'package:bbc_order_mobile/routes.dart';
import 'package:bbc_order_mobile/ui/controls/field_outline.dart';
import 'package:bbc_order_mobile/ui/controls/fill_btn.dart';
import 'package:bbc_order_mobile/ui/widgets/dropdown_cate.dart';
import 'package:bbc_order_mobile/ui/widgets/frame_common.dart';
import 'package:bbc_order_mobile/ui/widgets/processing.dart';
import 'package:bbc_order_mobile/utils/enum.dart';
import 'package:bbc_order_mobile/utils/function_common.dart';
import 'package:bbc_order_mobile/utils/ui_setting.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
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
        if (state is ErrorState) {
          Fn.showToast(EToast.danger, state.errMsg.toString());
        } else if (state is UpdatedLoadingState) {
          isLoading = state.isLoading;
          loadingMsg = state.labelLoading;
        }
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
          _filter(context),
        ],
      ),
    );
  }

  Widget _filter(BuildContext context) {
    var searchController = TextEditingController();
    return BlocBuilder<OrderBloc, OrderState>(
      builder: (context, state) {
        if (state is LoadedCateItemState) {
          selectedCate = state.selectedCate;
          lstCate = state.lstCate;
          lstItem = state.lstItem;
        } else if (state is FilteredState) {
          selectedCate = state.cate;
          searchController.text = state.search;
        }
        return Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            const SizedBox(height: 10),
            const Divider(color: MColor.primaryBlack, thickness: 1),
            const SizedBox(height: 10),
            const SizedBox(child: Text('Chọn loại')),
            DropdownCategory(
              listCategory: lstCate,
              selectedCategory: selectedCate,
              onChanged: (value) {
                BlocProvider.of<OrderBloc>(context)
                    .add(FilterEvent(value, searchController.text));
              },
            ),
            FieldOutnine(
              labelText: 'Tìm kiếm',
              controller: searchController,
              errorText: null,
              onChanged: (value) {
                // BlocProvider.of<OrderBloc>(context)
                //     .add(FilterEvent(selectedCate, value));
              },
            ),
          ],
        );
      },
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
          ),
        ),
        const SizedBox(child: Text(' - ')),
        const SizedBox(
          child: Text('Bàn: '),
        ),
        SizedBox(
          child: Text(
            table.description!,
            style: const TextStyle(fontWeight: FontWeight.bold),
          ),
        ),
      ],
    );
  }
}
