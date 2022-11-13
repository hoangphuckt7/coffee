// ignore_for_file: must_be_immutable

import 'package:orderr_app/blocs/order/order_bloc.dart';
import 'package:orderr_app/models/common/base_model.dart';
import 'package:orderr_app/models/item/item_model.dart';
import 'package:orderr_app/models/order/order_create_model.dart';
import 'package:orderr_app/models/order/order_detail_create_model.dart';
import 'package:orderr_app/routes.dart';
import 'package:orderr_app/ui/controls/field_outline.dart';
import 'package:orderr_app/ui/controls/fill_btn.dart';
import 'package:orderr_app/ui/controls/icon_btn.dart';
import 'package:orderr_app/ui/widgets/dropdown_cate.dart';
import 'package:orderr_app/ui/widgets/frame_common.dart';
import 'package:orderr_app/ui/widgets/item_order_card.dart';
import 'package:orderr_app/ui/widgets/processing.dart';
import 'package:orderr_app/utils/const.dart';
import 'package:orderr_app/utils/enum.dart';
import 'package:orderr_app/utils/function_common.dart';
import 'package:orderr_app/utils/ui_setting.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:fluttertoast/fluttertoast.dart';

class OrderScreen extends StatelessWidget {
  OrderCreateModel order;
  OrderScreen({
    super.key,
    required this.order,
  });

  List<ItemModel> lstItem = <ItemModel>[];
  List<BaseModel> lstCate = <BaseModel>[];
  BaseModel? selectedCate;
  String? search;
  var searchController = TextEditingController();
  List<OrderDetailCreateModel> lstODetailCreate = <OrderDetailCreateModel>[];

