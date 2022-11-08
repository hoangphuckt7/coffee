// ignore_for_file: must_be_immutable

import 'package:bbc_order_mobile/blocs/order/order_bloc.dart';
import 'package:bbc_order_mobile/models/common/base_model.dart';
import 'package:bbc_order_mobile/models/item/item_model.dart';
import 'package:bbc_order_mobile/models/order/order_create_model.dart';
import 'package:bbc_order_mobile/models/order/order_detail_create_model.dart';
import 'package:bbc_order_mobile/routes.dart';
import 'package:bbc_order_mobile/ui/controls/field_outline.dart';
import 'package:bbc_order_mobile/ui/controls/fill_btn.dart';
import 'package:bbc_order_mobile/ui/controls/icon_btn.dart';
import 'package:bbc_order_mobile/ui/widgets/dropdown_cate.dart';
import 'package:bbc_order_mobile/ui/widgets/frame_common.dart';
import 'package:bbc_order_mobile/ui/widgets/item_order_card.dart';
import 'package:bbc_order_mobile/ui/widgets/processing.dart';
import 'package:bbc_order_mobile/utils/const.dart';
import 'package:bbc_order_mobile/utils/enum.dart';
import 'package:bbc_order_mobile/utils/function_common.dart';
import 'package:bbc_order_mobile/utils/ui_setting.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:fluttertoast/fluttertoast.dart';

class OrderScreen extends StatelessWidget {
  final OrderCreateModel order;
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
    return MainFrame(
      showBackBtn: true,
      showUserInfo: false,
      showLogoutBtn: false,
      title: 'Chọn món',
      onClickBackBtn: () {
        Navigator.pushNamed(
          context,
          RouteName.pickTable,
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
    return BlocBuilder<OrderBloc, OrderState>(
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
      child: Padding(
        padding: const EdgeInsets.only(bottom: 0, left: 0, right: 0),
        child: Container(
          color: MColor.white,
          child: Padding(
            padding: const EdgeInsets.all(10),
            child: BlocBuilder<OrderBloc, OrderState>(
              builder: (context, state) {
                if (state is AddedToCartState) {
                  lstODetailCreate = state.lstODetail;
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
                      title: 'Kiểm tra',
                      btnBgColor: lstODetailCreate.isNotEmpty
                          ? EColor.primary
                          : EColor.dark,
                      onPressed: () {
                        if (lstODetailCreate.isNotEmpty) {
                          order.orderDetail = lstODetailCreate;
                          Navigator.pushNamed(
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
            if (state is LoadedCateItemState) {
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
                        if (state is ChangedSugarState) {
                          newItem = state.item;
                        } else if (state is ChangedIceState) {
                          newItem = state.item;
                        } else if (state is AddedToCartState) {
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
                                    AddToCartEvent(lstODetailCreate, item));
                              },
                              increaseSugar: () {
                                BlocProvider.of<OrderBloc>(context).add(
                                    ChangeSugarEvent(
                                        item, AppInfo.IncreaseStep));
                              },
                              decreaseSugar: () {
                                BlocProvider.of<OrderBloc>(context).add(
                                    ChangeSugarEvent(
                                        item, AppInfo.DecreaseStep));
                              },
                              currentIce: item.ice,
                              increaseIce: () {
                                BlocProvider.of<OrderBloc>(context).add(
                                    ChangeIceEvent(item, AppInfo.IncreaseStep));
                              },
                              decreaseIce: () {
                                BlocProvider.of<OrderBloc>(context).add(
                                    ChangeIceEvent(item, AppInfo.DecreaseStep));
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
        if (state is LoadedCateItemState) {
          selectedCate = state.selectedCate;
          lstCate = state.lstCate;
          lstItem = state.lstItem;
        } else if (state is FilteredState) {
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
                            fontSize: 13,
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
                          fontSize: 12,
                          height: 30,
                          listCategory: lstCate,
                          selectedCategory: selectedCate,
                          onChanged: (value) {
                            BlocProvider.of<OrderBloc>(context)
                                .add(FilterEvent(value, searchController.text));
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
                            fontSize: 13,
                            fontWeight: FontWeight.bold,
                          ),
                        ),
                      ),
                      const SizedBox(height: 5),
                      FieldOutline(
                        height: 32,
                        fontSize: 12,
                        controller: searchController,
                        eBorder: EBorder.all,
                        onChanged: (value) {
                          BlocProvider.of<OrderBloc>(context).add(
                              FilterEvent(selectedCate, searchController.text));
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
                    size: 35,
                    onPressed: (() {
                      BlocProvider.of<OrderBloc>(context)
                          .add(FilterEvent(lstCate[0], ''));
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
}
