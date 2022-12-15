// ignore_for_file: must_be_immutable, unrelated_type_equality_checks

import 'dart:developer';

import 'package:orderr_app/blocs/change_table/change_table_bloc.dart';
import 'package:orderr_app/models/common/base_model.dart';
import 'package:orderr_app/models/order/order_create_model.dart';
import 'package:orderr_app/models/order/order_model.dart';
import 'package:orderr_app/models/table/table_model.dart';
import 'package:orderr_app/routes.dart';
import 'package:orderr_app/ui/controls/fill_btn.dart';
import 'package:orderr_app/ui/widgets/dropdown_floor.dart';
import 'package:orderr_app/ui/widgets/dropdown_table.dart';
import 'package:orderr_app/ui/widgets/empty.dart';
import 'package:orderr_app/ui/widgets/frame_common.dart';
import 'package:orderr_app/ui/widgets/order_change_table_card.dart';
import 'package:orderr_app/ui/widgets/popup.dart';
import 'package:orderr_app/ui/widgets/popup_confirm.dart';
import 'package:orderr_app/ui/widgets/processing.dart';
import 'package:orderr_app/ui/widgets/title_custom.dart';
import 'package:orderr_app/utils/enum.dart';
import 'package:orderr_app/utils/function_common.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:orderr_app/utils/ui_setting.dart';

class ChangeTableScreen extends StatelessWidget {
  final OrderCreateModel? order;
  final bool isChange;
  ChangeTableScreen({
    super.key,
    this.order,
    required this.isChange,
  });

  bool isLoading = false;
  String loadingMsg = "";

  bool isShowPopupConfirm = false;
  bool isShowPopupSelectTableNew = false;
  List<BaseModel> lstFloor = <BaseModel>[];
  List<TableModel> lstTableOld = <TableModel>[];
  List<TableModel> lstTableNew = <TableModel>[];

  List<OrderModel> lstOrder = <OrderModel>[];
  List<String?> lstSelectedOrder = <String?>[];

  BaseModel? selectedFloorOld;
  BaseModel? selectedFloorNew;

  TableModel? selectedTableOld;
  TableModel? selectedTableNew;

  final TextStyle txtStyleFT = const TextStyle(fontWeight: FontWeight.bold);

  int _selLen() => lstSelectedOrder.length;
  int _orLen() => lstOrder.length;

  _getCbxValue() {
    if (_getCbxTristate()) return null;
    return _selLen() > 0 && _orLen() > 0 && _selLen() == _orLen();
  }

  _getCbxTristate() {
    return _selLen() > 0 && _orLen() > 0 && _selLen() != _orLen();
  }

  @override
  Widget build(BuildContext context) {
    return MainFrame(
      showBackBtn: true,
      showUserInfo: false,
      showLogoutBtn: false,
      title: isChange ? 'Chuyển / Gộp bàn' : 'Xem thông tin',
      onWillPop: () => _back(context),
      onClickBackBtn: () => _back(context),
      child: Stack(
        children: [
          _ftOld(context),
          _ftNew(context),
          _processState(context),
          _popupConfirmChange(context),
        ],
      ),
    );
  }

  Widget _processState(BuildContext context) {
    return BlocListener<ChangeTableBloc, ChangeTableState>(
      listener: (context, state) {
        if (state is CTGoToPickTableState) {
          Fn.showToast(
            eToast: EToast.success,
            msg: 'Chuyển / Gộp bàn thành công',
          );
          _back(context);
        }
      },
      child: BlocBuilder<ChangeTableBloc, ChangeTableState>(
        builder: (context, state) {
          isLoading = false;
          if (state is CTErrorState) {
            isShowPopupConfirm = false;
            Fn.showToast(eToast: EToast.danger, msg: state.errMsg.toString());
          }
          if (state is CTUpdatedLoadingState) {
            isLoading = state.isLoading;
            loadingMsg = state.labelLoading;
          }
          if (state is CTLoadedFloorTableState) {
            selectedFloorOld = state.selectedFloorOld;
            selectedFloorNew = state.selectedFloorNew;

            selectedTableOld = state.selectedTableOld;
            selectedTableNew = state.selectedTableNew;

            lstFloor = state.lstFloor;

            lstTableOld = state.lstTableOld;
            lstTableNew = state.lstTableNew;

            lstOrder = state.lstOrders;
            lstSelectedOrder = lstOrder.map((x) => x.id).toList();
          }
          if (state is CTChangedFloorOldState) {
            selectedFloorOld = state.floor;
            selectedTableOld = state.selectedTable;
            lstTableOld = state.listTable;
            lstOrder = state.listOrder;
            lstSelectedOrder = lstOrder.map((x) => x.id).toList();
          }
          if (state is CTChangedTableOldState) {
            selectedTableOld = state.table;
            lstOrder = state.lstOrder;
            lstSelectedOrder = lstOrder.map((x) => x.id).toList();
          }
          if (state is CTUpdateSelectedOrdersState) {
            lstSelectedOrder = state.listSelectedOrders;
          }
          if (state is CTUpdateCbxAllState) {
            lstSelectedOrder = state.listSelectedOrder;
          }
          return Processing(msg: loadingMsg, show: isLoading);
        },
      ),
    );
  }

