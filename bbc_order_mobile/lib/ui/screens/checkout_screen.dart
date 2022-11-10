// ignore_for_file: must_be_immutable

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

class CheckOutScreen extends StatelessWidget {
  final OrderCreateModel order;
  CheckOutScreen({
    super.key,
    required this.order,
  });

  List<List<TextEditingController>> lstListController =
      <List<TextEditingController>>[];

  @override
  Widget build(BuildContext context) {
    if (order.orderDetail!.isNotEmpty) {
      for (var detail in order.orderDetail!) {
        List<TextEditingController> lstTEC = <TextEditingController>[];
        for (var dct in detail.listDct!) {
          lstTEC.add(TextEditingController(text: dct.Note));
        }
        lstListController.add(lstTEC);
      }
    }
    return MainFrame(
      showBackBtn: true,
      showUserInfo: false,
      showLogoutBtn: false,
      title: 'Kiểm tra - Xác nhận',
      onWillPop: () => _back(context),
      onClickBackBtn: () => _back(context),
      bottomBar: _bottom(context),
      child: Stack(children: [
        _main(context),
        _processState(context),
      ]),
    );
  }

  Widget _processState(BuildContext context) {
    return BlocListener<CheckoutBloc, CheckoutState>(
      listener: (context, state) {
        if (state is GoBackOrderState) {
          Fn.showToast(eToast: EToast.danger, msg: "Vui lòng chọn món!");
          Fn.pushScreen(
            context,
            RouteName.order,
            arguments: [order],
          );
        }
      },
      child: BlocBuilder<CheckoutBloc, CheckoutState>(
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
      ),
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
      child: BlocBuilder<CheckoutBloc, CheckoutState>(
        builder: (context, state) {
          if (state is ChangedQuantityState) {
            OrderDetailCreateModel detail = state.detail;
            var index = order.orderDetail!.indexWhere(
              (x) => x.itemId == detail.itemId,
            );
            if (detail.quantity == 0) {
              if (order.orderDetail!.isNotEmpty) {
                order.orderDetail!.removeAt(index);
                lstListController.removeAt(index);
              }
            } else {
              order.orderDetail![index] = detail;
              lstListController[index] = state.listController;
            }

            if (order.orderDetail == null || order.orderDetail!.isEmpty) {
              BlocProvider.of<CheckoutBloc>(context).add(GoBackOrderEvent());
            }
          }
          return Column(
            children: List.generate(order.orderDetail!.length, (i) {
              OrderDetailCreateModel model = order.orderDetail![i];
              if (state is ChangedSugarState) {
                OrderDetailCreateModel detail = state.detail;
                if (model.itemId == detail.itemId) {
                  model = detail;
                }
              } else if (state is ChangedIceState) {
                OrderDetailCreateModel detail = state.detail;
                if (model.itemId == detail.itemId) {
                  model = detail;
                }
              } else if (state is ChangedNoteState) {
                OrderDetailCreateModel detail = state.detail;
                if (model.itemId == detail.itemId) {
                  model = detail;
                }
              }
              return Column(
                children: [
                  const SizedBox(height: 8),
                  ItemCheckoutCard(
                    model: model,
                    listController: lstListController[i],
                  ),
                  const SizedBox(height: 8),
                ],
              );
            }),
          );
        },
      ),
    );
  }

  Widget? _bottom(BuildContext context) {
    return BlocListener<CheckoutBloc, CheckoutState>(
      listener: (context, state) {
        if (state is GoToPickTableState) {
          Fn.showToast(eToast: EToast.success, msg: "Order thành công!");
          Fn.pushScreen(context, RouteName.pickTable);
        }
      },
      child: BlocBuilder<CheckoutBloc, CheckoutState>(
        builder: (context, state) {
          int totalItem = 0;
          if (order.orderDetail!.isNotEmpty) {
            for (var detail in order.orderDetail!) {
              totalItem += detail.quantity;
            }
          }

          return Container(
            decoration: const BoxDecoration(
              boxShadow: [
                BoxShadow(color: Colors.black12, blurRadius: 15),
              ],
            ),
            child: Container(
              color: MColor.white,
              padding: const EdgeInsets.only(
                top: 10,
                bottom: 20,
                left: 20,
                right: 20,
              ),
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
                  Expanded(child: Text('$totalItem món')),
                  FillBtn(
                    title: 'Xác nhận',
                    onPressed: () {
                      BlocProvider.of<CheckoutBloc>(context).add(
                        ConfirmOrderEvent(order),
                      );
                    },
                  ),
                ],
              ),
            ),
          );
        },
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

  _back(BuildContext context) =>
      Fn.pushScreen(context, RouteName.order, arguments: [order]);
}
