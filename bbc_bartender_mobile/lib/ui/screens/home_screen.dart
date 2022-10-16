// ignore_for_file: non_constant_identifier_names

import 'dart:developer';

import 'package:bbc_bartender_mobile/blocs/home/home_bloc.dart';
import 'package:bbc_bartender_mobile/repositories/item_repo.dart';
import 'package:bbc_bartender_mobile/repositories/order_repo.dart';
import 'package:bbc_bartender_mobile/ui/widgets/card_custom.dart';
import 'package:bbc_bartender_mobile/ui/widgets/processing.dart';
import 'package:bbc_bartender_mobile/utils/enum.dart';
import 'package:bbc_bartender_mobile/utils/function_common.dart';
import 'package:bbc_bartender_mobile/utils/ui_setting.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

class HomeScreen extends StatefulWidget {
  const HomeScreen({super.key});

  @override
  State<HomeScreen> createState() => _HomeScreenState();
}

class _HomeScreenState extends State<HomeScreen> {
  @override
  Widget build(BuildContext context) {
    return Container(
      color: MColor.white,
      child: BlocProvider(
        create: (context) => HomeBloc(
          RepositoryProvider.of<ItemRepo>(context),
          RepositoryProvider.of<OrderRepo>(context),
        )..add(LoadDataEvent()),
        child: BlocBuilder<HomeBloc, HomeState>(
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
            return Stack(
              children: [
                Processing(msg: loadingMsg, show: isLoading),
                _main(context, state),
              ],
            );
          },
        ),
      ),
    );
  }

  // GlobalKey wgLeft = GlobalKey();
  GlobalKey wgRight = GlobalKey();
  final scrollController = ScrollController();
  bool showArrowTop = false;
  bool showArrowBot = false;

  @override
  void setState(VoidCallback fn) {
    // TODO: implement setState
    super.setState(fn);

    scrollController.addListener(() {
      if (scrollController.position.atEdge) {
        double currentPixels = scrollController.position.pixels;
        bool isTop = currentPixels == 0;
        bool isBot = currentPixels == wgRight.currentContext!.size!.height;
        if (isTop) {
          showArrowTop = false;
          showArrowBot = true;
          // BlocProvider.of<HomeBloc>(context).add(OrderScrollEvent(false, true));
        } else if (isBot) {
          showArrowTop = true;
          showArrowBot = false;
          // BlocProvider.of<HomeBloc>(context).add(OrderScrollEvent(true, false));
        } else {
          showArrowTop = true;
          showArrowBot = true;
          // BlocProvider.of<HomeBloc>(context).add(OrderScrollEvent(true, true));
        }
      }
    });
  }

  Widget _main(BuildContext context, HomeState state) {
    if (state is OrderScrolledState) {
      showArrowTop = state.showArrowTop;
      showArrowBot = state.showArrowBot;
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
                  edgeInsets: const EdgeInsets.symmetric(
                    vertical: 0,
                    horizontal: 20,
                  ),
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
                          key: wgRight,
                          controller: scrollController,
                          child: Column(
                            children: const [
                              Text('data1'),
                              Text('data2'),
                              Text('data3'),
                              Text('data4'),
                              Text('data5'),
                              Text('data6'),
                              Text('data7'),
                              Text('data8'),
                              Text('data9'),
                              Text('data10'),
                              Text('data11'),
                              Text('data12'),
                              Text('data13'),
                              Text('data14'),
                              Text('data15'),
                              Text('data16'),
                              Text('data17'),
                              Text('data18'),
                              Text('data19'),
                              Text('data20'),
                              Text('data21'),
                              Text('data22'),
                              Text('data23'),
                              Text('data24'),
                              Text('data25'),
                              Text('data26'),
                              Text('data27'),
                              Text('data28'),
                              Text('data29'),
                              Text('data30'),
                              Text('data31'),
                              Text('data32'),
                              Text('data33'),
                              Text('data34'),
                              Text('data35'),
                              Text('data36'),
                              Text('data37'),
                              Text('data38'),
                              Text('data39'),
                              Text('data40'),
                              Text('data41'),
                              Text('data42'),
                              Text('data43'),
                              Text('data44'),
                              Text('data45'),
                              Text('data46'),
                              Text('data47'),
                              Text('data48'),
                              Text('data49'),
                              Text('data50'),
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