  // old
  Widget _ftOld(BuildContext context) {
    return Padding(
      padding: const EdgeInsets.all(30),
      child: Column(
        children: [
          TitleCustom(
            title: isChange ? 'Bàn chuyển đi' : 'Thông tin Khu vực / Bàn',
          ),
          Row(children: [Text("Khu vực:", style: txtStyleFT)]),
          BlocBuilder<ChangeTableBloc, ChangeTableState>(
            builder: (context, state) {
              return DropdownFloor(
                listFloor: lstFloor,
                selectedFloor: selectedFloorOld,
                onChanged: (value) {
                  BlocProvider.of<ChangeTableBloc>(context)
                      .add(CTChangeFloorOldEvent(value));
                },
              );
            },
          ),
          const SizedBox(height: 10),
          Row(children: [Text("Bàn:", style: txtStyleFT)]),
          BlocBuilder<ChangeTableBloc, ChangeTableState>(
            builder: (context, state) {
              return DropdownTable(
                listTable: lstTableOld,
                selectedTable: selectedTableOld,
                onChanged: (value) {
                  BlocProvider.of<ChangeTableBloc>(context)
                      .add(CTChangeTableOldEvent(value));
                },
              );
            },
          ),
          Padding(
            padding: const EdgeInsets.only(top: 20, bottom: 10),
            child: Column(
              children: [
                const TitleCustom(title: 'Danh sách Order'),
                Visibility(
                  visible: isChange,
                  child: Padding(
                    padding: const EdgeInsets.only(top: 20),
                    child: Row(
                      mainAxisAlignment: MainAxisAlignment.spaceBetween,
                      children: [
                        Expanded(
                          child: Row(
                            children: [
                              Text('Order đã chọn:  ', style: txtStyleFT),
                              BlocBuilder<ChangeTableBloc, ChangeTableState>(
                                builder: (context, state) {
                                  return Text('${_selLen()} / ${_orLen()}');
                                },
                              )
                            ],
                          ),
                        ),
                        Expanded(
                          child: Row(
                            mainAxisAlignment: MainAxisAlignment.end,
                            children: [
                              Text('Tất cả ', style: txtStyleFT),
                              Transform.scale(
                                scale: 1.3,
                                child: BlocBuilder<ChangeTableBloc,
                                    ChangeTableState>(
                                  builder: (context, state) {
                                    return Checkbox(
                                      value: _getCbxValue(),
                                      tristate: _getCbxTristate(),
                                      checkColor: MColor.primaryGreen,
                                      fillColor:
                                          MaterialStateProperty.all<Color>(
                                        MColor.primaryBlack,
                                      ),
                                      onChanged: (checked) {
                                        if (!isChange) return;
                                        BlocProvider.of<ChangeTableBloc>(
                                                context)
                                            .add(
                                          CTUpdateCbxAllEvent(
                                              lstOrder, _selLen()),
                                        );
                                      },
                                    );
                                  },
                                ),
                              )
                            ],
                          ),
                        ),
                      ],
                    ),
                  ),
                ),
              ],
            ),
          ),
          _lstOrder(context),
          const SizedBox(height: 20),
          Visibility(
            visible: isChange,
            child: BlocBuilder<ChangeTableBloc, ChangeTableState>(
              builder: (context, state) {
                return FillBtn(
                  label: 'Chọn bàn chuyển tới',
                  width: Fn.getScreenWidth(context) / 2,
                  height: 40,
                  btnBgColor: lstSelectedOrder.isNotEmpty
                      ? EColor.primary
                      : EColor.dark,
                  onPressed: () {
                    if (lstSelectedOrder.isEmpty) return;
                    BlocProvider.of<ChangeTableBloc>(context).add(
                      CTShowPopupSelectTableNewEvent(true),
                    );
                  },
                );
              },
            ),
          ),
          Visibility(
            visible: !isChange,
            child: FillBtn(
              label: 'Trở về',
              width: Fn.getScreenWidth(context) / 2,
              height: 40,
              onPressed: () => _back(context),
            ),
          ),
        ],
      ),
    );
  }

  Widget _lstOrder(BuildContext context) {
    return BlocBuilder<ChangeTableBloc, ChangeTableState>(
      builder: (context, state) {
        if (lstOrder.isEmpty) {
          return const Expanded(child: Empty());
        }
        return Expanded(
          child: ScrollConfiguration(
            behavior: ScrollConfiguration.of(context).copyWith(
              scrollbars: false,
            ),
            child: SingleChildScrollView(
              child: Column(
                children: List.generate(lstOrder.length, (i) {
                  var order = lstOrder[i];
                  return Padding(
                    padding: const EdgeInsets.symmetric(vertical: 5),
                    child: OrderChangeTableCard(
                      order: order,
                      lstSelected: lstSelectedOrder,
                      onTap: () {
                        if (isChange) {
                          BlocProvider.of<ChangeTableBloc>(context).add(
                            CTUpdateSelectedOrdersEvent(
                              order.id,
                              lstSelectedOrder,
                            ),
                          );
                        }
                      },
                    ),
                  );
                }),
              ),
            ),
          ),
        );
      },
    );
  }

