// ignore_for_file: must_be_immutable

import 'dart:developer';
import 'dart:io';

import 'package:orderr_app/blocs/pick_tabel/pick_table_bloc.dart';
import 'package:orderr_app/models/common/base_model.dart';
import 'package:orderr_app/models/order/order_create_model.dart';
import 'package:orderr_app/models/order/order_detail_create_model.dart';
import 'package:orderr_app/models/table/table_model.dart';
import 'package:orderr_app/routes.dart';
import 'package:orderr_app/ui/controls/fill_btn.dart';
import 'package:orderr_app/ui/widgets/dropdown_floor.dart';
import 'package:orderr_app/ui/widgets/dropdown_table.dart';
import 'package:orderr_app/ui/widgets/frame_common.dart';
import 'package:orderr_app/ui/widgets/popup_confirm.dart';
import 'package:orderr_app/ui/widgets/processing.dart';
import 'package:orderr_app/utils/enum.dart';
import 'package:orderr_app/utils/function_common.dart';
import 'package:orderr_app/utils/ui_setting.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

class PickTableScreen extends StatelessWidget {
  OrderCreateModel? order;
  PickTableScreen({
    super.key,
    this.order,
  });

  bool isLoading = false;
  bool isShowPopupConfirmLogout = false;
  List<BaseModel> lstFloor = <BaseModel>[];
  List<TableModel> lstTable = <TableModel>[];
  List<OrderDetailCreateModel>? lstODtail = <OrderDetailCreateModel>[];
  BaseModel? selectedFloor;
  TableModel? selectedTable;

  @override
  Widget build(BuildContext context) {
    lstODtail = order?.orderDetail;
    return MainFrame(
      showBackBtn: false,
      showUserInfo: true,
      showLogoutBtn: true,
      onWillPop: () => _showPopupConfirmLogout(context),
      onClickEditUserBtn: () {
        Fn.pushScreen(context, RouteName.userInfo, arguments: [order]);
      },
      child: Stack(
        children: [
          _main(context),
          _processState(context),
          _popupConfirmLogout(context),
        ],
      ),
    );
  }

  Widget _processState(BuildContext context) {
    return BlocBuilder<PickTableBloc, PickTableState>(
      builder: (context, state) {
        bool isLoading = false;
        String loadingMsg = "";
        if (state is PTErrorState) {
          if (isShowPopupConfirmLogout) {
            isShowPopupConfirmLogout = false;
          }
          Fn.showToast(eToast: EToast.danger, msg: state.errMsg.toString());
        } else if (state is PTUpdatedLoadingState) {
          isLoading = state.isLoading;
          loadingMsg = state.labelLoading;
        }
        return Processing(msg: loadingMsg, show: isLoading);
      },
    );
  }

  Widget _main(BuildContext context) {
    return Container(
      padding: const EdgeInsets.all(20),
      child: Column(
        mainAxisAlignment: MainAxisAlignment.center,
        children: [
          Expanded(flex: 1, child: _changeTable(context)),
          Expanded(flex: 2, child: _selectTable(context)),
          Expanded(flex: 1, child: _nextStep(context)),
        ],
      ),
    );
  }

  Widget _changeTable(BuildContext context) {
    return Column(
      mainAxisAlignment: MainAxisAlignment.center,
      children: [
        Row(
          children: [
            Expanded(
              child: FillBtn(
                label: 'Chuyển / Gộp bàn',
                height: 40,
                onPressed: () {
                  if (order == null) {
                    order = OrderCreateModel(
                      selectedTable?.id,
                      selectedTable,
                      selectedFloor?.id,
                      selectedFloor,
                      const <OrderDetailCreateModel>[],
                    );
                  } else {
                    order?.floor = selectedFloor;
                    order?.floorId = selectedFloor?.id;
                    order?.table = selectedTable;
                    order?.tableId = selectedTable?.id;
                  }
                  Fn.pushScreen(
                    context,
                    RouteName.changeTable,
                    arguments: [order, true],
                  );
                },
              ),
            ),
            const SizedBox(width: 20),
            Expanded(
              child: FillBtn(
                label: 'Xem thông tin order',
                height: 40,
                onPressed: () {
                  if (order == null) {
                    order = OrderCreateModel(
                      selectedTable?.id,
                      selectedTable,
                      selectedFloor?.id,
                      selectedFloor,
                      const <OrderDetailCreateModel>[],
                    );
                  } else {
                    order?.floor = selectedFloor;
                    order?.floorId = selectedFloor?.id;
                    order?.table = selectedTable;
                    order?.tableId = selectedTable?.id;
                  }
                  Fn.pushScreen(
                    context,
                    RouteName.changeTable,
                    arguments: [order, false],
                  );
                },
              ),
            ),
          ],
        ),
      ],
    );
  }

