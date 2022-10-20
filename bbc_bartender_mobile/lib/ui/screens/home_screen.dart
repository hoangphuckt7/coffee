// ignore_for_file: non_constant_identifier_names, must_be_immutable

import 'dart:developer';

import 'package:bbc_bartender_mobile/blocs/home/home_bloc.dart';
import 'package:bbc_bartender_mobile/models/item/item_model.dart';
import 'package:bbc_bartender_mobile/models/order/order_detail_model.dart';
import 'package:bbc_bartender_mobile/models/order/order_model.dart';
import 'package:bbc_bartender_mobile/repositories/item_repo.dart';
import 'package:bbc_bartender_mobile/repositories/order_repo.dart';
import 'package:bbc_bartender_mobile/repositories/user_repo.dart';
import 'package:bbc_bartender_mobile/routes.dart';
import 'package:bbc_bartender_mobile/ui/controls/fill_btn.dart';
import 'package:bbc_bartender_mobile/ui/widgets/card_custom.dart';
import 'package:bbc_bartender_mobile/ui/widgets/empty.dart';
import 'package:bbc_bartender_mobile/ui/widgets/order_card.dart';
import 'package:bbc_bartender_mobile/ui/widgets/order_detail_card.dart';
import 'package:bbc_bartender_mobile/ui/widgets/processing.dart';
import 'package:bbc_bartender_mobile/utils/const.dart';
import 'package:bbc_bartender_mobile/utils/enum.dart';
import 'package:bbc_bartender_mobile/utils/function_common.dart';
import 'package:bbc_bartender_mobile/utils/local_storage.dart';
import 'package:bbc_bartender_mobile/utils/ui_setting.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

class HomeScreen extends StatelessWidget {
  HomeScreen({super.key});

  bool showArrowTop = false;
  bool showArrowBot = false;
  String selectedOrder = '';
  String? pinnedOrder = '';
  List<OrderModel> lstOrders = <OrderModel>[];
  List<OrderDetailModel> lstOrderDetails = <OrderDetailModel>[];
  String? fullname;