  // new
  Widget _ftNew(BuildContext context) {
    return BlocBuilder<ChangeTableBloc, ChangeTableState>(
      builder: (context, state) {
        if (state is CTShowPopupSelectTableNewState) {
          isShowPopupSelectTableNew = state.isVisible;
        }
        if (state is CTChangedFloorNewState) {
          selectedFloorNew = state.floor;
          selectedTableNew = state.selectedTable;
          lstTableNew = state.listTable;
        }
        if (state is CTChangedTableNewState) {
          selectedTableNew = state.table;
        }
        return Popup(
          show: isShowPopupSelectTableNew,
          applyConstraints: true,
          padding: const EdgeInsets.all(20),
          children: [
            const TitleCustom(title: 'Bàn chuyển tới'),
            const SizedBox(height: 20),
            Expanded(
              child: Column(
                mainAxisAlignment: MainAxisAlignment.spaceAround,
                children: [
                  Row(children: [Text("Khu vực:", style: txtStyleFT)]),
                  DropdownFloor(
                    listFloor: lstFloor,
                    selectedFloor: selectedFloorNew,
                    onChanged: (value) {
                      BlocProvider.of<ChangeTableBloc>(context)
                          .add(CTChangeFloorNewEvent(value));
                    },
                  ),
                  Row(children: [Text("Bàn:", style: txtStyleFT)]),
                  DropdownTable(
                    listTable: lstTableNew,
                    selectedTable: selectedTableNew,
                    onChanged: (value) {
                      BlocProvider.of<ChangeTableBloc>(context)
                          .add(CTChangeTableNewEvent(value));
                    },
                  ),
                ],
              ),
            ),
            const SizedBox(height: 20),
            Row(
              mainAxisAlignment: MainAxisAlignment.spaceEvenly,
              children: [
                Expanded(
                  child: FillBtn(
                    label: 'Đóng',
                    btnBgColor: EColor.dark,
                    height: 40,
                    onPressed: () {
                      BlocProvider.of<ChangeTableBloc>(context).add(
                        CTShowPopupSelectTableNewEvent(false),
                      );
                    },
                  ),
                ),
                const SizedBox(width: 20),
                Expanded(
                  child: FillBtn(
                    label: 'Chuyển',
                    height: 40,
                    onPressed: () {
                      if (_validate()) {
                        BlocProvider.of<ChangeTableBloc>(context)
                            .add(CTShowPopupConfirmChangeEvent(true));
                      }
                    },
                  ),
                ),
              ],
            ),
          ],
        );
      },
    );
  }

  Widget _popupConfirmChange(BuildContext context) {
    return BlocBuilder<ChangeTableBloc, ChangeTableState>(
      builder: (context, state) {
        if (state is CTShowPopupConfirmChangeState) {
          isShowPopupConfirm = state.isVisible;
        }
        String? nameTableOld = selectedTableOld?.description;
        String? nameTablenew = selectedTableNew?.description;
        return PopupConfirm(
          visible: isShowPopupConfirm,
          title: 'Xác nhận chuyển bàn $nameTableOld qua $nameTablenew',
          onLeftBtnPressed: () {
            BlocProvider.of<ChangeTableBloc>(context)
                .add(CTShowPopupConfirmChangeEvent(false));
          },
          onRightBtnPressed: () {
            BlocProvider.of<ChangeTableBloc>(context).add(CTConfirmChangeEvent(
              selectedTableNew?.id,
              lstSelectedOrder,
            ));
          },
        );
      },
    );
  }

  _validate() {
    bool isError = false;
    String errMsg = '';

    bool isValidTableOld =
        selectedTableOld?.id != null && selectedTableOld?.id != '';
    bool isValidTableNew =
        selectedTableNew?.id != null && selectedTableNew?.id != '';

    if (!isValidTableOld) {
      errMsg = 'Vui lòng chọn bàn cần chuyển đi';
      isError = true;
    } else if (!isValidTableNew) {
      errMsg = 'Vui lòng chọn bàn cần chuyển tới';
      isError = true;
    } else if (isValidTableOld && isValidTableNew) {
      if (selectedTableOld?.id == selectedTableNew?.id) {
        errMsg = 'Bàn chuyển đi trùng với bàn chuyển tới';
        isError = true;
      }
    }

    if (isError) {
      Fn.showToast(eToast: EToast.danger, msg: errMsg);
      return false;
    }

    return true;
  }

  // common
  _back(BuildContext context) => Fn.pushScreen(
        context,
        RouteName.pickTable,
        arguments: [order],
      );
}