  @override
  Widget build(BuildContext context) {
    if (order.orderDetail!.isNotEmpty) {
      lstODetailCreate = order.orderDetail!;
    }
    return MainFrame(
      showBackBtn: true,
      showUserInfo: false,
      showLogoutBtn: false,
      title: 'Chọn món',
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
    return BlocBuilder<OrderBloc, OrderState>(
      builder: (context, state) {
        bool isLoading = false;
        String loadingMsg = "";
        if (state is ORErrorState) {
          Fn.showToast(eToast: EToast.danger, msg: state.errMsg.toString());
        } else if (state is ORUpdatedLoadingState) {
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
          _filter(context),
          Expanded(child: _menu(context)),
        ],
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
      child: Container(
        color: MColor.white,
        padding: const EdgeInsets.only(
          top: 10,
          bottom: 20,
          left: 20,
          right: 20,
        ),
        child: BlocBuilder<OrderBloc, OrderState>(
          builder: (context, state) {
            if (state is ORAddedToCartState) {
              lstODetailCreate = state.lstODetail;
              order.orderDetail = state.lstODetail;
            }
            int totalItem = 0;
            if (lstODetailCreate.isNotEmpty) {
              for (var detail in lstODetailCreate) {
                totalItem += detail.quantity;
              }
            }
            return Row(
              crossAxisAlignment: CrossAxisAlignment.center,
              children: [
                const Icon(
                  Icons.add_shopping_cart_rounded,
                  color: MColor.danger,
                ),
                const SizedBox(width: 5),
                Expanded(
                  child: Text('$totalItem món'),
                ),
                FillBtn(
                  label: 'Kiểm tra',
                  btnBgColor: lstODetailCreate.isNotEmpty
                      ? EColor.primary
                      : EColor.dark,
                  onPressed: () {
                    if (lstODetailCreate.isNotEmpty) {
                      order.orderDetail = lstODetailCreate;
                      Fn.pushScreen(
                        context,
                        RouteName.checkOut,
                        arguments: [order],
                      );
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
            );
          },
        ),
      ),
    );
  }

  Widget _menu(BuildContext context) {
    return Column(
      children: [
        const SizedBox(height: 10),
        const SizedBox(
          child: Text(
            'Menu',
            style: TextStyle(
              fontWeight: FontWeight.bold,
              fontSize: ScreenSetting.fontSize + 5,
            ),
          ),
        ),
        const SizedBox(height: 10),
        BlocBuilder<OrderBloc, OrderState>(
          builder: (context, state) {
            if (state is ORLoadedCateItemState) {
              lstItem = state.lstItem;
            }
            return Expanded(
              child: SingleChildScrollView(
                child: Column(
                  children: List.generate(lstItem.length, (i) {
                    var item = lstItem[i];
                    return BlocBuilder<OrderBloc, OrderState>(
                      builder: (context, state) {
                        ItemModel? newItem;
                        if (state is ORChangedSugarState) {
                          newItem = state.item;
                        } else if (state is ORChangedIceState) {
                          newItem = state.item;
                        } else if (state is ORAddedToCartState) {
                          newItem = state.item;
                        }
                        if (newItem?.id == item.id) {
                          lstItem[i] = newItem!;
                          item = lstItem[i];
                        }
                        return Column(
                          children: [
                            ItemOrderCard(
                              model: item,
                              currentSugar: item.sugar,
                              addToCart: () {
                                BlocProvider.of<OrderBloc>(context).add(
                                    ORAddToCartEvent(lstODetailCreate, item));
                              },
                              increaseSugar: () {
                                BlocProvider.of<OrderBloc>(context).add(
                                    ORChangeSugarEvent(
                                        item, AppInfo.IncreaseStep));
                              },
                              decreaseSugar: () {
                                BlocProvider.of<OrderBloc>(context).add(
                                    ORChangeSugarEvent(
                                        item, AppInfo.DecreaseStep));
                              },
                              currentIce: item.ice,
                              increaseIce: () {
                                BlocProvider.of<OrderBloc>(context).add(
                                    ORChangeIceEvent(
                                        item, AppInfo.IncreaseStep));
                              },
                              decreaseIce: () {
                                BlocProvider.of<OrderBloc>(context).add(
                                    ORChangeIceEvent(
                                        item, AppInfo.DecreaseStep));
                              },
                            ),
                            const SizedBox(height: 10),
                          ],
                        );
                      },
                    );
                  }),
                ),
              ),
            );
          },
        ),
      ],
    );
  }

  Widget _filter(BuildContext context) {
    return BlocBuilder<OrderBloc, OrderState>(
      builder: (context, state) {
        if (state is ORLoadedCateItemState) {
          selectedCate = state.selectedCate;
          lstCate = state.lstCate;
          lstItem = state.lstItem;
        } else if (state is ORFilteredState) {
          lstItem = state.lstItem;
          selectedCate = state.cate;
        }
        return Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            Row(
              crossAxisAlignment: CrossAxisAlignment.end,
              children: [
                Expanded(
                  flex: 6,
                  child: Column(
                    crossAxisAlignment: CrossAxisAlignment.start,
                    children: [
                      const SizedBox(
                        child: Text(
                          'Chọn loại',
                          style: TextStyle(
                            fontSize: 14,
                            fontWeight: FontWeight.bold,
                          ),
                        ),
                      ),
                      const SizedBox(height: 5),
                      Container(
                        decoration: BoxDecoration(
                          border: Border.all(color: MColor.primaryBlack),
                          borderRadius: const BorderRadius.all(
                            Radius.circular(BtnSetting.border_radius),
                          ),
                        ),
                        child: DropdownCategory(
                          fontSize: 14,
                          height: 35,
                          listCategory: lstCate,
                          selectedCategory: selectedCate,
                          onChanged: (value) {
                            BlocProvider.of<OrderBloc>(context).add(
                                ORFilterEvent(value, searchController.text));
                          },
                        ),
                      ),
                    ],
                  ),
                ),
                const SizedBox(width: 10),
                Expanded(
                  flex: 6,
                  child: Column(
                    crossAxisAlignment: CrossAxisAlignment.start,
                    children: [
                      const SizedBox(
                        child: Text(
                          'Tìm kiếm',
                          style: TextStyle(
                            fontSize: 14,
                            fontWeight: FontWeight.bold,
                          ),
                        ),
                      ),
                      const SizedBox(height: 5),
                      FieldOutline(
                        height: 37.5,
                        fontSize: 13,
                        controller: searchController,
                        eBorder: EBorder.all,
                        onChanged: (val) {
                          BlocProvider.of<OrderBloc>(context).add(ORFilterEvent(
                              selectedCate, searchController.text));
                        },
                      ),
                    ],
                  ),
                ),
                const SizedBox(width: 5),
                Expanded(
                  flex: 1,
                  child: IconBtn(
                    icons: Icons.clear_rounded,
                    btnBgColor: EColor.danger,
                    size: 40,
                    onPressed: (() {
                      BlocProvider.of<OrderBloc>(context)
                          .add(ORFilterEvent(lstCate[0], ''));
                      searchController.clear();
                      FocusScope.of(context).unfocus();
                    }),
                  ),
                )
              ],
            ),
          ],
        );
      },
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
      Fn.pushScreen(context, RouteName.pickTable, arguments: [order]);
}
