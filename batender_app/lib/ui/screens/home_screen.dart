// ignore_for_file: non_constant_identifier_names, must_be_immutable

import 'package:bartender_app/blocs/auth/auth_bloc.dart';
import 'package:bartender_app/blocs/home/home_bloc.dart';
import 'package:bartender_app/models/order/order_detail_model.dart';
import 'package:bartender_app/models/order/order_model.dart';
import 'package:bartender_app/routes.dart';
import 'package:bartender_app/ui/controls/fill_btn.dart';
import 'package:bartender_app/ui/controls/icon_btn.dart';
import 'package:bartender_app/ui/widgets/card_custom.dart';
import 'package:bartender_app/ui/widgets/empty.dart';
import 'package:bartender_app/ui/widgets/order_card.dart';
import 'package:bartender_app/ui/widgets/order_detail_card.dart';
import 'package:bartender_app/ui/widgets/processing.dart';
import 'package:bartender_app/utils/enum.dart';
import 'package:bartender_app/utils/function_common.dart';
import 'package:bartender_app/utils/ui_setting.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

class HomeScreen extends StatefulWidget {
  const HomeScreen({super.key});

  @override
  State<HomeScreen> createState() => _HomeScreenState();
}

class _HomeScreenState extends State<HomeScreen> with TickerProviderStateMixin {
  bool isLoading = false;
  String? fullName = '';
  String selectedOrder = '';
  String selectedOrderDone = '';
  String? pinnedOrder = '';
  List<OrderModel> lstOrders = <OrderModel>[];
  List<OrderModel> lstOrdersDone = <OrderModel>[];
  List<OrderDetailModel> lstOrderDetails = <OrderDetailModel>[];

  @override
  Widget build(BuildContext context) {
    return Container(
      color: MColor.white,
      child: Stack(
        children: [
          _main(context),
          _processState(context),
        ],
      ),
    );
  }

