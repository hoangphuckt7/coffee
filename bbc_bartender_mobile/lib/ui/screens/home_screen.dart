// ignore_for_file: non_constant_identifier_names, must_be_immutable

import 'dart:developer';

import 'package:bbc_bartender_mobile/blocs/home/home_bloc.dart';
import 'package:bbc_bartender_mobile/models/item/item_model.dart';
import 'package:bbc_bartender_mobile/models/order/order_model.dart';
import 'package:bbc_bartender_mobile/repositories/item_repo.dart';
import 'package:bbc_bartender_mobile/repositories/order_repo.dart';
import 'package:bbc_bartender_mobile/ui/widgets/card_custom.dart';
import 'package:bbc_bartender_mobile/ui/widgets/order_card.dart';
import 'package:bbc_bartender_mobile/ui/widgets/processing.dart';
import 'package:bbc_bartender_mobile/utils/enum.dart';
import 'package:bbc_bartender_mobile/utils/function_common.dart';
import 'package:bbc_bartender_mobile/utils/ui_setting.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

class HomeScreen extends StatelessWidget {
  HomeScreen({super.key});

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
            BlocBuilder<HomeBloc, HomeState>(
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
            ),
            BlocBuilder<HomeBloc, HomeState>(
              builder: (context, state) {
                return _main(context, state);
              },
            ),
          ],
        ),
      ),
    );
  }

  // GlobalKey wgLeft = GlobalKey();
  GlobalKey wgRight = GlobalKey();
  final scrollController = ScrollController();
  bool showArrowTop = false;
  bool showArrowBot = false;

  Widget _main(BuildContext context, HomeState state) {
    List<ItemModel> lstItems = <ItemModel>[];
    List<OrderModel> lstOrders = <OrderModel>[];
    if (state is OrderScrolledState) {
      showArrowTop = state.showArrowTop;
      showArrowBot = state.showArrowBot;
    } else if (state is OrdersLoadedState) {
      lstItems = state.lstItems;
      lstOrders = state.lstOrders;
    }
    return Container(
      color: MColor.primaryBlack,
      child: Padding(
        padding: const EdgeInsets.all(15),
        child: Row(
          children: [
            Expanded(
              flex: 5,
              child: SizedBox(
                height: Fn.getScreenHeight(context),
                child: CardCustom(
                  edgeInsets: const EdgeInsets.all(20),
                  child: SingleChildScrollView(
                    child: Column(
                      children: const [
                        Text('data1'),
                        Text('data1'),
                        Text('data1'),
                        Text('data1'),
                        Text('data1'),
                        Text('data1'),
                        Text('data1'),
                        Text('data1'),
                        Text('data1'),
                        Text('data1'),
                        Text('data1'),
                        Text('data1'),
                        Text('data1'),
                        Text('data1'),
                        Text('data1'),
                        Text('data1'),
                        Text('data1'),
                        Text('data1'),
                        Text('data1'),
                        Text('data1'),
                        Text('data1'),
                        Text('data1'),
                        Text('data1'),
                        Text('data1'),
                        Text('data1'),
                        Text('data1'),
                        Text('data1'),
                        Text('data1'),
                        Text('data1'),
                        Text('data1'),
                        Text('data1'),
                        Text('data1'),
                        Text('data1'),
                        Text('data1'),
                        Text('data1'),
                        Text('data1'),
                        Text('data1'),
                        Text('data1'),
                        Text('data1'),
                        Text('data1'),
                        Text('data1'),
                        Text('data1'),
                        Text('data1'),
                        Text('data1'),
                        Text('data1'),
                        Text('data1'),
                        Text('data1'),
                        Text('data1'),
                      ],
                    ),
                  ),
                ),
              ),
            ),
            const Icon(
              Icons.keyboard_arrow_left_rounded,
              color: MColor.primaryGreen,
              size: 45,
            ),
            Expanded(
              flex: 3,
              child: SizedBox(
                height: Fn.getScreenHeight(context),
                child: CardCustom(
                  edgeInsets: const EdgeInsets.all(15),
                  child: Column(
                    children: [
                      Visibility(
                        visible: showArrowTop,
                        child: const Icon(
                          Icons.keyboard_arrow_up_rounded,
                          size: 50,
                        ),
                      ),
                      Expanded(
                        // child: NotificationListener(
                        child: SingleChildScrollView(
                          // key: wgRight,
                          // controller: scrollController,

                          child: Column(
                            children: [
                              for (var i = 0; i < lstOrders.length; i++)
                                OrderCard(
                                  orderModel: lstOrders[i],
                                  isSelected: i == 0,
                                  isPinned: i == 1,
                                )
                            ],
                          ),
                        ),
                        // onNotification: (e) {
                        //   if (e is ScrollEndNotification) {
                        //     log(e.metrics.pixels.toString());
                        //     bool isTop = e.metrics.pixels == 0;
                        //     if (isTop) {
                        //       log('top');
                        //       BlocProvider.of<HomeBloc>(context)
                        //           .add(OrderScrollEvent(false, true));
                        //     } else {
                        //       log('un-top');
                        //       log('screen height: ${Fn.getScreenHeight(context)}');
                        //       showArrowTop = true;

                        //     }
                        //   }
                        //   return true;
                        // },
                        // ),
                      ),
                      Visibility(
                        visible: showArrowBot,
                        child: const Icon(
                          Icons.keyboard_arrow_down_rounded,
                          size: 50,
                        ),
                      ),
                    ],
                  ),
                ),
              ),
            ),
          ],
        ),
      ),
    );
  }
}