  @override
  Widget build(BuildContext context) {
    return Container(
      color: MColor.white,
      child: BlocProvider(
        create: (context) => HomeBloc(
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
    );
  }

  Widget _processState(BuildContext context) {
    return BlocBuilder<HomeBloc, HomeState>(
      builder: (context, state) {
        bool isLoading = false;
        String loadingMsg = "";
        if (state is ErrorState) {
          Fn.showToast(EToast.danger, state.errMsg.toString());
        } else if (state is ItemsLoadingState) {
          loadingMsg = state.loadingMsg.toString();
          isLoading = true;
        } else if (state is ItemsLoadedState) {
          EToast eToast = EToast.success;
          if (!state.isSuccess) eToast = EToast.danger;
          Fn.showToast(eToast, state.msg.toString());
        }
        return Processing(msg: loadingMsg, show: isLoading);
      },
    );
  }

  Widget _main(BuildContext context) {
    return Container(
      color: MColor.primaryBlack,
      child: Padding(
        padding: const EdgeInsets.all(15),
        child: Row(
          children: [
            _leftSide(context, true),
            const Icon(
              Icons.keyboard_arrow_left_rounded,
              color: MColor.primaryGreen,
              size: 45,
            ),
            _rightSide(context),
          ],
        ),
      ),
    );
  }

  Widget _leftSide(BuildContext context, bool isNew) {
    return BlocBuilder<HomeBloc, HomeState>(
      builder: (context, state) {
        if (state is OrdersLoadedState) {
          lstOrderDetails = state.lstOrderDetails;
        } else if (state is OrdersChangedState) {
          lstOrderDetails = state.lstOrderDetails;
          selectedOrder = state.orderId;
        }
        return Expanded(
          flex: 5,
          child: SizedBox(
            height: Fn.getScreenHeight(context),
            child: CardCustom(
              padding: const EdgeInsets.all(20),
              child: lstOrderDetails.isEmpty
                  ? const Center(child: Empty())
                  : Column(
                      children: [
                        Expanded(
                          child: SingleChildScrollView(
                            child: Column(
                              children:
                                  List.generate(lstOrderDetails.length, (i) {
                                var orderDetailModel = lstOrderDetails[i];
                                return BlocBuilder<HomeBloc, HomeState>(
                                  builder: (context, state) {
                                    List<String> itemCheck = <String>[];
                                    if (state is ItemCheckboxChangedState) {
                                      itemCheck = state.check;
                                    }
                                    return OrderDetailCard(
                                      model: orderDetailModel,
                                      itemCheck: itemCheck,
                                      onItemCheckChanged: (value) {
                                        if (value == true) {
                                          itemCheck
                                              .add(orderDetailModel.itemId!);
                                        } else {
                                          itemCheck = itemCheck
                                              .where((x) =>
                                                  x != orderDetailModel.itemId!)
                                              .toList();
                                        }
                                        BlocProvider.of<HomeBloc>(context).add(
                                          ItemCheckboxChangeEvent(itemCheck),
                                        );
                                      },
                                    );
                                  },
                                );
                              }),
                            ),
                          ),
                        ),
                        Padding(
                          padding: const EdgeInsets.only(top: 15),
                          child: FillBtn(
                            title: isNew ? 'Hoàn thành' : 'Hoàn tác',
                            btnBgColor: isNew ? EColor.primary : EColor.danger,
                            onPressed: () {
                              BlocProvider.of<HomeBloc>(context).add(
                                OrderSubmitEvent(isNew, selectedOrder),
                              );
                            },
                          ),
                        ),
                      ],
                    ),
            ),
          ),
        );
      },
    );
  }

  Widget _rightSide(BuildContext context) {
    return Expanded(
      flex: 3,
      child: SizedBox(
        height: Fn.getScreenHeight(context),
        child: Column(
          children: [
            _userInfo(context),
            Expanded(
              child: CardCustom(
                padding: const EdgeInsets.all(15),
                child: Column(
                  children: [
                    _orderArrorUp(context),
                    _listOrder(context, true),
                    _orderArrorDown(context),
                  ],
                ),
              ),
            ),
          ],
        ),
      ),
    );
  }

  Widget _listOrder(BuildContext context, bool isNew) {
    return BlocBuilder<HomeBloc, HomeState>(
      builder: (context, state) {
        if (state is OrdersLoadedState) {
          lstOrders = state.lstOrders;
          selectedOrder = lstOrders[0].id.toString();
        }
        if (state is OrdersPinnedState) {
          pinnedOrder = state.order?.id;
          lstOrders = state.lstOrders;
        }
        return Expanded(
          child: lstOrders.isEmpty
              ? const Center(child: Empty(msg: 'Không có order'))
              : SingleChildScrollView(
                  child: Column(
                    children: List.generate(lstOrders.length, (i) {
                      var orderModel = lstOrders[i];
                      return OrderCard(
                        model: orderModel,
                        isSelected: selectedOrder == orderModel.id,
                        isPinned: pinnedOrder == orderModel.id,
                        showPinned: !isNew,
                        onClick: () {
                          BlocProvider.of<HomeBloc>(context).add(
                            OrderChangeEvent(
                              orderModel.id,
                              orderModel.orderDetails,
                            ),
                          );
                        },
                        onPin: () {
                          dynamic data = orderModel;
                          if (pinnedOrder == orderModel.id) {
                            data = null;
                          }
                          BlocProvider.of<HomeBloc>(context).add(
                            OrderPinEvent(data, lstOrders),
                          );
                        },
                      );
                    }),
                  ),
                ),
        );
      },
    );
  }

  Widget _orderArrorUp(BuildContext context) {
    return BlocBuilder<HomeBloc, HomeState>(
      builder: (context, state) {
        return Visibility(
          visible: showArrowTop,
          child: const Icon(
            Icons.keyboard_arrow_up_rounded,
            size: 50,
          ),
        );
      },
    );
  }

  Widget _orderArrorDown(BuildContext context) {
    return BlocBuilder<HomeBloc, HomeState>(
      builder: (context, state) {
        return Visibility(
          visible: showArrowBot,
          child: const Icon(
            Icons.keyboard_arrow_down_rounded,
            size: 50,
          ),
        );
      },
    );
  }

  Widget _userInfo(BuildContext context) {
    return BlocConsumer<HomeBloc, HomeState>(
      listener: (context, state) {
        if (state is LogoutState) {
          Navigator.pushNamed(context, RouteName.login);
        }
      },
      builder: (context, state) {
        if (state is UserInfoLoadedState) {
          fullname = state.fullName;
        }
        return CardCustom(
          padding: const EdgeInsets.symmetric(vertical: 10, horizontal: 20),
          child: Row(
            children: [
              Expanded(
                child: SizedBox(
                  child: Text(
                    Fn.renderData(fullname, 'Không xác định'),
                    style: const TextStyle(
                      fontSize: 16,
                      fontWeight: FontWeight.bold,
                    ),
                  ),
                ),
              ),
              InkWell(
                onTap: () {
                  BlocProvider.of<HomeBloc>(context).add(LogoutEvent());
                },
                child: const Icon(
                  Icons.logout_outlined,
                  color: MColor.danger,
                  size: 30,
                ),
              ),
            ],
          ),
        );
      },
    );
  }
}
