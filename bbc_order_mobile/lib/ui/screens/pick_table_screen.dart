// ignore_for_file: must_be_immutable

import 'package:bbc_order_mobile/blocs/pick_tabel/pick_table_bloc.dart';
import 'package:bbc_order_mobile/models/common/base_model.dart';
import 'package:bbc_order_mobile/models/order/order_create_model.dart';
import 'package:bbc_order_mobile/models/order/order_detail_create_model.dart';
import 'package:bbc_order_mobile/models/table/table_model.dart';
import 'package:bbc_order_mobile/routes.dart';
import 'package:bbc_order_mobile/ui/controls/fill_btn.dart';
import 'package:bbc_order_mobile/ui/widgets/dropdown_floor.dart';
import 'package:bbc_order_mobile/ui/widgets/dropdown_table.dart';
import 'package:bbc_order_mobile/ui/widgets/frame_common.dart';
import 'package:bbc_order_mobile/ui/widgets/processing.dart';
import 'package:bbc_order_mobile/utils/enum.dart';
import 'package:bbc_order_mobile/utils/function_common.dart';
import 'package:bbc_order_mobile/utils/ui_setting.dart';
import 'package:flutter/material.dart';
import 'package:flutter_bloc/flutter_bloc.dart';

class PickTableScreen extends StatelessWidget {
  OrderCreateModel? order;
  PickTableScreen({
    super.key,
    this.order,
  });
  bool isLoading = false;
  List<BaseModel> lstFloor = <BaseModel>[];
  List<TableModel> lstTable = <TableModel>[];
  BaseModel? selectedFloor;
  TableModel? selectedTable;
  @override
  Widget build(BuildContext context) {
    return MainFrame(
      showBackBtn: false,
      showUserInfo: true,
      showLogoutBtn: true,
      child: Stack(
        children: [
          _main(context),
          _processState(context),
        ],
      ),
    );
  }

  Widget _processState(BuildContext context) {
    return BlocBuilder<PickTableBloc, PickTableState>(
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
    return Container(
      padding: const EdgeInsets.all(20),
      child: Column(
        mainAxisAlignment: MainAxisAlignment.center,
        children: [
          Expanded(
            flex: 1,
            child: Column(
              mainAxisAlignment: MainAxisAlignment.center,
              children: [
                FillBtn(
                  title: 'Chuyển / Gộp bàn',
                  height: 40,
                  onPressed: () {
                    order ??= OrderCreateModel(
                      selectedTable?.id,
                      selectedTable,
                      selectedFloor?.id,
                      selectedFloor,
                      <OrderDetailCreateModel>[],
                    );
                    Fn.pushScreen(
                      context,
                      RouteName.changeTable,
                      arguments: [order],
                    );
                  },
                ),
              ],
            ),
          ),
          Expanded(
            flex: 2,
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
                          if (state is LoadedFloorTableState) {
                            isLoading = false;
                            lstFloor = state.listFloor;
                            if (order != null && order?.floor != null) {
                              selectedFloor = lstFloor
                                  .firstWhere((x) => x.id == order?.floorId);
                            } else {
                              selectedFloor = state.selectedFloor;
                            }
                          } else if (state is ChangedFloorState) {
                            selectedFloor = state.floor;
                            lstTable = state.listTable;
                            selectedTable = state.selectedTable;
                          }
                          return DropdownFloor(
                            listFloor: lstFloor,
                            selectedFloor: selectedFloor,
                            onChanged: (value) {
                              BlocProvider.of<PickTableBloc>(context)
                                  .add(ChangeFloorEvent(value));
                            },
                          );
                        },
                      ),
                      const SizedBox(height: 20),
                      const Text(
                        "Bàn:",
                        style: TextStyle(
                          fontWeight: FontWeight.bold,
                        ),
                      ),
                      BlocBuilder<PickTableBloc, PickTableState>(
                        builder: (context, state) {
                          if (state is LoadedFloorTableState) {
                            isLoading = false;
                            lstTable = state.listTable;
                            if (order != null && order?.table != null) {
                              selectedTable = lstTable
                                  .firstWhere((x) => x.id == order?.tableId);
                            } else {
                              selectedTable = state.selectedTable;
                            }
                          } else if (state is ChangedTableState) {
                            selectedTable = state.table;
                          }
                          return DropdownTable(
                            listTable: lstTable,
                            selectedTable: selectedTable,
                            onChanged: (value) {
                              BlocProvider.of<PickTableBloc>(context)
                                  .add(ChangeTableEvent(value));
                            },
                          );
                        },
                      ),
                    ],
                  ),
                ),
              ],
            ),
          ),
          const SizedBox(height: 20),
          Expanded(
            flex: 1,
            child: Column(
              mainAxisAlignment: MainAxisAlignment.center,
              children: [
                FillBtn(
                    title: 'Tiếp theo',
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
                        Fn.pushScreen(
                          context,
                          RouteName.order,
                          arguments: [order],
                        );
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
                    }),
              ],
            ),
          ),
        ],
      ),
    );
  }
}
