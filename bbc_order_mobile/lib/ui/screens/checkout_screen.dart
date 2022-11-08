import 'package:bbc_order_mobile/blocs/checkout/checkout_bloc.dart';
import 'package:bbc_order_mobile/models/order/order_create_model.dart';
import 'package:bbc_order_mobile/models/order/order_detail_create_model.dart';
import 'package:bbc_order_mobile/routes.dart';
import 'package:bbc_order_mobile/ui/controls/fill_btn.dart';
import 'package:bbc_order_mobile/ui/widgets/frame_common.dart';
import 'package:bbc_order_mobile/ui/widgets/item_checkout_card.dart';
import 'package:bbc_order_mobile/ui/widgets/processing.dart';
import 'package:bbc_order_mobile/utils/enum.dart';
import 'package:bbc_order_mobile/utils/function_common.dart';
import 'package:bbc_order_mobile/utils/ui_setting.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:fluttertoast/fluttertoast.dart';

class CheckOutScreen extends StatelessWidget {
  final OrderCreateModel order;
  const CheckOutScreen({
    super.key,
    required this.order,
  });

  @override
  Widget build(BuildContext context) {
    return MainFrame(
      showBackBtn: true,
      showUserInfo: false,
      showLogoutBtn: false,
      title: 'Kiểm tra - Xác nhận',
      onClickBackBtn: () {
        Navigator.pushNamed(
          context,
          RouteName.order,
          arguments: [order],
        );
      },
      bottomBar: _bottom(context),
      child: Stack(children: [
        _main(context),
        _processState(context),
      ]),
    );
  }

  Widget _processState(BuildContext context) {
    return BlocBuilder<CheckoutBloc, CheckoutState>(
      builder: (context, state) {
        bool isLoading = false;
        String loadingMsg = "";
        if (state is ErrorState) {
          Fn.showToast(eToast: EToast.danger, msg: state.errMsg.toString());
        } else if (state is UpdatedLoadingState) {
          isLoading = state.isLoading;
          loadingMsg = state.labelLoading;
        }
        return Processing(msg: loadingMsg, show: isLoading);
      },
    );
  }

  Widget _main(BuildContext context) {
    return Padding(
      padding: const EdgeInsets.all(ScreenSetting.padding_all),
      child: Column(
        children: [
          _postion(context),
          Expanded(child: _detail(context)),
        ],
      ),
    );
  }

  Widget _detail(BuildContext context) {
    return SingleChildScrollView(
      child: Column(
        children: List.generate(order.orderDetail!.length, (i) {
          OrderDetailCreateModel model = order.orderDetail![i];
          return Column(
            children: [
              const SizedBox(height: 8),
              ItemCheckoutCard(model: model),
              const SizedBox(height: 8),
            ],
          );
        }),
      ),
    );
  }

  Widget? _bottom(BuildContext context) {
    return Container(
      decoration: const BoxDecoration(
        boxShadow: [
          BoxShadow(color: Colors.black12, blurRadius: 15),
        ],
      ),
      child: Padding(
        padding: const EdgeInsets.only(bottom: 0, left: 0, right: 0),
        child: Container(
          color: MColor.white,
          child: Padding(
            padding: const EdgeInsets.all(10),
            child: Row(
              crossAxisAlignment: CrossAxisAlignment.center,
              children: [
                const SizedBox(
                  child: Text(
                    'Tổng: ',
                    style: TextStyle(
                      fontWeight: FontWeight.bold,
                      color: MColor.danger,
                    ),
                  ),
                ),
                const SizedBox(width: 5),
                BlocBuilder<CheckoutBloc, CheckoutState>(
                  builder: (context, state) {
                    int totalItem = 0;
                    if (order.orderDetail!.isNotEmpty) {
                      for (var detail in order.orderDetail!) {
                        totalItem += detail.quantity;
                      }
                    }
                    return Expanded(
                      child: Text('$totalItem món'),
                    );
                  },
                ),
                FillBtn(
                  title: 'Xác nhận',
                  btnBgColor:
                      order.orderDetail != null ? EColor.primary : EColor.dark,
                  onPressed: () {
                    if (order.orderDetail != null) {
                    } else {
                      Fn.showToast(
                        eToast: EToast.danger,
                        msg: 'Vui lòng chọn món!',
                        index: ToastGravity.CENTER,
                      );
                    }
                  },
                ),
              ],
            ),
          ),
        ),
      ),
    );
  }

  Widget _postion(BuildContext context) {
    return Column(
      children: [
        Row(
          mainAxisAlignment: MainAxisAlignment.center,
          children: [
            const SizedBox(
              child: Text('Khu vực: '),
            ),
            SizedBox(
              child: Text(
                order.floor!.description!,
                style: const TextStyle(fontWeight: FontWeight.bold),
              ),
            ),
            const SizedBox(child: Text(' - ')),
            const SizedBox(
              child: Text('Bàn: '),
            ),
            SizedBox(
              child: Text(
                order.table!.description!,
                style: const TextStyle(fontWeight: FontWeight.bold),
              ),
            ),
          ],
        ),
        const SizedBox(height: 3),
        const Divider(
          color: MColor.primaryBlack,
          thickness: 1,
          indent: 50,
          endIndent: 50,
        ),
      ],
    );
  }
}