  Widget _selectTable(BuildContext context) {
    return SingleChildScrollView(
      child: Column(
        mainAxisAlignment: MainAxisAlignment.center,
        children: [
          const Divider(
            color: MColor.primaryBlack,
            thickness: 1,
            indent: 50,
            endIndent: 50,
          ),
          const SizedBox(height: 10),
          const SizedBox(
            child: Text(
              'Chọn bàn order',
              style: TextStyle(
                fontSize: 20,
                fontWeight: FontWeight.bold,
                color: MColor.primaryBlack,
              ),
            ),
          ),
          const SizedBox(height: 20),
          SizedBox(
            width: Fn.getScreenWidth(context) * .8,
            child: Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                const Text(
                  "Khu vực:",
                  style: TextStyle(
                    fontWeight: FontWeight.bold,
                  ),
                ),
                BlocBuilder<PickTableBloc, PickTableState>(
                  builder: (context, state) {
                    if (state is PTLoadedFloorTableState) {
                      isLoading = false;
                      lstFloor = state.listFloor;
                      if (order != null && order?.floor != null) {
                        selectedFloor =
                            lstFloor.firstWhere((x) => x.id == order?.floorId);
                      } else {
                        selectedFloor = state.selectedFloor;
                      }
                    } else if (state is PTChangedFloorState) {
                      selectedFloor = state.floor;
                    }
                    return DropdownFloor(
                      listFloor: lstFloor,
                      selectedFloor: selectedFloor,
                      onChanged: (value) {
                        BlocProvider.of<PickTableBloc>(context)
                            .add(PTChangeFloorEvent(value));
                      },
                    );
                  },
                ),
                const SizedBox(height: 20),
                const Text(
                  "Bàn:",
                  style: TextStyle(fontWeight: FontWeight.bold),
                ),
                BlocBuilder<PickTableBloc, PickTableState>(
                  builder: (context, state) {
                    if (state is PTLoadedFloorTableState) {
                      isLoading = false;
                      lstTable = state.listTable;
                      if (order != null && order?.table != null) {
                        var lstByTableId = lstTable
                            .where((x) => x.id == order?.tableId)
                            .toList();
                        if (lstByTableId.isNotEmpty) {
                          selectedTable = lstByTableId.first;
                        }
                      } else {
                        selectedTable = state.selectedTable;
                      }
                    } else if (state is PTChangedTableState) {
                      selectedTable = state.table;
                    } else if (state is PTChangedFloorState) {
                      lstTable = state.listTable;
                      selectedTable = state.selectedTable;
                    }
                    return DropdownTable(
                      listTable: lstTable,
                      selectedTable: selectedTable,
                      onChanged: (value) {
                        BlocProvider.of<PickTableBloc>(context)
                            .add(PTChangeTableEvent(value));
                      },
                    );
                  },
                ),
              ],
            ),
          ),
        ],
      ),
    );
  }

  Widget _nextStep(BuildContext context) {
    return Column(
      mainAxisAlignment: MainAxisAlignment.center,
      children: [
        const SizedBox(height: 20),
        SizedBox(
          width: Fn.getScreenWidth(context) / 2,
          child: FillBtn(
            label: 'Tiếp theo',
            height: 40,
            onPressed: () {
              if (selectedTable != null && selectedFloor != null) {
                if (order == null) {
                  order = OrderCreateModel(
                    selectedTable?.id,
                    selectedTable,
                    selectedFloor?.id,
                    selectedFloor,
                    const <OrderDetailCreateModel>[],
                  );
                } else {
                  order?.floor = selectedFloor;
                  order?.floorId = selectedFloor?.id;
                  order?.table = selectedTable;
                  order?.tableId = selectedTable?.id;
                }
                Fn.pushScreen(context, RouteName.order, arguments: [order]);
              }
              if (selectedFloor == null) {
                Fn.showToast(
                  eToast: EToast.danger,
                  msg: 'Vui lòng chọn khu vục!',
                );
              } else if (selectedTable == null) {
                Fn.showToast(
                  eToast: EToast.danger,
                  msg: 'Vui lòng chọn bàn!',
                );
              }
            },
          ),
        ),
      ],
    );
  }

  Widget _popupConfirmLogout(BuildContext context) {
    return BlocBuilder<PickTableBloc, PickTableState>(
      builder: (context, state) {
        if (state is PTShowPopupConfirmExitState) {
          isShowPopupConfirmLogout = state.isVisible;
        }
        return PopupConfirm(
          visible: isShowPopupConfirmLogout,
          title: 'Xác nhận thoát ứng dụng',
          onLeftBtnPressed: () {
            BlocProvider.of<PickTableBloc>(context)
                .add(PTShowPopupConfirmExitEvent(false));
          },
          onRightBtnPressed: () => exit(0),
        );
      },
    );
  }

  _showPopupConfirmLogout(BuildContext context) {
    BlocProvider.of<PickTableBloc>(context)
        .add(PTShowPopupConfirmExitEvent(true));
  }
}