  Widget _processState(BuildContext context) {
    return BlocBuilder<HomeBloc, HomeState>(
      builder: (context, state) {
        String loadingMsg = "";
        if (state is HomeErrorState) {
          isLoading = false;
          Fn.showToast(eToast: EToast.danger, msg: state.errMsg.toString());
        } else if (state is HomeUpdateLoadingState) {
          isLoading = true;
          loadingMsg = state.labelLoading.toString();
        } else if (state is HomeItemsLoadedState) {
          EToast eToast = EToast.success;
          if (!state.isSuccess) eToast = EToast.danger;
          Fn.showToast(eToast: eToast, msg: state.msg.toString());
        } else if (state is HomeOrdersLoadedState ||
            state is HomeOrderSubmitSuccessState ||
            state is HomeOrderSubmitFailState) {
          isLoading = false;
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
            Expanded(flex: 4, child: _leftSide(context)),
            const Icon(
              Icons.keyboard_arrow_left_rounded,
              color: MColor.primaryGreen,
              size: 30,
            ),
            Expanded(flex: 3, child: _rightSide(context)),
          ],
        ),
      ),
    );
  }

  Widget _leftSide(BuildContext context) {
    bool isNew = true;
    return BlocBuilder<HomeBloc, HomeState>(
      builder: (context, state) {
        if (state is HomeOrdersLoadedState) {
          lstOrderDetails = state.lstOrderDetails;
        } else if (state is HomeOrdersChangedState) {
          lstOrderDetails = state.lstOrderDetails;
          selectedOrder = state.orderId;
        } else if (state is HomeOrdersDoneChangedState) {
          lstOrderDetails = state.lstOrderDetails;
          selectedOrderDone = state.orderId;
        } else if (state is HomeOrderTabChangedState) {
          isNew = state.isNew;
          lstOrderDetails = state.lstCurrentOrderDetail;
        } else if (state is HomeOrderSubmitSuccessState) {
          lstOrderDetails = state.lstDetails;
          pinnedOrder = state.pinnedOrder;
        } else if (state is HomeRecieveNewOrderState) {
          if (selectedOrder.isEmpty) {
            lstOrderDetails = state.lstDetail;
          }
        }
        return SizedBox(
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
                                  if (state is HomeItemCheckboxChangedState) {
                                    itemCheck = state.check;
                                  }
                                  return OrderDetailCard(
                                    model: orderDetailModel,
                                    itemCheck: itemCheck,
                                    showCheckItem: isNew,
                                    onItemCheckChanged: (value) {
                                      if (value == true) {
                                        itemCheck.add(orderDetailModel.itemId!);
                                      } else {
                                        itemCheck = itemCheck
                                            .where((x) =>
                                                x != orderDetailModel.itemId!)
                                            .toList();
                                      }
                                      BlocProvider.of<HomeBloc>(context).add(
                                        HomeItemCheckboxChangeEvent(itemCheck),
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
                          label: isNew ? 'Hoàn thành' : 'Hoàn tác',
                          btnBgColor: isNew ? EColor.primary : EColor.danger,
                          onPressed: () {
                            BlocProvider.of<HomeBloc>(context).add(
                              HomeOrderSubmitEvent(
                                isNew,
                                selectedOrder,
                                lstOrders,
                                selectedOrderDone,
                                lstOrdersDone,
                                lstOrderDetails,
                                pinnedOrder,
                              ),
                            );
                          },
                        ),
                      ),
                    ],
                  ),
          ),
        );
      },
    );
  }

  Widget _rightSide(BuildContext context) {
    TabController tabController = TabController(length: 2, vsync: this);
    return SizedBox(
      height: Fn.getScreenHeight(context),
      child: Column(
        children: [
          _userInfo(context),
          Expanded(
            child: CardCustom(
              padding: const EdgeInsets.symmetric(
                vertical: 10,
                horizontal: 15,
              ),
              child: Column(
                children: [
                  _tabOrder(context, tabController),
                  const SizedBox(height: 10),
                  Expanded(
                    child: TabBarView(
                      controller: tabController,
                      children: [
                        Column(children: [_listOrder(context, true)]),
                        Column(children: [_listOrder(context, false)]),
                      ],
                    ),
                  ),
                ],
              ),
            ),
          ),
        ],
      ),
    );
  }

  Widget _tabOrder(BuildContext context, TabController tabController) {
    return BlocBuilder<HomeBloc, HomeState>(
      builder: (context, state) {
        if (state is HomeOrdersLoadedState) {
          tabController.index = 0;
          // fullName = state.fullName;
        }
        tabController.addListener(() {
          switch (tabController.index) {
            case 0:
              var lstDetail = <OrderDetailModel>[];
              if (lstOrders.isNotEmpty && selectedOrder.isNotEmpty) {
                lstDetail = lstOrders
                    .firstWhere((x) => x.id == selectedOrder)
                    .orderDetails!;
              }
              BlocProvider.of<HomeBloc>(context).add(
                HomeOrderTabChangeEvent(true, lstOrders, lstDetail),
              );
              break;
            case 1:
              var lstDetail = <OrderDetailModel>[];
              if (lstOrdersDone.isNotEmpty && selectedOrderDone.isNotEmpty) {
                lstDetail = lstOrdersDone
                    .firstWhere((x) => x.id == selectedOrderDone)
                    .orderDetails!;
              }
              BlocProvider.of<HomeBloc>(context).add(
                HomeOrderTabChangeEvent(false, lstOrdersDone, lstDetail),
              );
              break;
          }
        });
        return TabBar(
          unselectedLabelColor: MColor.primaryBlack,
          labelColor: MColor.primaryGreen,
          tabs: const [
            Tab(text: 'Hiện tại'),
            Tab(text: 'Hoàn thành'),
          ],
          controller: tabController,
          indicatorSize: TabBarIndicatorSize.tab,
          // onTap: ((value) {}),
        );
      },
    );
  }

  Widget _listOrder(BuildContext context, bool isNew) {
    List<OrderModel> currentLstOrder = <OrderModel>[];
    String currentId = '';
    return BlocBuilder<HomeBloc, HomeState>(
      builder: (context, state) {
        if (state is HomeOrdersLoadedState) {
          selectedOrder = state.selectedOrder;
          lstOrders = state.lstOrders;
          lstOrdersDone = state.lstOrdersDone;
          selectedOrderDone = state.selectedOrderDone;
        } else if (state is HomeOrdersPinnedState) {
          pinnedOrder = state.order?.id;
          lstOrders = state.lstOrders;
        } else if (state is HomeOrderSubmitSuccessState) {
          selectedOrder = state.selectedOrder;
          lstOrders = state.lstOrders;
          selectedOrderDone = state.selectedOrderDone;
          lstOrdersDone = state.lstOrdersDone;
        } else if (state is HomeRecieveNewOrderState) {
          lstOrders.addAll(state.lstOrder);
          if (selectedOrder.isEmpty) {
            selectedOrder = lstOrders[0].id!;
            lstOrderDetails = lstOrders[0].orderDetails!;
          }
        }
        if (isNew) {
          currentLstOrder = lstOrders;
          currentId = selectedOrder;
        } else {
          currentLstOrder = lstOrdersDone;
          currentId = selectedOrderDone;
        }
        return Expanded(
          child: currentLstOrder.isEmpty
              ? const Center(child: Empty(msg: 'Không có order'))
              : SingleChildScrollView(
                  child: Column(
                    children: List.generate(currentLstOrder.length, (i) {
                      var orderModel = currentLstOrder[i];
                      return OrderCard(
                        model: orderModel,
                        isSelected: currentId == orderModel.id,
                        isPinned: pinnedOrder == orderModel.id,
                        showPinned: isNew,
                        onClick: () {
                          if (isNew) {
                            BlocProvider.of<HomeBloc>(context).add(
                              HomeOrderChangeEvent(
                                orderModel.id,
                                orderModel.orderDetails,
                              ),
                            );
                          } else {
                            BlocProvider.of<HomeBloc>(context).add(
                              HomeOrderDoneChangeEvent(
                                orderModel.id,
                                orderModel.orderDetails,
                              ),
                            );
                          }
                        },
                        onPin: () {
                          dynamic data = orderModel;
                          if (pinnedOrder == orderModel.id) {
                            data = null;
                          }
                          BlocProvider.of<HomeBloc>(context).add(
                            HomeOrderPinEvent(data, currentLstOrder),
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

  Widget _userInfo(BuildContext context) {
    double? fontSize1 = 15;
    double? fontSize2 = 12;
    return CardCustom(
      padding: const EdgeInsets.symmetric(vertical: 10, horizontal: 20),
      child: Row(
        children: [
          BlocBuilder<AuthBloc, AuthState>(
            builder: (context, state) {
              if (state is AuthLoadedUserInfoState) {
                fullName = state.fullName;
              }
              return Expanded(
                child: SingleChildScrollView(
                  scrollDirection: Axis.horizontal,
                  child: Row(
                    children: [
                      SizedBox(
                        child: Text(
                          Fn.renderData(fullName, ''),
                          style: TextStyle(
                            fontSize: fontSize1,
                            fontWeight: FontWeight.bold,
                          ),
                        ),
                      ),
                    ],
                  ),
                ),
              );
            },
          ),
          const SizedBox(width: 10),
          BlocBuilder<HomeBloc, HomeState>(
            builder: (context, state) {
              return IconBtn(
                icons: Icons.edit_outlined,
                label: 'Sửa',
                fontSize: fontSize2,
                onPressed: () {
                  BlocProvider.of<HomeBloc>(context).add(HomeLoadDataEvent());
                },
              );
            },
          ),
          const SizedBox(width: 10),
          BlocBuilder<HomeBloc, HomeState>(
            builder: (context, state) {
              return IconBtn(
                icons: Icons.refresh_outlined,
                label: 'Tải lại',
                fontSize: fontSize2,
                onPressed: () {
                  BlocProvider.of<HomeBloc>(context).add(HomeLoadDataEvent());
                },
              );
            },
          ),
          const SizedBox(width: 10),
          BlocListener<AuthBloc, AuthState>(
            listener: (context, state) {
              if (state is AuthLogoutState) {
                Navigator.pushNamed(context, RouteName.login);
              }
            },
            child: IconBtn(
              icons: Icons.logout_outlined,
              label: 'Đăng xuất',
              btnBgColor: EColor.danger,
              fontSize: fontSize2,
              onPressed: () {
                BlocProvider.of<AuthBloc>(context).add(AuthLogoutEvent());
              },
            ),
          ),
        ],
      ),
    );
  }
}
